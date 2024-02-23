using GTA5OnlineTools.Utils;
using GTA5OnlineTools.Models;

using GTA5Shared.Helper;

using CommunityToolkit.Mvvm.Input;

namespace GTA5OnlineTools;

/// <summary>
/// LoadWindow.xaml 的交互逻辑
/// </summary>
public partial class LoadWindow
{
    /// <summary>
    /// 数据模型绑定
    /// </summary>
    public LoadModel LoadModel { get; set; } = new();

    public LoadWindow()
    {
        InitializeComponent();
    }

    private void Window_Load_Loaded(object sender, RoutedEventArgs e)
    {
        Task.Run(() =>
        {
            try
            {
                // 关闭第三方进程
                ProcessHelper.CloseThirdProcess();

                LoadModel.LoadState = "正在初始化工具...";
                LoadModel.IsShowLoading = true;

                LoggerHelper.Info("开始初始化程序...");
                LoggerHelper.Info($"当前程序版本号 {CoreUtil.ClientVersion}");
                LoggerHelper.Info($"当前程序最后编译时间 {CoreUtil.BuildDate}");

                // 客户端程序版本号
                LoadModel.VersionInfo = CoreUtil.ClientVersion;
                // 最后编译时间
                LoadModel.BuildDate = CoreUtil.BuildDate;

                /////////////////////////////////////////////////////////////////////

                LoadModel.LoadState = "正在初始化配置文件...";
                LoggerHelper.Info("正在初始化配置文件...");

                // 创建指定文件夹，用于释放必要文件和更新软件（如果已存在则不会创建）
                FileHelper.CreateDirectory(FileHelper.Dir_Cache);
                FileHelper.CreateDirectory(FileHelper.Dir_YimMenu);
                FileHelper.CreateDirectory(FileHelper.Dir_Config);
                FileHelper.CreateDirectory(FileHelper.Dir_Kiddion);
                FileHelper.CreateDirectory(FileHelper.Dir_Logger);

                FileHelper.CreateDirectory(FileHelper.Dir_Kiddion_Scripts);

                FileHelper.CreateDirectory(FileHelper.Dir_Log_NLog);
                FileHelper.CreateDirectory(FileHelper.Dir_Log_Crash);

                // 清空缓存文件夹
                FileHelper.ClearDirectory(FileHelper.Dir_Cache);

                // 释放必要文件
                FileHelper.ExtractResFile(FileHelper.Res_Kiddion_Kiddion, FileHelper.File_Kiddion_Kiddion);
                FileHelper.ExtractResFile(FileHelper.Res_Kiddion_KiddionChs, FileHelper.File_Kiddion_KiddionChs);

                // 释放前先判断，防止覆盖配置文件（当文件不存在时释放文件）
                if (!File.Exists(FileHelper.File_Kiddion_Config))
                    FileHelper.ExtractResFile(FileHelper.Res_Kiddion_Config, FileHelper.File_Kiddion_Config);
                if (!File.Exists(FileHelper.File_Kiddion_Themes))
                    FileHelper.ExtractResFile(FileHelper.Res_Kiddion_Themes, FileHelper.File_Kiddion_Themes);
                if (!File.Exists(FileHelper.File_Kiddion_Teleports))
                    FileHelper.ExtractResFile(FileHelper.Res_Kiddion_Teleports, FileHelper.File_Kiddion_Teleports);
                if (!File.Exists(FileHelper.File_Kiddion_Vehicles))
                    FileHelper.ExtractResFile(FileHelper.Res_Kiddion_Vehicles, FileHelper.File_Kiddion_Vehicles);

                // Kiddion Lua脚本
                FileHelper.ExtractResFile(FileHelper.Res_Kiddion_Scripts_Readme, FileHelper.File_Kiddion_Scripts_Readme);

                /////////////////////////////////////////////////////////////////////

                FileHelper.ExtractResFile(FileHelper.Res_Cache_GTAHax, FileHelper.File_Cache_GTAHax);
                FileHelper.ExtractResFile(FileHelper.Res_Cache_BincoHax, FileHelper.File_Cache_BincoHax);
                FileHelper.ExtractResFile(FileHelper.Res_Cache_LSCHax, FileHelper.File_Cache_LSCHax);
                FileHelper.ExtractResFile(FileHelper.Res_Cache_Stat, FileHelper.File_Cache_Stat);

                FileHelper.ExtractResFile(FileHelper.Res_Cache_Notepad2, FileHelper.File_Cache_Notepad2);

                // 判断YimMenu.dll文件是否存在 是否被占用
                if (!File.Exists(FileHelper.File_YimMenu_DLL) ||
                    !FileHelper.IsOccupied(FileHelper.File_YimMenu_DLL))
                {
                    FileHelper.ExtractResFile(FileHelper.Res_YimMenu_YimMenu, FileHelper.File_YimMenu_DLL);
                    LoggerHelper.Info("释放YimMenu.dll文件成功");
                }
                else
                {
                    LoggerHelper.Warn("YimMenu.dll文件正在被占用，跳过释放");
                }

                // 初始化简繁字库
                ChsHelper.PreHeat();
                LoggerHelper.Info("简繁翻译库初始化成功");

                /////////////////////////////////////////////////////////////////////

                this.Dispatcher.Invoke(() =>
                {
                    var mainWindow = new MainWindow();
                    // 转移主程序控制权
                    Application.Current.MainWindow = mainWindow;
                    // 显示主窗口
                    mainWindow.Show();
                    // 关闭初始化窗口
                    this.Close();
                });
            }
            catch (Exception ex)
            {
                LoadModel.LoadState = $"初始化错误，发生了未知异常！\n{ex.Message}";
                LoadModel.IsShowLoading = false;
                LoadModel.IsInitError = true;
                LoggerHelper.Error("初始化错误，发生了未知异常", ex);
            }
        });
    }

    [RelayCommand]
    private void ButtonClick(string name)
    {
        switch (name)
        {
            case "OpenDefaultPath":
                ProcessHelper.OpenProcess(FileHelper.Dir_Base);
                break;
            case "ExitAPP":
                Application.Current.Shutdown();
                break;
        }
    }
}
