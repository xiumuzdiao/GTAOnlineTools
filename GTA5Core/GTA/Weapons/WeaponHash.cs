namespace GTA5Core.GTA.Weapons;

public static class WeaponHash
{
    public class WeaponClass
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public List<WeaponInfo> WeaponInfos { get; set; }
    }

    public class WeaponInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    /// <summary>
    /// 近战
    /// </summary>
    public static readonly List<WeaponInfo> Melee = new()
    {
        new WeaponInfo(){ Name="古董骑兵匕首", Value="weapon_dagger" },
        new WeaponInfo(){ Name="球棒", Value="weapon_bat" },
        new WeaponInfo(){ Name="酒瓶", Value="weapon_bottle" },
        new WeaponInfo(){ Name="撬棒", Value="weapon_crowbar" },
        new WeaponInfo(){ Name="徒手", Value="weapon_unarmed" },
        new WeaponInfo(){ Name="手电筒", Value="weapon_flashlight" },
        new WeaponInfo(){ Name="高尔夫球杆", Value="weapon_golfclub" },
        new WeaponInfo(){ Name="铁锤", Value="weapon_hammer" },
        new WeaponInfo(){ Name="手斧", Value="weapon_hatchet" },
        new WeaponInfo(){ Name="手指虎", Value="weapon_knuckle" },
        new WeaponInfo(){ Name="小刀", Value="weapon_knife" },
        new WeaponInfo(){ Name="开山刀", Value="weapon_machete" },
        new WeaponInfo(){ Name="弹簧刀", Value="weapon_switchblade" },
        new WeaponInfo(){ Name="警棍", Value="weapon_nightstick" },
        new WeaponInfo(){ Name="管钳扳手", Value="weapon_wrench" },
        new WeaponInfo(){ Name="战斧", Value="weapon_battleaxe" },
        new WeaponInfo(){ Name="台球杆", Value="weapon_poolcue" },
        new WeaponInfo(){ Name="石斧", Value="weapon_stone_hatchet" },
    };

    /// <summary>
    /// 手枪
    /// </summary>
    public static readonly List<WeaponInfo> Handguns = new()
    {
        new WeaponInfo(){ Name="手枪", Value="weapon_pistol" },
        new WeaponInfo(){ Name="MK2 手枪", Value="weapon_pistol_mk2" },
        new WeaponInfo(){ Name="战斗手枪", Value="weapon_combatpistol" },
        new WeaponInfo(){ Name="穿甲手枪", Value="weapon_appistol" },
        new WeaponInfo(){ Name="电击枪", Value="weapon_stungun" },
        new WeaponInfo(){ Name="0.5口径手枪", Value="weapon_pistol50" },
        new WeaponInfo(){ Name="劣质手枪", Value="weapon_snspistol" },
        new WeaponInfo(){ Name="MK2 劣质手枪", Value="weapon_snspistol_mk2" },
        new WeaponInfo(){ Name="重型手枪", Value="weapon_heavypistol" },
        new WeaponInfo(){ Name="老式手枪", Value="weapon_vintagepistol" },
        new WeaponInfo(){ Name="信号枪", Value="weapon_flaregun" },
        new WeaponInfo(){ Name="射手手枪", Value="weapon_marksmanpistol" },
        new WeaponInfo(){ Name="重型左轮手枪", Value="weapon_revolver" },
        new WeaponInfo(){ Name="MK2 重型左轮手枪", Value="weapon_revolver_mk2" },
        new WeaponInfo(){ Name="双动式左轮手枪 ", Value="weapon_doubleaction" },
        new WeaponInfo(){ Name="原子能手枪", Value="weapon_raypistol" },
        new WeaponInfo(){ Name="陶瓷手枪", Value="weapon_ceramicpistol" },
        new WeaponInfo(){ Name="海军左轮手枪", Value="weapon_navyrevolver" },
        new WeaponInfo(){ Name="佩里科手枪", Value="weapon_gadgetpistol" },
        new WeaponInfo(){ Name="电击枪（多人）", Value="weapon_stungun_mp" },
    };

    /// <summary>
    /// 冲锋枪
    /// </summary>
    public static readonly List<WeaponInfo> SubmachineGuns = new()
    {
        new WeaponInfo(){ Name="微型冲锋枪", Value="weapon_microsmg" },
        new WeaponInfo(){ Name="冲锋枪", Value="weapon_smg" },
        new WeaponInfo(){ Name="MK2 冲锋枪", Value="weapon_smg_mk2" },
        new WeaponInfo(){ Name="突击冲锋枪", Value="weapon_assaultsmg" },
        new WeaponInfo(){ Name="作战自卫冲锋枪", Value="weapon_combatpdw" },
        new WeaponInfo(){ Name="冲锋手枪", Value="weapon_machinepistol" },
        new WeaponInfo(){ Name="迷你冲锋枪", Value="weapon_minismg" },
        new WeaponInfo(){ Name="古森柏冲锋枪", Value="weapon_gusenberg" },
        new WeaponInfo(){ Name="战术冲锋枪", Value="weapon_tecpistol" },
    };

    /// <summary>
    /// 霰弹枪
    /// </summary>
    public static readonly List<WeaponInfo> Shotguns = new()
    {
        new WeaponInfo(){ Name="泵动式霰弹枪", Value="weapon_pumpshotgun" },
        new WeaponInfo(){ Name="MK2 泵动式霰弹枪", Value="weapon_pumpshotgun_mk2" },
        new WeaponInfo(){ Name="短管霰弹枪", Value="weapon_sawnoffshotgun" },
        new WeaponInfo(){ Name="突击霰弹枪", Value="weapon_assaultshotgun" },
        new WeaponInfo(){ Name="无托式霰弹枪", Value="weapon_bullpupshotgun" },
        new WeaponInfo(){ Name="老式火枪", Value="weapon_musket" },
        new WeaponInfo(){ Name="重型霰弹枪", Value="weapon_heavyshotgun" },
        new WeaponInfo(){ Name="双管霰弹枪", Value="weapon_dbshotgun" },
        new WeaponInfo(){ Name="冲锋霰弹枪", Value="weapon_autoshotgun" },
        new WeaponInfo(){ Name="战斗霰弹枪", Value="weapon_combatshotgun" },
    };

    /// <summary>
    /// 突击步枪
    /// </summary>
    public static readonly List<WeaponInfo> AssaultRifles = new()
    {
        new WeaponInfo(){ Name="突击步枪", Value="weapon_assaultrifle" },
        new WeaponInfo(){ Name="MK2 突击步枪", Value="weapon_assaultrifle_mk2" },
        new WeaponInfo(){ Name="卡宾步枪", Value="weapon_carbinerifle" },
        new WeaponInfo(){ Name="MK2 卡宾步枪", Value="weapon_carbinerifle_mk2" },
        new WeaponInfo(){ Name="高级步枪", Value="weapon_advancedrifle" },
        new WeaponInfo(){ Name="特制卡宾步枪", Value="weapon_specialcarbine" },
        new WeaponInfo(){ Name="MK2 特制卡宾步枪", Value="weapon_specialcarbine_mk2" },
        new WeaponInfo(){ Name="无托式步枪", Value="weapon_bullpuprifle" },
        new WeaponInfo(){ Name="MK2 无托式步枪", Value="weapon_bullpuprifle_mk2" },
        new WeaponInfo(){ Name="紧凑型步枪", Value="weapon_compactrifle" },
        new WeaponInfo(){ Name="军用步枪", Value="weapon_militaryrifle" },
        new WeaponInfo(){ Name="重型步枪", Value="weapon_heavyrifle" },
        new WeaponInfo(){ Name="制式卡宾步枪", Value="weapon_tacticalrifle" },
    };

    /// <summary>
    /// 轻机枪
    /// </summary>
    public static readonly List<WeaponInfo> LightMachineGuns = new()
    {
        new WeaponInfo(){ Name="机枪", Value="weapon_mg" },
        new WeaponInfo(){ Name="战斗机枪", Value="weapon_combatmg" },
        new WeaponInfo(){ Name="MK2 战斗机枪", Value="weapon_combatmg_mk2" },
        new WeaponInfo(){ Name="邪恶冥王", Value="weapon_raycarbine" },
    };

    /// <summary>
    /// 狙击枪
    /// </summary>
    public static readonly List<WeaponInfo> SniperRifles = new()
    {
        new WeaponInfo(){ Name="狙击步枪", Value="weapon_sniperrifle" },
        new WeaponInfo(){ Name="重型狙击步枪", Value="weapon_heavysniper" },
        new WeaponInfo(){ Name="MK2 重型狙击步枪", Value="weapon_heavysniper_mk2" },
        new WeaponInfo(){ Name="射手步枪", Value="weapon_marksmanrifle" },
        new WeaponInfo(){ Name="MK2 射手步枪", Value="weapon_marksmanrifle_mk2" },
        new WeaponInfo(){ Name="精确步枪", Value="weapon_precisionrifle" },
    };

    /// <summary>
    /// 重武器
    /// </summary>
    public static readonly List<WeaponInfo> HeavyWeapons = new()
    {
        new WeaponInfo(){ Name="火箭炮", Value="weapon_rpg" },
        new WeaponInfo(){ Name="榴弹发射器", Value="weapon_grenadelauncher" },
        new WeaponInfo(){ Name="烟雾榴弹发射器", Value="weapon_grenadelauncher_smoke" },
        new WeaponInfo(){ Name="火神机枪", Value="weapon_minigun" },
        new WeaponInfo(){ Name="烟火发射器", Value="weapon_firework" },
        new WeaponInfo(){ Name="电磁步枪", Value="weapon_railgun" },
        new WeaponInfo(){ Name="制导火箭发射器", Value="weapon_hominglauncher" },
        new WeaponInfo(){ Name="紧凑型榴弹发射器", Value="weapon_compactlauncher" },
        new WeaponInfo(){ Name="寡妇制造者", Value="weapon_rayminigun" },
        new WeaponInfo(){ Name="紧凑电磁脉冲发射器", Value="weapon_emplauncher" },
    };

    /// <summary>
    /// 投掷物
    /// </summary>
    public static readonly List<WeaponInfo> Throwables = new()
    {
        new WeaponInfo(){ Name="手榴弹", Value="weapon_grenade" },
        new WeaponInfo(){ Name="毒气手榴弹", Value="weapon_bzgas" },
        new WeaponInfo(){ Name="汽油弹", Value="weapon_molotov" },
        new WeaponInfo(){ Name="黏弹", Value="weapon_stickybomb" },
        new WeaponInfo(){ Name="感应地雷", Value="weapon_proxmine" },
        new WeaponInfo(){ Name="雪球", Value="weapon_snowball" },
        new WeaponInfo(){ Name="土制炸弹", Value="weapon_pipebomb" },
        new WeaponInfo(){ Name="棒球", Value="weapon_ball" },
        new WeaponInfo(){ Name="催泪瓦斯", Value="weapon_smokegrenade" },
        new WeaponInfo(){ Name="信号弹", Value="weapon_flare" },
    };

    /// <summary>
    /// 杂项
    /// </summary>
    public static readonly List<WeaponInfo> Miscellaneous = new()
    {
        new WeaponInfo(){ Name="油桶", Value="weapon_petrolcan" },
        new WeaponInfo(){ Name="降落伞", Value="gadget_parachute" },
        new WeaponInfo(){ Name="灭火器", Value="weapon_fireextinguisher" },
        new WeaponInfo(){ Name="危险的杰瑞罐", Value="weapon_hazardcan" },
        new WeaponInfo(){ Name="肥料罐", Value="weapon_fertilizercan" },
    };

    /// <summary>
    /// 武器分类
    /// </summary>
    public static readonly List<WeaponClass> WeaponClasses = new()
    {
        new WeaponClass(){ Icon="\xe616", Name="近战", WeaponInfos=Melee },
        new WeaponClass(){ Icon="\xe616", Name="手枪", WeaponInfos=Handguns },
        new WeaponClass(){ Icon="\xe616", Name="冲锋枪", WeaponInfos=SubmachineGuns },
        new WeaponClass(){ Icon="\xe616", Name="霰弹枪", WeaponInfos=Shotguns },
        new WeaponClass(){ Icon="\xe616", Name="突击步枪", WeaponInfos=AssaultRifles },
        new WeaponClass(){ Icon="\xe616", Name="轻机枪", WeaponInfos=LightMachineGuns },
        new WeaponClass(){ Icon="\xe616", Name="狙击枪", WeaponInfos=SniperRifles },
        new WeaponClass(){ Icon="\xe616", Name="重武器", WeaponInfos=HeavyWeapons },
        new WeaponClass(){ Icon="\xe616", Name="投掷物", WeaponInfos=Throwables },
        new WeaponClass(){ Icon="\xe616", Name="杂项", WeaponInfos=Miscellaneous }
    };
}
