using GTA5OnlineTools.Utils;

using GTA5Shared.Helper;

namespace GTA5OnlineTools.Views;

/// <summary>
/// OptionsView.xaml 的交互逻辑
/// </summary>
public partial class OptionsView : UserControl
{
    public OptionsView()
    {
        InitializeComponent();
        MainWindow.WindowClosingEvent += MainWindow_WindowClosingEvent;

        var clickAudio = IniHelper.ReadValue("Options", "ClickAudio");
        switch (clickAudio)
        {
            case "1":
                AudioHelper.ClickAudio = AudioHelper.Audio.Sound1;
                RadioButton_ClickAudio1.IsChecked = true;
                break;
            case "2":
                AudioHelper.ClickAudio = AudioHelper.Audio.Sound2;
                RadioButton_ClickAudio2.IsChecked = true;
                break;
            case "3":
                AudioHelper.ClickAudio = AudioHelper.Audio.Sound3;
                RadioButton_ClickAudio3.IsChecked = true;
                break;
            case "4":
                AudioHelper.ClickAudio = AudioHelper.Audio.Sound4;
                RadioButton_ClickAudio4.IsChecked = true;
                break;
            case "5":
                AudioHelper.ClickAudio = AudioHelper.Audio.Sound5;
                RadioButton_ClickAudio5.IsChecked = true;
                break;
            ////////////////////////
            case "0":
            default:
                AudioHelper.ClickAudio = AudioHelper.Audio.None;
                RadioButton_ClickAudio0.IsChecked = true;
                break;
        }

        TextBlock_Computer.Text = $"{Environment.UserName}";
        TextBlock_Runtime.Text = $"{RuntimeInformation.FrameworkDescription}";
        TextBlock_Admin.Text = $"{CoreUtil.GetAdminState()}";
        TextBlock_Version.Text = $"{CoreUtil.ClientVersion}";
        TextBlock_Build.Text = $"{CoreUtil.BuildDate}";
    }

    /// <summary>
    /// 主窗口关闭事件
    /// </summary>
    private void MainWindow_WindowClosingEvent()
    {
        SaveConfig();
    }

    /// <summary>
    /// 保存配置文件
    /// </summary>
    private void SaveConfig()
    {
        IniHelper.WriteValue("Options", "ClickAudio", $"{(int)AudioHelper.ClickAudio}");
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

    private void RadioButton_ClickAudio_Click(object sender, RoutedEventArgs e)
    {
        if (RadioButton_ClickAudio0.IsChecked == true)
            AudioHelper.ClickAudio = AudioHelper.Audio.None;
        else if (RadioButton_ClickAudio1.IsChecked == true)
            AudioHelper.ClickAudio = AudioHelper.Audio.Sound1;
        else if (RadioButton_ClickAudio2.IsChecked == true)
            AudioHelper.ClickAudio = AudioHelper.Audio.Sound2;
        else if (RadioButton_ClickAudio3.IsChecked == true)
            AudioHelper.ClickAudio = AudioHelper.Audio.Sound3;
        else if (RadioButton_ClickAudio4.IsChecked == true)
            AudioHelper.ClickAudio = AudioHelper.Audio.Sound4;
        else if (RadioButton_ClickAudio5.IsChecked == true)
            AudioHelper.ClickAudio = AudioHelper.Audio.Sound5;

        AudioHelper.PlayClickSound();
    }
}
