using GTA5Core.Features;
using GTA5Core.GTA.Peds;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// OtherMiscView.xaml 的交互逻辑
/// </summary>
public partial class OtherMiscView : UserControl
{
    public OtherMiscView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;

        // Ped列表
        foreach (var item in PedHash.PedHashData)
        {
            ListBox_PedModel.Items.Add(item.Name);
        }
        ListBox_PedModel.SelectedIndex = 0;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        GTA5MenuWindow.WindowClosingEvent -= GTA5MenuWindow_WindowClosingEvent;
    }

    /////////////////////////////////////////////////

    private void Button_ModelChange_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var index = ListBox_PedModel.SelectedIndex;
        if (index != -1)
            Online.ModelChange(STATS.JOATT(PedHash.PedHashData[index].Value));
    }

    private void ListBox_PedModel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_ModelChange_Click(null, null);
    }
}
