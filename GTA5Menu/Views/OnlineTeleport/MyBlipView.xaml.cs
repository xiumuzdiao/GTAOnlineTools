using GTA5Menu.Data;

using GTA5Core.GTA;
using GTA5Shared.Helper;
using GTA5Core.Features;

namespace GTA5Menu.Views.OnlineTeleport;

/// <summary>
/// MyBlipView.xaml 的交互逻辑
/// </summary>
public partial class MyBlipView : UserControl
{
    public ObservableCollection<BlipInfo> MyFavorites { get; set; } = new();

    public static Action<BlipInfo> ActionAddMyFavorite;

    public MyBlipView()
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
        if (!File.Exists(FileHelper.File_Config_Blips))
            return;

        try
        {
            var blips = JsonHelper.ReadFile<List<int>>(FileHelper.File_Config_Blips);

            foreach (var item in blips)
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
                {
                    MyFavorites.Add(new()
                    {
                        Value = item,
                        Image = GTAHelper.GetBlipImage(item)
                    });
                });
            }
        }
        catch (Exception ex)
        {
            NotifierHelper.Show(NotifierType.Warning, $"Blips配置文件读取异常，{ex.Message}");
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
            var blips = new List<int>();
            foreach (BlipInfo info in ListBox_BlipInfos.Items)
            {
                blips.Add(info.Value);
            }
            // 写入到Json文件
            JsonHelper.WriteFile(FileHelper.File_Config_Blips, blips);
        }
        catch (Exception ex)
        {
            LoggerHelper.Error($"Blips配置文件写入异常，{ex.Message}");
        }
    }

    private void AddMyFavorite(BlipInfo info)
    {
        var result = MyFavorites.ToList().Find(var => var.Value == info.Value);
        if (result == null)
        {
            MyFavorites.Add(info);

            NotifierHelper.Show(NotifierType.Success, $"添加Blip {info.Value} 到我的收藏成功");
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, $"Blip {info.Value} 已存在，请勿重复添加");
        }
    }

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

    private void Button_DeleteMyFavorite_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_BlipInfos.SelectedItem is BlipInfo info)
        {
            MyFavorites.Remove(info);

            NotifierHelper.Show(NotifierType.Success, $"从我的收藏删除Blip {info.Value} 成功");
        }
    }
}
