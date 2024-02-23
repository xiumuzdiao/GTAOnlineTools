using GTA5Menu.Data;

using GTA5Core.GTA.Vehicles;
using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.OnlineVehicle;

/// <summary>
/// FindVehicleView.xaml 的交互逻辑
/// </summary>
public partial class FindVehicleView : UserControl
{
    public List<ModelInfo> AllVehicles { get; set; } = new();

    public ObservableCollection<ModelInfo> FindVehicles { get; set; } = new();

    public FindVehicleView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;

        // 填充全部载具
        Task.Run(() =>
        {
            foreach (var info in VehicleHash.AllVehicles)
            {
                AllVehicles.Add(new()
                {
                    Class = info.Class,
                    Name = info.Name,
                    Value = info.Value,
                    Image = info.Image,
                    Mods = info.Mods
                });
            }
        });
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        GTA5MenuWindow.WindowClosingEvent -= GTA5MenuWindow_WindowClosingEvent;
    }

    /////////////////////////////////////////////////

    private void FindVehiclesByModeName()
    {
        if (FindVehicles.Count != 0)
            FindVehicles.Clear();

        var name = TextBox_ModelName.Text;
        if (string.IsNullOrWhiteSpace(name))
            return;

        var result = AllVehicles.FindAll(v => v.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
        if (result.Count == 0)
            return;

        result.ForEach(v => FindVehicles.Add(v));
    }

    private void TextBox_ModelName_TextChanged(object sender, TextChangedEventArgs e)
    {
        FindVehiclesByModeName();
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
