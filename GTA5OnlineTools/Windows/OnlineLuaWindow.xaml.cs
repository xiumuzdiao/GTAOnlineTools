using GTA5OnlineTools.Data;
using GTA5OnlineTools.Utils;

using GTA5Shared.Helper;

using Downloader;

namespace GTA5OnlineTools.Windows;

/// <summary>
/// OnlineLuaWindow.xaml 的交互逻辑
/// </summary>
public partial class OnlineLuaWindow
{
    private DownloadService _downloader;

    private bool isUseKiddion = true;
    private string tempPath = string.Empty;

    private const string host = "https://api.crazyzhang.cn/lua";
    private const string kiddion = $"{host}/Kiddion.json";
    private const string yimMenu = $"{host}/YimMenu.json";

    public ObservableCollection<LuaInfo> OnlineLuas { get; set; } = new();

    public OnlineLuaWindow()
    {
        InitializeComponent();
    }

    private void Window_OnlineLua_Loaded(object sender, RoutedEventArgs e)
    {
        var downloadOpt = new DownloadConfiguration()
        {
            ClearPackageOnCompletionWithFailure = true,
            ReserveStorageSpaceBeforeStartingDownload = true
        };

        // 初始化下载库
        _downloader = new(downloadOpt);

        RadioButton_Kiddion.IsChecked = true;
    }

    private async void Window_OnlineLua_Closing(object sender, CancelEventArgs e)
    {
        await _downloader.CancelTaskAsync();
        _downloader.Dispose();
    }

    //////////////////////////////////////////////////////////

    private void ClearLogger()
    {
        TextBox_Logger.Clear();
    }

    private void AppendLogger(string log)
    {
        TextBox_Logger.AppendText($"{log}\n");
        TextBox_Logger.ScrollToEnd();
    }

    //////////////////////////////////////////////////////////

