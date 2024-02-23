using GTA5OnlineTools.Data;
using GTA5OnlineTools.Windows;

using GTA5Core;
using GTA5Core.Native;
using GTA5Menu;
using GTA5MenuExtra;
using GTA5Shared.Helper;

using CommunityToolkit.Mvvm.Input;

namespace GTA5OnlineTools.Views;

/// <summary>
/// GTA5View.xaml 的交互逻辑
/// </summary>
public partial class GTA5View : UserControl
{
    /// <summary>
    /// 导航字典
    /// </summary>
    private readonly Dictionary<string, NavWindow> NavDictionary = new();

    /// <summary>
    /// 关闭全部GTA5窗口委托
    /// </summary>
    public static Action ActionCloseAllGTA5Window;

    /////////////////////////////////////////////////

    public GTA5View()
    {
        InitializeComponent();
        MainWindow.WindowClosingEvent += MainWindow_WindowClosingEvent;

        ActionCloseAllGTA5Window = CloseAllGTA5Window;

        /////////////////////////////////////////////////

        NavDictionary.Add("GTA5MenuWindow", new()
        {
            Type = typeof(GTA5MenuWindow),
            Window = null
        });

        NavDictionary.Add("HeistsEditorWindow", new()
        {
            Type = typeof(HeistsEditorWindow),
            Window = null
        });
        NavDictionary.Add("StatsEditorWindow", new()
        {
            Type = typeof(StatsEditorWindow),
            Window = null
        });
        NavDictionary.Add("OutfitsEditorWindow", new()
        {
            Type = typeof(OutfitsEditorWindow),
            Window = null
        });
        NavDictionary.Add("CasinoHackWindow", new()
        {
            Type = typeof(CasinoHackWindow),
            Window = null
        });
        NavDictionary.Add("SpeedMeterWindow", new()
        {
            Type = typeof(SpeedMeterWindow),
            Window = null
        });

        /////////////////////////////////////////////////

        NavDictionary.Add("KiddionWindow", new()
        {
            Type = typeof(KiddionWindow),
            Window = null
        });
        NavDictionary.Add("StartupWindow", new()
        {
            Type = typeof(StartupWindow),
            Window = null
        });
        NavDictionary.Add("ProfilesWindow", new()
        {
            Type = typeof(ProfilesWindow),
            Window = null
        });
    }

    private void MainWindow_WindowClosingEvent()
    {

    }

    [RelayCommand]
    private void GTA5ViewClick(string viewName)
    {
        AudioHelper.PlayClickSound();

        if (ProcessHelper.IsGTA5Run())
        {
            // GTA5内存模块初始化窗口
            if (!Memory.IsInitialized)
            {
                var gta5InitWindow = new GTA5InitWindow
                {
                    Owner = MainWindow.MainWindowInstance
                };
                if (gta5InitWindow.ShowDialog() == false)
                    return;
            }

            switch (viewName)
            {
                case "ExternalMenu":
                    ExternalMenuClick();
                    break;
                case "HeistsEditor":
                    HeistsEditorClick();
                    break;
                case "StatsEditor":
                    StatsEditorClick();
                    break;
                case "OutfitsEditor":
                    OutfitsEditorClick();
                    break;
                case "CasinoHack":
                    CasinoHackClick();
                    break;
                case "SpeedMeter":
                    SpeedMeterClick();
                    break;
            }
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "未发现《GTA5》进程，请先运行《GTA5》游戏");
        }
    }

    [RelayCommand]
    private void GTA5FuncClick(string funcName)
    {
        AudioHelper.PlayClickSound();

        switch (funcName)
        {
            case "KiddionChs":
                KiddionChsClick();
                break;
            case "StartupMeta":
                StartupMetaClick();
                break;
            case "StoryProfiles":
                StoryProfilesWindowClick();
                break;
        }
    }

    ///////////////////////////////////////////////////////////////////

    /// <summary>
    /// 自动处理窗口显示、隐藏和创建
    /// </summary>
    /// <param name="windowName"></param>
    private void AutoOpenWindow(string windowName)
    {
        if (!NavDictionary.ContainsKey(windowName))
            return;

        // 首次创建
        if (NavDictionary[windowName].Window == null)
            goto RE_CREATE;

        // 窗口隐藏
        if (NavDictionary[windowName].Window.Visibility == Visibility.Hidden)
        {
            NavDictionary[windowName].Window.Show();
            return;
        }

        // 窗口最小化
        if (NavDictionary[windowName].Window.WindowState == WindowState.Minimized)
        {
            NavDictionary[windowName].Window.WindowState = WindowState.Normal;
            return;
        }

        // 窗口不在最前面（为false代表窗口已被关闭）
        if (NavDictionary[windowName].Window.IsVisible)
        {
            NavDictionary[windowName].Window.Topmost = true;
            NavDictionary[windowName].Window.Topmost = false;
            return;
        }

        // 窗口已被关闭，重新创建
        NavDictionary[windowName].Window.Close();
        NavDictionary[windowName].Window = null;

    RE_CREATE:
        NavDictionary[windowName].Window = Activator.CreateInstance(NavDictionary[windowName].Type) as Window;
        NavDictionary[windowName].Window.Show();
    }

    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="windowName"></param>
    private void AutoCloseWindow(string windowName)
    {
        if (NavDictionary[windowName].Window != null)
        {
            NavDictionary[windowName].Window.Close();
            NavDictionary[windowName].Window = null;
        }
    }

    #region 第三方模块按钮点击事件
    private void ExternalMenuClick()
    {
        AutoOpenWindow("GTA5MenuWindow");
    }

    private void HeistsEditorClick()
    {
        AutoOpenWindow("HeistsEditorWindow");
    }

    private void StatsEditorClick()
    {
        AutoOpenWindow("StatsEditorWindow");
    }

    private void OutfitsEditorClick()
    {
        AutoOpenWindow("OutfitsEditorWindow");
    }

    private void CasinoHackClick()
    {
        AutoOpenWindow("CasinoHackWindow");
    }

    private void SpeedMeterClick()
    {
        AutoOpenWindow("SpeedMeterWindow");
    }
    #endregion

    ///////////////////////////////////////////////////////////////////

    /// <summary>
    /// 关闭全部GTA5窗口
    /// </summary>
    private void CloseAllGTA5Window()
    {
        Memory.CloseHandle();

        this.Dispatcher.Invoke(() =>
        {
            AutoCloseWindow("GTA5MenuWindow");

            AutoCloseWindow("HeistsEditorWindow");
            AutoCloseWindow("StatsEditorWindow");
            AutoCloseWindow("OutfitsEditorWindow");
            AutoCloseWindow("CasinoHackWindow");
            AutoCloseWindow("SpeedMeterWindow");
        });
    }

    ///////////////////////////////////////////////////////////////////

    /// <summary>
    /// Kiddion汉化润色修正
    /// </summary>
    private void KiddionChsClick()
    {
        AutoOpenWindow("KiddionWindow");
    }

    /// <summary>
    /// 生成带密码战局文件
    /// </summary>
    private void StartupMetaClick()
    {
        AutoOpenWindow("StartupWindow");
    }

    /// <summary>
    /// 替换故事模式完美存档
    /// </summary>
    private void StoryProfilesWindowClick()
    {
        AutoOpenWindow("ProfilesWindow");
    }
}
