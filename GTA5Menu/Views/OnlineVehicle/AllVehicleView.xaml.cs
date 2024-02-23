using GTA5Menu.Data;

using GTA5Core.GTA.Vehicles;
using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.OnlineVehicle;

/// <summary>
/// AllVehicleView.xaml 的交互逻辑
/// </summary>
public partial class AllVehicleView : UserControl
{
    public AllVehicleView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;

        // 载具分类列表
        foreach (var vClass in VehicleHash.VehicleClasses)
        {
            ListBox_VehicleClasses.Items.Add(new IconMenu()
            {
                Icon = vClass.Icon,
                Title = vClass.Name
            });
        }
        ListBox_VehicleClasses.SelectedIndex = 0;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        GTA5MenuWindow.WindowClosingEvent -= GTA5MenuWindow_WindowClosingEvent;
    }

    /////////////////////////////////////////////////

    private void ListBox_VehicleTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = ListBox_VehicleClasses.SelectedIndex;
        if (index == -1)
            return;

        ListBox_VehicleInfos.Items.Clear();

        foreach (var item in VehicleHash.VehicleClasses[index].VehicleInfos)
        {
            var currentIndex = index;

            this.Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
            {
                if (currentIndex != ListBox_VehicleClasses.SelectedIndex)
                    return;

                ListBox_VehicleInfos.Items.Add(new ModelInfo()
                {
                    Class = item.Class,
                    Name = item.Name,
                    Value = item.Value,
                    Image = item.Image,
                    Mods = item.Mods
                });
            });
        }
    }

    private void ListBox_VehicleInfos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_SpawnVehicle_Click(null, null);
    }

    private async void Button_SpawnVehicle_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_VehicleInfos.SelectedItem is ModelInfo info)
        {
            var isMax = CheckBox_SpawnMax.IsChecked == true;

            if (RadioButton_SpawnMode1.IsChecked == true)
                await Vehicle2.SpawnVehicle(info.Value, info.Mods, isMax);
            else
                await Vehicle2.SpawnVehicle(info.Value, info.Mods, isMax, true);
        }
    }

    private void Button_AddMyFavorite_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_VehicleInfos.SelectedItem is ModelInfo info)
        {
            MyVehicleView.ActionAddMyFavorite(info);
        }
    }
}
