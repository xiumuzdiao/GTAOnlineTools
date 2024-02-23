using GTA5Menu.Data;

using GTA5Core.GTA.Teleports;
using GTA5Core.Features;
using GTA5Shared.Helper;
using GTA5Core.GTA.Vehicles;

namespace GTA5Menu.Views.OnlineTeleport;

/// <summary>
/// DefaultTeleportView.xaml 的交互逻辑
/// </summary>
public partial class DefaultTeleportView : UserControl
{
    public DefaultTeleportView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;

        // 传送分类列表
        foreach (var tClass in TeleportData.TeleportClasses)
        {
            ListBox_TeleportClasses.Items.Add(new IconMenu()
            {
                Icon = tClass.Icon,
                Title = tClass.Name
            });
        }
        ListBox_TeleportClasses.SelectedIndex = 0;
    }

    /// <summary>
    /// 主窗口关闭事件
    /// </summary>
    private void GTA5MenuWindow_WindowClosingEvent()
    {
        GTA5MenuWindow.WindowClosingEvent -= GTA5MenuWindow_WindowClosingEvent;
    }

    /////////////////////////////////////////////////////

    /// <summary>
    /// 传送分类选中变更事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ListBox_TeleportClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = ListBox_TeleportClasses.SelectedIndex;
        if (index == -1)
            return;

        ListBox_TeleportInfos.Items.Clear();

        foreach (var item in TeleportData.TeleportClasses[index].TeleportInfos)
        {
            var currentIndex = index;

            this.Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
            {
                if (currentIndex != ListBox_TeleportClasses.SelectedIndex)
                    return;

                ListBox_TeleportInfos.Items.Add(new TeleportInfo()
                {
                    Name = item.Name,
                    X = item.X,
                    Y = item.Y,
                    Z = item.Z
                });
            });
        }
    }

    /// <summary>
    /// 传送项鼠标双击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ListBox_TeleportInfos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_Teleport_Click(null, null);
    }

    private void Button_Teleport_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_TeleportInfos.SelectedItem is TeleportInfo info)
        {
            Teleport.SetTeleportPosition(new()
            {
                X = info.X,
                Y = info.Y,
                Z = info.Z
            });
        }
    }
}
