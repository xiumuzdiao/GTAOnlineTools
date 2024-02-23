using GTA5Menu.Config;
using GTA5Menu.Models;

using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.OnlineTeleport;

/// <summary>
/// CustomTeleportView.xaml 的交互逻辑
/// </summary>
public partial class CustomTeleportView : UserControl
{
    public ObservableCollection<TeleportInfoModel> CustomTeleports { get; set; } = new();

    public CustomTeleportView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;

        ReadConfig();
    }

    /// <summary>
    /// 主窗口关闭事件
    /// </summary>
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
        if (!File.Exists(FileHelper.File_Config_Teleports))
            return;

        try
        {
            var teleports = JsonHelper.ReadFile<Teleports>(FileHelper.File_Config_Teleports);

            foreach (var custom in teleports.CustomLocations)
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
                {
                    CustomTeleports.Add(new()
                    {
                        Name = custom.Name,
                        X = custom.X,
                        Y = custom.Y,
                        Z = custom.Z
                    });
                });
            }
        }
        catch (Exception ex)
        {
            NotifierHelper.Show(NotifierType.Warning, $"Teleports配置文件读取异常，{ex.Message}");
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
            var teleports = new Teleports
            {
                CustomLocations = new()
            };
            // 加载到配置文件
            foreach (var info in CustomTeleports)
            {
                teleports.CustomLocations.Add(new()
                {
                    Name = info.Name,
                    X = info.X,
                    Y = info.Y,
                    Z = info.Z,
                    Pitch = 0.0f,
                    Yaw = 0.0f,
                    Roll = 0.0f,
                });
            }
            // 写入到Json文件
            JsonHelper.WriteFile(FileHelper.File_Config_Teleports, teleports);
        }
        catch (Exception ex)
        {
            LoggerHelper.Error($"Teleports配置文件写入异常，{ex.Message}");
        }
    }

    private void ListBox_CustomTeleports_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_Teleport_Click(null, null);
    }

    /// <summary>
    /// 增加自定义传送坐标
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_AddCustomTeleport_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var vector3 = Teleport.GetPlayerPosition();

        CustomTeleports.Add(new()
        {
            Name = $"保存点 : {DateTime.Now:yyyyMMdd_HHmmss_ffff}",
            X = vector3.X,
            Y = vector3.Y,
            Z = vector3.Z
        });

        ListBox_CustomTeleports.SelectedIndex = ListBox_CustomTeleports.Items.Count - 1;
    }

    /// <summary>
    /// 修改自定义传送坐标
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_EditCustomTeleport_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var tempName = TextBox_CustomName.Text.Trim();
        var tempX = TextBox_Position_X.Text.Trim();
        var tempY = TextBox_Position_Y.Text.Trim();
        var tempZ = TextBox_Position_Z.Text.Trim();

        if (string.IsNullOrEmpty(tempName))
        {
            NotifierHelper.Show(NotifierType.Warning, "坐标名称不能为空，操作取消");
            return;
        }

        if (!float.TryParse(tempX, out float x) ||
            !float.TryParse(tempY, out float y) ||
            !float.TryParse(tempZ, out float z))
        {
            NotifierHelper.Show(NotifierType.Warning, "坐标数据不合法，操作取消");
            return;
        }

        var index = ListBox_CustomTeleports.SelectedIndex;
        if (index == -1)
        {
            NotifierHelper.Show(NotifierType.Warning, "当前自定义传送坐标选中项为空");
            return;
        }

        CustomTeleports[index].Name = tempName;
        CustomTeleports[index].X = x;
        CustomTeleports[index].Y = y;
        CustomTeleports[index].Z = z;

        NotifierHelper.Show(NotifierType.Success, "修改自定义传送坐标数据成功");
    }

    /// <summary>
    /// 删除自定义传送坐标
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_DeleteCustomTeleport_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var index = ListBox_CustomTeleports.SelectedIndex;
        if (index == -1)
        {
            NotifierHelper.Show(NotifierType.Warning, "当前自定义传送坐标选中项为空");
            return;
        }

        CustomTeleports.RemoveAt(index);
    }

    /// <summary>
    /// 传送到自定义传送坐标
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Teleport_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var index = ListBox_CustomTeleports.SelectedIndex;
        if (index == -1)
        {
            NotifierHelper.Show(NotifierType.Warning, "当前自定义传送坐标选中项为空");
            return;
        }

        var info = CustomTeleports[index];

        Teleport.SetTeleportPosition(new()
        {
            X = info.X,
            Y = info.Y,
            Z = info.Z
        });
    }
}
