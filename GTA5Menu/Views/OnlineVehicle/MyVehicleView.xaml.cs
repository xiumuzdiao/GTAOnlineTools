using GTA5Menu.Data;
using GTA5Menu.Config;

using GTA5Core.GTA;
using GTA5Core.GTA.Vehicles;
using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.OnlineVehicle;

/// <summary>
/// MyVehicleView.xaml 的交互逻辑
/// </summary>
public partial class MyVehicleView : UserControl
{
    public ObservableCollection<ModelInfo> MyFavorites { get; set; } = new();

    public static Action<ModelInfo> ActionAddMyFavorite;

    public MyVehicleView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;

        ActionAddMyFavorite = AddMyFavorite;

        ReadConfig();
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        SaveConfig();

        GTA5MenuWindow.WindowClosingEvent -= GTA5MenuWindow_WindowClosingEvent;
    }

    /////////////////////////////////////////////////

    /// <summary>
    /// 读取配置文件
    /// </summary>
    private void ReadConfig()
    {
        if (!File.Exists(FileHelper.File_Config_Vehicles))
            return;

        try
        {
            var vehicles = JsonHelper.ReadFile<List<Vehicles>>(FileHelper.File_Config_Vehicles);

            foreach (var item in vehicles)
            {
                var classes = VehicleHash.VehicleClasses.Find(v => v.Name == item.Class);
                if (classes == null)
                    continue;

                var info = classes.VehicleInfos.Find(v => v.Value == item.Value);
                if (info == null)
                    continue;

                this.Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
                {
                    MyFavorites.Add(new()
                    {
                        Class = classes.Name,
                        Name = info.Name,
                        Value = info.Value,
                        Image = GTAHelper.GetVehicleImage(info.Value),
                        Mods = info.Mods
                    });
                });
            }
        }
        catch (Exception ex)
        {
            NotifierHelper.Show(NotifierType.Warning, $"Vehicles配置文件读取异常，{ex.Message}");
        }
    }

    /// <summary>
    /// 保存配置文件
    /// </summary>
    private void SaveConfig()
    {
        if (!Directory.Exists(FileHelper.Dir_Config))
            return;

        try
        {
            var vehicles = new List<Vehicles>();
            foreach (ModelInfo info in ListBox_VehicleInfos.Items)
            {
                vehicles.Add(new()
                {
                    Class = info.Class,
                    Name = info.Name,
                    Value = info.Value,
                });
            }
            // 写入到Json文件
            JsonHelper.WriteFile(FileHelper.File_Config_Vehicles, vehicles);
        }
        catch (Exception ex)
        {
            LoggerHelper.Error($"Vehicles配置文件写入异常，{ex.Message}");
        }
    }

    private void AddMyFavorite(ModelInfo model)
    {
        var result = MyFavorites.ToList().Find(var => var.Value == model.Value);
        if (result == null)
        {
            MyFavorites.Add(model);

            NotifierHelper.Show(NotifierType.Success, $"添加载具 {model.Name} 到我的收藏成功");
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, $"载具 {model.Name} 已存在，请勿重复添加");
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

    private void Button_DeleteMyFavorite_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_VehicleInfos.SelectedItem is ModelInfo info)
        {
            MyFavorites.Remove(info);

            NotifierHelper.Show(NotifierType.Success, $"从我的收藏删除载具 {info.Name} 成功");
        }
    }
}
