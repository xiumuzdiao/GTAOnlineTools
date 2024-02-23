using GTA5Core.Features;
using GTA5Core.GTA.Onlines;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// JobHelperView.xaml 的交互逻辑
/// </summary>
public partial class JobHelperView : UserControl
{
    private class Options
    {
        public bool CEOBuyingCratesCooldown = false;
        public bool CEOSellingCratesCooldown = false;

        public bool CEOWorkCooldown = false;
        public bool ClientJobCooldown = false;

        public bool BunkerSupplyDelay = false;
        public bool UnlockBunkerResearch = false;

        public bool MCSupplyDelay = false;

        public bool NightclubOutDelay = false;

        public bool ExportVehicleDelay = false;

        public bool SmugglerRunInDelay = false;
        public bool SmugglerRunOutDelay = false;

        public bool SecurityHitCooldown = false;
        public bool PayphoneHitCooldown = false;
    }
    private readonly Options _options = new();

    public JobHelperView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;
        GTA5MenuWindow.LoopSpeedNormalEvent += GTA5MenuWindow_LoopSpeedNormalEvent;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        GTA5MenuWindow.WindowClosingEvent -= GTA5MenuWindow_WindowClosingEvent;
        GTA5MenuWindow.LoopSpeedNormalEvent -= GTA5MenuWindow_LoopSpeedNormalEvent;
    }

    private void GTA5MenuWindow_LoopSpeedNormalEvent()
    {
        // 只有用户勾选才开启循环写入，不勾选不修改值（避免与其他工具冲突）

        // 移除购买板条箱冷却
        if (_options.CEOBuyingCratesCooldown)
            Online.CEOBuyingCratesCooldown(true);
        // 移除出售板条箱冷却
        if (_options.CEOSellingCratesCooldown)
            Online.CEOSellingCratesCooldown(true);

        // 移除CEO工作冷却
        if (_options.CEOWorkCooldown)
            Online.CEOWorkCooldown(true);
        // 移除恐霸客户差事冷却
        if (_options.ClientJobCooldown)
            Online.ClientJobCooldown(true);

        // 移除地堡进货延迟
        if (_options.BunkerSupplyDelay)
            Online.BunkerSupplyDelay(true);
        // 解锁地堡所有研究 (临时)
        if (_options.UnlockBunkerResearch)
            Online.UnlockBunkerResearch(true);

        // 移除摩托帮进货延迟
        if (_options.MCSupplyDelay)
            Online.MCSupplyDelay(true);

        // 移除夜总会出货延迟
        if (_options.NightclubOutDelay)
            Online.NightclubOutDelay(true);

        // 移除进出口大亨出货延迟
        if (_options.ExportVehicleDelay)
            Online.ExportVehicleDelay(true);

        // 移除机库进货延迟
        if (_options.SmugglerRunInDelay)
            Online.SmugglerRunInDelay(true);
        // 移除机库出货延迟
        if (_options.SmugglerRunOutDelay)
            Online.SmugglerRunOutDelay(true);

        // 移除事务所安保合约冷却
        if (_options.SecurityHitCooldown)
            Online.SecurityHitCooldown(true);
        // 移除公共电话任务合约冷却
        if (_options.PayphoneHitCooldown)
            Online.PayphoneHitCooldown(true);
    }

    /////////////////////////////////////////////////

    private void Button_CEOCargos_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (sender is Button button)
        {
            var btnContent = button.Content.ToString();

            var cargo = OnlineData.CEOCargos.Find(t => t.Name == btnContent);
            if (cargo != null)
            {
                Online.CEOSpecialCargo(false);
                Online.CEOCargoType(cargo.Value);
            }
        }
    }

    private void Button_CEOSpecialCargos_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (sender is Button button)
        {
            var btnContent = button.Content.ToString();

            var specialCargo = OnlineData.CEOSpecialCargos.Find(t => t.Name == btnContent);
            if (specialCargo != null)
            {
                // They are in gb_contraband_buy at func_915, for future updates.
                Online.CEOSpecialCargo(true);
                Online.CEOCargoType(specialCargo.Value);
            }
        }
    }

    private void CheckBox_CEOBuyingCratesCooldown_Click(object sender, RoutedEventArgs e)
    {
        _options.CEOBuyingCratesCooldown = CheckBox_CEOBuyingCratesCooldown.IsChecked == true;
        Online.CEOBuyingCratesCooldown(_options.CEOBuyingCratesCooldown);
    }

    private void CheckBox_CEOSellingCratesCooldown_Click(object sender, RoutedEventArgs e)
    {
        _options.CEOSellingCratesCooldown = CheckBox_CEOSellingCratesCooldown.IsChecked == true;
        Online.CEOSellingCratesCooldown(_options.CEOSellingCratesCooldown);
    }

    private void CheckBox_CEOWorkCooldown_Click(object sender, RoutedEventArgs e)
    {
        _options.CEOWorkCooldown = CheckBox_CEOWorkCooldown.IsChecked == true;
        Online.CEOWorkCooldown(_options.CEOWorkCooldown);
    }

    private void CheckBox_ClientJobCooldown_Click(object sender, RoutedEventArgs e)
    {
        _options.ClientJobCooldown = CheckBox_ClientJobCooldown.IsChecked == true;
        Online.ClientJobCooldown(_options.ClientJobCooldown);
    }

    private void CheckBox_BunkerSupplyDelay_Click(object sender, RoutedEventArgs e)
    {
        _options.BunkerSupplyDelay = CheckBox_BunkerSupplyDelay.IsChecked == true;
        Online.BunkerSupplyDelay(_options.BunkerSupplyDelay);
    }

    private void CheckBox_UnlockBunkerResearch_Click(object sender, RoutedEventArgs e)
    {
        _options.UnlockBunkerResearch = CheckBox_UnlockBunkerResearch.IsChecked == true;
        Online.UnlockBunkerResearch(_options.UnlockBunkerResearch);
    }

    private void CheckBox_MCSupplyDelay_Click(object sender, RoutedEventArgs e)
    {
        _options.MCSupplyDelay = CheckBox_MCSupplyDelay.IsChecked == true;
        Online.MCSupplyDelay(_options.MCSupplyDelay);
    }

    private void CheckBox_NightclubOutDelay_Click(object sender, RoutedEventArgs e)
    {
        _options.NightclubOutDelay = CheckBox_NightclubOutDelay.IsChecked == true;
        Online.NightclubOutDelay(_options.NightclubOutDelay);
    }

    private void CheckBox_ExportVehicleDelay_Click(object sender, RoutedEventArgs e)
    {
        _options.ExportVehicleDelay = CheckBox_ExportVehicleDelay.IsChecked == true;
        Online.ExportVehicleDelay(_options.ExportVehicleDelay);
    }

    private void CheckBox_SmugglerRunInDelay_Click(object sender, RoutedEventArgs e)
    {
        _options.SmugglerRunInDelay = CheckBox_SmugglerRunInDelay.IsChecked == true;
        Online.SmugglerRunInDelay(_options.SmugglerRunInDelay);
    }

    private void CheckBox_SmugglerRunOutDelay_Click(object sender, RoutedEventArgs e)
    {
        _options.SmugglerRunOutDelay = CheckBox_SmugglerRunOutDelay.IsChecked == true;
        Online.SmugglerRunOutDelay(_options.SmugglerRunOutDelay);
    }

    private void CheckBox_SecurityHitCooldown_Click(object sender, RoutedEventArgs e)
    {
        _options.SecurityHitCooldown = CheckBox_SecurityHitCooldown.IsChecked == true;
        Online.SecurityHitCooldown(_options.SecurityHitCooldown);
    }

    private void CheckBox_PayphoneHitCooldown_Click(object sender, RoutedEventArgs e)
    {
        _options.PayphoneHitCooldown = CheckBox_PayphoneHitCooldown.IsChecked == true;
        Online.PayphoneHitCooldown(_options.PayphoneHitCooldown);
    }
}
