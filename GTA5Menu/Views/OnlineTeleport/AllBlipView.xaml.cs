using GTA5Menu.Data;

using GTA5Core.GTA;
using GTA5Core.GTA.Blips;
using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.OnlineTeleport;

/// <summary>
/// AllBlipView.xaml 的交互逻辑
/// </summary>
public partial class AllBlipView : UserControl
{
    public AllBlipView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;

        foreach (var model in BlipData.BlipModels)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
            {
                ListBox_BlipInfos.Items.Add(new BlipInfo()
                {
                    Value = model,
                    Image = GTAHelper.GetBlipImage(model)
                });
            });
        }
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        GTA5MenuWindow.WindowClosingEvent -= GTA5MenuWindow_WindowClosingEvent;
    }

    /////////////////////////////////////////////////

    private void ListBox_BlipInfos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_TeleportToBlip_Click(null, null);
    }

    private void Button_TeleportToBlip_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_BlipInfos.SelectedItem is BlipInfo info)
        {
            Teleport.ToBlips(info.Value);
        }
    }

    private void Button_AddMyFavorite_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_BlipInfos.SelectedItem is BlipInfo info)
        {
            MyBlipView.ActionAddMyFavorite(info);
        }
    }
}
