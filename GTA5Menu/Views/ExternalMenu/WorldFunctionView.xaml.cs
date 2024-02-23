using GTA5Core.Features;
using GTA5Core.GTA.Onlines;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// WorldFunctionView.xaml 的交互逻辑
/// </summary>
public partial class WorldFunctionView : UserControl
{
    private class Options
    {
        public float RPxN = 1.0f;
        public float APxN = 1.0f;
        public float REPxN = 1.0f;
    }
    private readonly Options _options = new();

    public WorldFunctionView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;
        GTA5MenuWindow.LoopSpeedNormalEvent += GTA5MenuWindow_LoopSpeedNormalEvent;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        GTA5MenuWindow.WindowClosingEvent -= GTA5MenuWindow_WindowClosingEvent;
        GTA5MenuWindow.LoopSpeedNormalEvent -= GTA5MenuWindow_LoopSpeedNormalEvent;
    }

    ///////////////////////////////////////////////

    private void GTA5MenuWindow_LoopSpeedNormalEvent()
    {
        // 角色RP
        if (_options.RPxN != 1.0f)
            Online.RPMultiplier(_options.RPxN);
        // 竞技场AP
        if (_options.APxN != 1.0f)
            Online.APMultiplier(_options.APxN);
        // 车友会RP
        if (_options.REPxN != 1.0f)
            Online.REPMultiplier(_options.REPxN);
    }

    /////////////////////////////////////////////////////////////

    private void Button_LocalWeather_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (sender is Button button)
        {
            var btnContent = button.Content.ToString();

            var weather = OnlineData.LocalWeathers.Find(t => t.Name == btnContent);
            if (weather != null)
                World.SetLocalWeather(weather.Value);
        }
    }

    private void Slider_RPxN_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _options.RPxN = (float)Slider_RPxN.Value;
        Online.RPMultiplier(_options.RPxN);
    }

    private void Slider_APxN_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _options.APxN = (float)Slider_APxN.Value;
        Online.APMultiplier(_options.APxN);
    }

    private void Slider_REPxN_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _options.REPxN = (float)Slider_REPxN.Value;
        Online.REPMultiplier(_options.REPxN);
    }

    /////////////////////////////////////////////////////////////

    private void Button_KillNPC_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.KillNPC();
    }

    private void Button_KillEnemyNPC_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.KillNPC(true);
    }

    private void Button_KillPolice_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.KillPolice();
    }

    private void Button_DestroyVehicles_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.DestroyVehicles();
    }

    private void Button_DestroyNPCVehicles_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.DestroyNPCVehicles();
    }

    private void Button_DestroyEnemyNPCVehicles_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.DestroyNPCVehicles(true);
    }

    private void Button_DestroyPoliceVehicles_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.DestroyPoliceVehicles();
    }

    private void Button_TeleportNPCToMe_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.TeleportNPCToMe();
    }

    private void Button_TeleportEnemyNPCToMe_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.TeleportNPCToMe(true);
    }

    private void Button_TeleporNPCTo9999_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.TeleporNPCTo9999();
    }

    private void Button_TeleporEnemyNPCTo9999_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.TeleporNPCTo9999(true);
    }

    private void Button_RemoveCCTV_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.RemoveCCTV();
    }
}
