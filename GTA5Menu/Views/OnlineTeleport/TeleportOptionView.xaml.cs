using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.OnlineTeleport;

/// <summary>
/// TeleportOptionView.xaml 的交互逻辑
/// </summary>
public partial class TeleportOptionView : UserControl
{
    public TeleportOptionView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        GTA5MenuWindow.WindowClosingEvent -= GTA5MenuWindow_WindowClosingEvent;
    }

    /////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// 传送到导航点
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_ToWaypoint_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Teleport.ToWaypoint();
    }

    /// <summary>
    /// 传送到目标点
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_ToObjective_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Teleport.ToObjective();
    }

    /////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// 坐标微调
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_MoveDistance_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var moveDistance = (float)Slider_MoveDistance.Value;

        if (sender is Button button)
        {
            switch (button.Content.ToString())
            {
                case "向前":
                    Teleport.MoveFoward(moveDistance);
                    break;
                case "向后":
                    Teleport.MoveBack(moveDistance);
                    break;
                case "向左":
                    Teleport.MoveLeft(moveDistance);
                    break;
                case "向右":
                    Teleport.MoveRight(moveDistance);
                    break;
                case "向上":
                    Teleport.MoveUp(moveDistance);
                    break;
                case "向下":
                    Teleport.MoveDown(moveDistance);
                    break;
            }
        }
    }
}
