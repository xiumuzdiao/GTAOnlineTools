using GTA5HotKey;
using GTA5Overlay;
using GTA5Core.Native;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// ExternalOverlayView.xaml 的交互逻辑
/// </summary>
public partial class ExternalOverlayView : UserControl
{
    private Overlay overlay;

    public ExternalOverlayView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        CloseESP();
        // 重置ESP按键
        Setting.Reset();

        GTA5MenuWindow.WindowClosingEvent -= GTA5MenuWindow_WindowClosingEvent;
    }

    /////////////////////////////////////////////////

    private void Button_Overaly_Run_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (overlay == null)
        {
            GameOverlay.TimerService.EnableHighPrecisionTimers();

            Task.Run(() =>
            {
                overlay = new Overlay();
                overlay.Run();
            });
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "ESP程序已经运行了，请勿重复启动");
        }
    }

    private void Button_Overaly_Exit_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        CloseESP();
    }

    private void CloseESP()
    {
        if (overlay != null)
        {
            overlay.Dispose();
            overlay = null;
        }
    }

    ///////////////////////////////////////////////////////////////////

    private void CheckBox_ESP_Player_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Player = CheckBox_ESP_Player.IsChecked == true;
    }

    private void RadioButton_ESP_Player_2D_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Player_2D = RadioButton_ESP_Player_2D.IsChecked == true;
        Setting.ESP_Player_3D = RadioButton_ESP_Player_3D.IsChecked == true;
    }

    private void RadioButton_ESP_Player_3D_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Player_2D = RadioButton_ESP_Player_2D.IsChecked == true;
        Setting.ESP_Player_3D = RadioButton_ESP_Player_3D.IsChecked == true;
    }

    private void CheckBox_ESP_Player_Box_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Player_Box = CheckBox_ESP_Player_Box.IsChecked == true;
    }

    private void CheckBox_ESP_Player_Line_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Player_Line = CheckBox_ESP_Player_Line.IsChecked == true;
    }

    private void CheckBox_ESP_Player_Bone_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Player_Bone = CheckBox_ESP_Player_Bone.IsChecked == true;
    }

    private void CheckBox_ESP_Player_HealthBar_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Player_HealthBar = CheckBox_ESP_Player_HealthBar.IsChecked == true;
    }

    private void CheckBox_ESP_Player_HealthText_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Player_HealthText = CheckBox_ESP_Player_HealthText.IsChecked == true;
    }

    private void CheckBox_ESP_Player_NameText_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Player_NameText = CheckBox_ESP_Player_NameText.IsChecked == true;
    }

    private void CheckBox_AimBot_Player_Enabled_Click(object sender, RoutedEventArgs e)
    {
        Setting.AimBot_Player_Enabled = CheckBox_AimBot_Player_Enabled.IsChecked == true;
    }

    ///////////////////////////////////////////////////////////////////

    private void CheckBox_ESP_NPC_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_NPC = CheckBox_ESP_NPC.IsChecked == true;
    }

    private void RadioButton_ESP_NPC_2D_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_NPC_2D = RadioButton_ESP_NPC_2D.IsChecked == true;
        Setting.ESP_NPC_3D = RadioButton_ESP_NPC_3D.IsChecked == true;
    }

    private void RadioButton_ESP_NPC_3D_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_NPC_2D = RadioButton_ESP_NPC_2D.IsChecked == true;
        Setting.ESP_NPC_3D = RadioButton_ESP_NPC_3D.IsChecked == true;
    }

    private void CheckBox_ESP_NPC_Box_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_NPC_Box = CheckBox_ESP_NPC_Box.IsChecked == true;
    }

    private void CheckBox_ESP_NPC_Line_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_NPC_Line = CheckBox_ESP_NPC_Line.IsChecked == true;
    }

    private void CheckBox_ESP_NPC_Bone_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_NPC_Bone = CheckBox_ESP_NPC_Bone.IsChecked == true;
    }

    private void CheckBox_ESP_NPC_HealthBar_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_NPC_HealthBar = CheckBox_ESP_NPC_HealthBar.IsChecked == true;
    }

    private void CheckBox_ESP_NPC_HealthText_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_NPC_HealthText = CheckBox_ESP_NPC_HealthText.IsChecked == true;
    }

    private void CheckBox_ESP_NPC_NameText_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_NPC_NameText = CheckBox_ESP_NPC_NameText.IsChecked == true;
    }

    private void CheckBox_AimBot_NPC_Enabled_Click(object sender, RoutedEventArgs e)
    {
        Setting.AimBot_NPC_Enabled = CheckBox_AimBot_NPC_Enabled.IsChecked == true;
    }

    ///////////////////////////////////////////////////////////////////

    private void CheckBox_ESP_Pickup_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Pickup = CheckBox_ESP_Pickup.IsChecked == true;
    }

    private void RadioButton_ESP_Pickup_2D_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Pickup_2D = RadioButton_ESP_Pickup_2D.IsChecked == true;
        Setting.ESP_Pickup_3D = RadioButton_ESP_Pickup_3D.IsChecked == true;
    }

    private void RadioButton_ESP_Pickup_3D_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Pickup_2D = RadioButton_ESP_Pickup_2D.IsChecked == true;
        Setting.ESP_Pickup_3D = RadioButton_ESP_Pickup_3D.IsChecked == true;
    }

    private void CheckBox_ESP_Pickup_Box_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Pickup_Box = CheckBox_ESP_Pickup_Box.IsChecked == true;
    }

    private void CheckBox_ESP_Pickup_Line_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Pickup_Line = CheckBox_ESP_Pickup_Line.IsChecked == true;
    }

    ///////////////////////////////////////////////////////////////////

    private void CheckBox_ESP_Crosshair_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Crosshair = CheckBox_ESP_Crosshair.IsChecked == true;
    }

    private void CheckBox_ESP_InfoText_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_InfoText = CheckBox_ESP_InfoText.IsChecked == true;
    }

    private void CheckBox_NoTopMostHide_Click(object sender, RoutedEventArgs e)
    {
        Setting.NoTopMostHide = CheckBox_NoTopMostHide.IsChecked == true;
    }

    ///////////////////////////////////////////////////////////////////

    private void RadioButton_Overlay_RunMode0_Click(object sender, RoutedEventArgs e)
    {
        if (RadioButton_Overlay_RunMode0.IsChecked == true)
        {
            Setting.VSync = true;
            Setting.FPS = 300;

            CloseESP();
        }
        else if (RadioButton_Overlay_RunMode1.IsChecked == true)
        {
            Setting.VSync = false;
            Setting.FPS = 300;

            CloseESP();
        }
        else if (RadioButton_Overlay_RunMode2.IsChecked == true)
        {
            Setting.VSync = false;
            Setting.FPS = 144;

            CloseESP();
        }
        else if (RadioButton_Overlay_RunMode3.IsChecked == true)
        {
            Setting.VSync = false;
            Setting.FPS = 90;

            CloseESP();
        }
        else if (RadioButton_Overlay_RunMode4.IsChecked == true)
        {
            Setting.VSync = false;
            Setting.FPS = 60;

            CloseESP();
        }
    }

    private void RadioButton_AimbotKey_Click(object sender, RoutedEventArgs e)
    {
        if (RadioButton_AimbotKey_Control.IsChecked == true)
        {
            Setting.AimBot_Key = Keys.Control;
        }
        else if (RadioButton_AimbotKey_ShiftKey.IsChecked == true)
        {
            Setting.AimBot_Key = Keys.ShiftKey;
        }
        else if (RadioButton_AimbotKey_LButton.IsChecked == true)
        {
            Setting.AimBot_Key = Keys.LButton;
        }
        else if (RadioButton_AimbotKey_RButton.IsChecked == true)
        {
            Setting.AimBot_Key = Keys.RButton;
        }
        else if (RadioButton_AimbotKey_XButton1.IsChecked == true)
        {
            Setting.AimBot_Key = Keys.XButton1;
        }
        else if (RadioButton_AimbotKey_XButton2.IsChecked == true)
        {
            Setting.AimBot_Key = Keys.XButton2;
        }
    }

    private void RadioButton_AimBot_BoneIndex_Click(object sender, RoutedEventArgs e)
    {
        if (RadioButton_AimBot_BoneIndex_0.IsChecked == true)
        {
            Setting.AimBot_BoneIndex = 0;
        }
        else if (RadioButton_AimBot_BoneIndex_7.IsChecked == true)
        {
            Setting.AimBot_BoneIndex = 7;
        }
        else if (RadioButton_AimBot_BoneIndex_8.IsChecked == true)
        {
            Setting.AimBot_BoneIndex = 8;
        }
    }

    private void RadioButton_AimbotFov_Height_Click(object sender, RoutedEventArgs e)
    {
        var windowData = Memory.GetGameWindowData();

        if (RadioButton_Crosshair_NearBy.IsChecked == true)
        {
            Setting.AimBot_Fov = 250.0f;
        }
        else if (RadioButton_AimbotFov_14Height.IsChecked == true)
        {
            Setting.AimBot_Fov = windowData.Height / 4.0f;
        }
        else if (RadioButton_AimbotFov_12Height.IsChecked == true)
        {
            Setting.AimBot_Fov = windowData.Height / 2.0f;
        }
        else if (RadioButton_AimbotFov_Height.IsChecked == true)
        {
            Setting.AimBot_Fov = windowData.Height;
        }
        else if (RadioButton_AimbotFov_Width.IsChecked == true)
        {
            Setting.AimBot_Fov = windowData.Width;
        }
        else if (RadioButton_AimbotFov_All.IsChecked == true)
        {
            Setting.AimBot_Fov = 8848.0f;
        }
    }
}