    private async void Button_RefushList_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        try
        {
            OnlineLuas.Clear();

            Button_StartDownload.IsEnabled = false;
            Button_CancelDownload.IsEnabled = false;

            LoadingSpinner_Refush.IsLoading = true;

            string content;
            if (isUseKiddion)
                content = await HttpHelper.DownloadString(kiddion);
            else
                content = await HttpHelper.DownloadString(yimMenu);

            if (string.IsNullOrEmpty(content))
            {
                AppendLogger("无法获取服务器Lua列表，返回结果为空");
                NotifierHelper.Show(NotifierType.Warning, "无法获取服务器Lua列表，返回结果为空");
                return;
            }

            var result = JsonHelper.JsonDese<List<LuaInfo>>(content);
            if (result != null)
            {
                foreach (var item in result)
                {
                    OnlineLuas.Add(item);
                }
            }

            ListBox_DownloadNode.Items.Clear();
            for (int i = 0; i < OnlineLuas.First().Download.Count; i++)
            {
                ListBox_DownloadNode.Items.Add($"节点{i + 1}");
            }
            ListBox_DownloadNode.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            AppendLogger($"获取服务器Lua列表异常：{ex.Message}");
            NotifierHelper.Show(NotifierType.Error, $"获取服务器Lua列表异常\n{ex.Message}");
        }
        finally
        {
            Button_StartDownload.IsEnabled = true;
            Button_CancelDownload.IsEnabled = false;

            LoadingSpinner_Refush.IsLoading = false;
        }
    }

    private async void Button_StartDownload_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var index = ListBox_DownloadAddress.SelectedIndex;
        if (index == -1)
        {
            AppendLogger("请选择要下载的内容，操作取消");
            NotifierHelper.Show(NotifierType.Warning, "请选择要下载的内容，操作取消");
            return;
        }

        var index2 = ListBox_DownloadNode.SelectedIndex;
        if (index2 == -1)
        {
            AppendLogger("请选择下载节点，操作取消");
            NotifierHelper.Show(NotifierType.Warning, "请选择下载节点，操作取消");
            return;
        }

        ClearLogger();

        StackPanel_ToggleOption.IsEnabled = false;
        Button_StartDownload.IsEnabled = false;
        Button_CancelDownload.IsEnabled = true;

        ResetUIState();

        var adddress = OnlineLuas[index].Download[index2];

        AppendLogger($"Lua名称：{OnlineLuas[index].Name}");
        AppendLogger($"Lua大小: {OnlineLuas[index].Size}");

        _downloader.DownloadStarted -= DownloadStarted;
        _downloader.DownloadProgressChanged -= DownloadProgressChanged;
        _downloader.DownloadFileCompleted -= DownloadFileCompleted;

        _downloader.DownloadStarted += DownloadStarted;
        _downloader.DownloadProgressChanged += DownloadProgressChanged;
        _downloader.DownloadFileCompleted += DownloadFileCompleted;

        if (isUseKiddion)
            tempPath = Path.Combine(FileHelper.Dir_Kiddion_Scripts, "GTA5OnlineLua.zip");
        else
            tempPath = Path.Combine(FileHelper.Dir_AppData_YimMenu_Scripts, "GTA5OnlineLua.zip");

        AppendLogger("开始下载中...");
        await _downloader.DownloadFileTaskAsync(adddress, tempPath);
    }

    private async void Button_CancelDownload_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        StackPanel_ToggleOption.IsEnabled = false;
        Button_StartDownload.IsEnabled = false;
        Button_CancelDownload.IsEnabled = false;

        await _downloader.CancelTaskAsync();

        ResetUIState();
        AppendLogger("下载取消");

        StackPanel_ToggleOption.IsEnabled = true;
        Button_StartDownload.IsEnabled = true;
        Button_CancelDownload.IsEnabled = false;
    }

    //////////////////////////////////////////////////////////

    /// <summary>
    /// 重置UI显示
    /// </summary>
    private void ResetUIState()
    {
        ProgressBar_Download.Maximum = 1024;
        ProgressBar_Download.Value = 0;

        TaskbarItemInfo.ProgressValue = 0;

        TextBlock_Percentage.Text = "0KB / 0MB";
    }

    private void DownloadStarted(object sender, DownloadStartedEventArgs e)
    {
        this.Dispatcher.Invoke(() =>
        {
            ProgressBar_Download.Maximum = e.TotalBytesToReceive;
        });
    }

    private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        this.Dispatcher.Invoke(() =>
        {
            ProgressBar_Download.Value = e.ReceivedBytesSize;
            TaskbarItemInfo.ProgressValue = ProgressBar_Download.Value / ProgressBar_Download.Maximum;

            TextBlock_Percentage.Text = $"{CoreUtil.GetFileForamtSize(e.ReceivedBytesSize)} / {CoreUtil.GetFileForamtSize(e.TotalBytesToReceive)}";
        });
    }

    private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        this.Dispatcher.Invoke(async () =>
        {
            if (e.Error != null)
            {
                ResetUIState();

                StackPanel_ToggleOption.IsEnabled = true;
                Button_StartDownload.IsEnabled = true;
                Button_CancelDownload.IsEnabled = false;

                AppendLogger("下载失败");
                AppendLogger($"错误信息：{e.Error.Message}");
                return;
            }

            try
            {
                AppendLogger("下载成功");
                AppendLogger("开始解压Lua中...");

                using var archive = ZipFile.OpenRead(tempPath);

                if (isUseKiddion)
                    archive.ExtractToDirectory(FileHelper.Dir_Kiddion_Scripts, true);
                else
                    archive.ExtractToDirectory(FileHelper.Dir_AppData_YimMenu_Scripts, true);

                await Task.Delay(100);
                archive.Dispose();

                AppendLogger("解压成功");
                AppendLogger("开始删除临时文件中...");

                await Task.Delay(100);
                File.Delete(tempPath);

                AppendLogger("删除临时文件成功");
                AppendLogger("操作结束");
            }
            catch (Exception ex)
            {
                AppendLogger("解压时发生异常");
                AppendLogger($"异常信息：{ex.Message}");
            }
            finally
            {
                StackPanel_ToggleOption.IsEnabled = true;
                Button_StartDownload.IsEnabled = true;
                Button_CancelDownload.IsEnabled = false;
            }
        });
    }

    private void RadioButton_ScriptMode_Checked(object sender, RoutedEventArgs e)
    {
        OnlineLuas.Clear();

        isUseKiddion = RadioButton_Kiddion.IsChecked == true;
    }

    private void Button_ScriptDir_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (isUseKiddion)
            ProcessHelper.OpenDir(FileHelper.Dir_Kiddion_Scripts);
        else
            ProcessHelper.OpenDir(FileHelper.Dir_AppData_YimMenu_Scripts);
    }

    private void Button_ClearScriptDir_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (isUseKiddion)
        {
            FileHelper.ClearDirectory(FileHelper.Dir_Kiddion_Scripts);
            FileHelper.ExtractResFile(FileHelper.Res_Kiddion_Scripts_Readme, FileHelper.File_Kiddion_Scripts_Readme);
            NotifierHelper.Show(NotifierType.Success, "清空Kiddion Lua脚本文件夹成功");
        }
        else
        {
            FileHelper.ClearDirectory(FileHelper.Dir_AppData_YimMenu_Scripts);
            NotifierHelper.Show(NotifierType.Success, "清空YimMenu Lua脚本文件夹成功");
        }
    }
}
