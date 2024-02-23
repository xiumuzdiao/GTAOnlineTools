using GTA5OnlineTools.Utils;

using GTA5Shared.Helper;

using Downloader;

namespace GTA5OnlineTools.Windows;

/// <summary>
/// UpdateWindow.xaml 的交互逻辑
/// </summary>
public partial class UpdateWindow
{
    private DownloadService _downloader;

    public UpdateWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 更新窗口加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Update_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            var downloadOpt = new DownloadConfiguration()
            {
                ClearPackageOnCompletionWithFailure = true,
                ReserveStorageSpaceBeforeStartingDownload = true
            };

            // 初始化下载库
            _downloader = new(downloadOpt);

            // 删除未下载完的文件
            var tempPath = CoreUtil.GetHalfwayFilePath();
            if (File.Exists(tempPath))
                File.Delete(tempPath);

            // 防止未获取到更新信息情况
            if (CoreUtil.UpdateInfo == null)
            {
                Button_StartDownload.IsEnabled = false;
                Button_CancelDownload.IsEnabled = false;
                return;
            }

            // 显示最新的更新日期和时间
            TextBlock_LatestUpdateInfo.Text = $"{CoreUtil.UpdateInfo.Latest.Date}\n{CoreUtil.UpdateInfo.Latest.Change}";
            // 加载更新日志
            foreach (var item in CoreUtil.UpdateInfo.Download)
            {
                ListBox_DownloadAddress.Items.Add(item.Name);
            }
            // 选中第一项
            if (ListBox_DownloadAddress.Items.Count > 0)
                ListBox_DownloadAddress.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }

    /// <summary>
    /// 更新窗口关闭事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Window_Update_Closing(object sender, CancelEventArgs e)
    {
        await _downloader.CancelTaskAsync();
        _downloader.Dispose();
    }

    /// <summary>
    /// 超链接请求导航事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        ProcessHelper.OpenLink(e.Uri.OriginalString);
        e.Handled = true;
    }

    //////////////////////////////////////////////////////////

    /// <summary>
    /// 开始更新按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Button_StartDownload_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var index = ListBox_DownloadAddress.SelectedIndex;
        if (index == -1)
        {
            NotifierHelper.Show(NotifierType.Warning, "请选择要下载的内容，操作取消");
            return;
        }

        Button_StartDownload.IsEnabled = false;
        Button_CancelDownload.IsEnabled = true;

        ResetUIState("下载开始");

        CoreUtil.UpdateAddress = CoreUtil.UpdateInfo.Download[index].Url;

        // 获取未下载完临时文件路径
        var tempPath = CoreUtil.GetHalfwayFilePath(); ;

        _downloader.DownloadStarted -= DownloadStarted;
        _downloader.DownloadProgressChanged -= DownloadProgressChanged;
        _downloader.DownloadFileCompleted -= DownloadFileCompleted;

        _downloader.DownloadStarted += DownloadStarted;
        _downloader.DownloadProgressChanged += DownloadProgressChanged;
        _downloader.DownloadFileCompleted += DownloadFileCompleted;

        await _downloader.DownloadFileTaskAsync(CoreUtil.UpdateAddress, tempPath);
    }

    /// <summary>
    /// 取消更新按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Button_CancelDownload_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Button_StartDownload.IsEnabled = false;
        Button_CancelDownload.IsEnabled = false;

        await _downloader.CancelTaskAsync();

        ResetUIState("下载取消");

        Button_StartDownload.IsEnabled = true;
        Button_CancelDownload.IsEnabled = false;
    }

    //////////////////////////////////////////////////////////

    private void ResetUIState(string reson)
    {
        ProgressBar_Download.Maximum = 1024;
        ProgressBar_Download.Value = 0;

        TaskbarItemInfo.ProgressValue = 0;

        TextBlock_DonloadInfo.Text = reson;
        TextBlock_Percentage.Text = "0KB / 0MB";
    }

    /// <summary>
    /// 下载开始事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void DownloadStarted(object sender, DownloadStartedEventArgs e)
    {
        this.Dispatcher.Invoke(() =>
        {
            ProgressBar_Download.Maximum = e.TotalBytesToReceive;

            TextBlock_DonloadInfo.Text = $"下载开始 文件大小 {CoreUtil.GetFileForamtSize(e.TotalBytesToReceive)}";
        });
    }

    /// <summary>
    /// 下载进度变更事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        this.Dispatcher.Invoke(() =>
        {
            ProgressBar_Download.Value = e.ReceivedBytesSize;
            TaskbarItemInfo.ProgressValue = ProgressBar_Download.Value / ProgressBar_Download.Maximum;

            TextBlock_Percentage.Text = $"{CoreUtil.GetFileForamtSize(e.ReceivedBytesSize)} / {CoreUtil.GetFileForamtSize(e.TotalBytesToReceive)}";
        });
    }

    /// <summary>
    /// 下载文件完成事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        this.Dispatcher.Invoke(async () =>
        {
            if (e.Error != null)
            {
                ResetUIState($"下载失败 {e.Error.Message}");

                Button_StartDownload.IsEnabled = true;
                Button_CancelDownload.IsEnabled = false;
                return;
            }

            try
            {
                Button_StartDownload.IsEnabled = false;
                Button_CancelDownload.IsEnabled = false;

                // 下载临时文件完整路径
                var oldPath = CoreUtil.GetHalfwayFilePath();
                // 下载完成后文件真正路径
                var newPath = CoreUtil.GetFullFilePath();

                // 下载完成后新文件重命名
                FileUtil.FileReName(oldPath, newPath);

                await Task.Delay(100);

                // 下载完成后旧文件重命名
                var oldFileName = $"[旧版本小助手请手动删除] {Guid.NewGuid()}.exe";
                // 旧版本小助手重命名
                FileUtil.FileReName(FileUtil.File_MainApp, FileUtil.GetCurrFullPath(oldFileName));

                TextBlock_DonloadInfo.Text = "更新下载完成，程序将在3秒内重新启动";

                App.AppMainMutex.Dispose();
                await Task.Delay(1000);
                ProcessHelper.OpenProcess(newPath);
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                NotifierHelper.ShowException(ex);
            }
        });
    }
}
