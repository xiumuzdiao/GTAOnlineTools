using GTA5Menu.Data;

using GTA5Core.Offsets;
using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.OnlineVehicle;

/// <summary>
/// DriverButlerView.xaml 的交互逻辑
/// </summary>
public partial class DriverButlerView : UserControl
{
    private List<PerVehInfo> _perVehInfos = new();

    public ObservableCollection<PerVehInfo> PerVehInfos { get; set; } = new();

    public DriverButlerView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        GTA5MenuWindow.WindowClosingEvent -= GTA5MenuWindow_WindowClosingEvent;
    }

    /////////////////////////////////////////////////

    private async void Button_RefushPersonalVehicleList_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        _perVehInfos.Clear();
        PerVehInfos.Clear();

        await Task.Run(() =>
        {
            int max_slots = Globals.Get_Global_Value<int>(Base.oVMSlots);
            for (int i = 0; i < max_slots; i++)
            {
                long hash = Globals.Get_Global_Value<long>(Base.oVMSlots + 1 + (i * 142) + 66);
                if (hash == 0)
                    continue;

                string plate = Globals.Get_Global_String(Base.oVMSlots + 1 + (i * 142) + 1);

                var vInfo = Vehicle2.FindVehicleNameByHash(hash);
                if (vInfo == null)
                    continue;

                var preVInfo = new PerVehInfo()
                {
                    Id = i,
                    Name = vInfo.Name,
                    Hash = hash,
                    Plate = plate,
                    Image = vInfo.Image
                };

                this.Dispatcher.Invoke(() =>
                {
                    _perVehInfos.Add(preVInfo);
                    PerVehInfos.Add(preVInfo);
                });
            }
        });
    }

    private void Button_SpawnPersonalVehicle_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_VehicleInfos.SelectedItem is PerVehInfo info)
            Vehicle.RequestPersonalVehicle(info.Id);
    }

    private void Button_GetInOnlinePV_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Online.GetInOnlinePV();
    }

    private void ListBox_VehicleInfos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_SpawnPersonalVehicle_Click(null, null);
    }

    private void TextBox_ModelName_TextChanged(object sender, TextChangedEventArgs e)
    {
        FindVehiclesByModeName();
    }

    private void FindVehiclesByModeName()
    {
        if (PerVehInfos.Count != 0)
            PerVehInfos.Clear();

        var name = TextBox_ModelName.Text;
        if (string.IsNullOrWhiteSpace(name))
        {
            PerVehInfos.Clear();
            _perVehInfos.ForEach(v => PerVehInfos.Add(v));
            return;
        }

        var result = _perVehInfos.FindAll(v => v.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
        if (result.Count == 0)
            return;

        result.ForEach(v => PerVehInfos.Add(v));
    }
}
