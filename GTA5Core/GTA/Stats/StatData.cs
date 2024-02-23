namespace GTA5Core.GTA.Stats;

public static class StatData
{
    public class StatClass
    {
        public string Name { get; set; }
        public List<StatInfo> StatInfos { get; set; }
    }

    public class StatInfo
    {
        public string Hash { get; set; }
        public int Value { get; set; }
    }

    #region 玩家
    /// <summary>
    /// 玩家护甲全满
    /// </summary>
    public static readonly List<StatInfo> MP_CHAR_ARMOUR = new()
    {
        new StatInfo(){ Hash="MPx_MP_CHAR_ARMOUR_1_COUNT", Value=100 },
        new StatInfo(){ Hash="MPx_MP_CHAR_ARMOUR_2_COUNT", Value=100 },
        new StatInfo(){ Hash="MPx_MP_CHAR_ARMOUR_3_COUNT", Value=100 },
        new StatInfo(){ Hash="MPx_MP_CHAR_ARMOUR_4_COUNT", Value=100 },
        new StatInfo(){ Hash="MPx_MP_CHAR_ARMOUR_5_COUNT", Value=100 },
    };

    /// <summary>
    /// 玩家零食全满
    /// </summary>
    public static readonly List<StatInfo> NO_BOUGHT = new()
    {
        new StatInfo(){ Hash="MPx_NO_BOUGHT_YUM_SNACKS", Value=100 },
        new StatInfo(){ Hash="MPx_NO_BOUGHT_HEALTH_SNACKS", Value=100 },
        new StatInfo(){ Hash="MPx_NO_BOUGHT_EPIC_SNACKS", Value=100 },
        new StatInfo(){ Hash="MPx_NUMBER_OF_ORANGE_BOUGHT", Value=100 },
        new StatInfo(){ Hash="MPx_NUMBER_OF_BOURGE_BOUGHT", Value=100 },
        new StatInfo(){ Hash="MPx_CIGARETTES_BOUGHT", Value=100 },
        new StatInfo(){ Hash="MPx_NUMBER_OF_CHAMP_BOUGHT", Value=100 },
    };

    /// <summary>
    /// 玩家属性全满
    /// </summary>
    public static readonly List<StatInfo> SCRIPT_INCREASE = new()
    {
        new StatInfo(){ Hash="MPx_SCRIPT_INCREASE_STAM", Value=100 },
        new StatInfo(){ Hash="MPx_SCRIPT_INCREASE_SHO", Value=100 },
        new StatInfo(){ Hash="MPx_SCRIPT_INCREASE_STRN", Value=100 },
        new StatInfo(){ Hash="MPx_SCRIPT_INCREASE_STL", Value=100 },
        new StatInfo(){ Hash="MPx_SCRIPT_INCREASE_FLY", Value=100 },
        new StatInfo(){ Hash="MPx_SCRIPT_INCREASE_DRIV", Value=100 },
        new StatInfo(){ Hash="MPx_SCRIPT_INCREASE_LUNG", Value=100 },
    };

    /// <summary>
    /// 玩家隐藏属性全满
    /// </summary>
    public static readonly List<StatInfo> CHAR_ABILITY = new()
    {
        new StatInfo(){ Hash="MPx_CHAR_ABILITY_1_UNLCK", Value=-1 },
        new StatInfo(){ Hash="MPx_CHAR_ABILITY_2_UNLCK", Value=-1 },
        new StatInfo(){ Hash="MPx_CHAR_ABILITY_3_UNLCK", Value=-1 },
        new StatInfo(){ Hash="MPx_CHAR_FM_ABILITY_1_UNLCK", Value=-1 },
        new StatInfo(){ Hash="MPx_CHAR_FM_ABILITY_2_UNLCK", Value=-1 },
        new StatInfo(){ Hash="MPx_CHAR_FM_ABILITY_3_UNLCK", Value=-1 },
    };

    /// <summary>
    /// 重置玩家隐藏属性
    /// </summary>
    public static readonly List<StatInfo> CHAR_ABILITY0 = new()
    {
        new StatInfo(){ Hash="MPx_CHAR_ABILITY_1_UNLCK", Value=0 },
        new StatInfo(){ Hash="MPx_CHAR_ABILITY_2_UNLCK", Value=0 },
        new StatInfo(){ Hash="MPx_CHAR_ABILITY_3_UNLCK", Value=0 },
        new StatInfo(){ Hash="MPx_CHAR_FM_ABILITY_1_UNLCK", Value=0 },
        new StatInfo(){ Hash="MPx_CHAR_FM_ABILITY_2_UNLCK", Value=0 },
        new StatInfo(){ Hash="MPx_CHAR_FM_ABILITY_3_UNLCK", Value=0 },
    };

    /// <summary>
    /// 开启玩家性别修改（去重新捏脸）
    /// </summary>
    public static readonly List<StatInfo> GENDER_CHANGE_ON = new()
    {
        new StatInfo(){ Hash="MPx_ALLOW_GENDER_CHANGE", Value=52 },
    };

    /// <summary>
    /// 关闭玩家性别修改（去重新捏脸）
    /// </summary>
    public static readonly List<StatInfo> GENDER_CHANGE_OFF = new()
    {
        new StatInfo(){ Hash="MPx_ALLOW_GENDER_CHANGE", Value=0 },
    };

    /// <summary>
    /// 设置玩家等级为1
    /// </summary>
    public static readonly List<StatInfo> CHAR_SET_RP1 = new()
    {
        new StatInfo(){ Hash="MPx_CHAR_SET_RP_GIFT_ADMIN", Value=0 },
    };

    /// <summary>
    /// 设置玩家等级为30
    /// </summary>
    public static readonly List<StatInfo> CHAR_SET_RP30 = new()
    {
        new StatInfo(){ Hash="MPx_CHAR_SET_RP_GIFT_ADMIN", Value=177100 },
    };

    /// <summary>
    /// 设置玩家等级为60
    /// </summary>
    public static readonly List<StatInfo> CHAR_SET_RP60 = new()
    {
        new StatInfo(){ Hash="MPx_CHAR_SET_RP_GIFT_ADMIN", Value=625400 },
    };

    /// <summary>
    /// 设置玩家等级为90
    /// </summary>
    public static readonly List<StatInfo> CHAR_SET_RP90 = new()
    {
        new StatInfo(){ Hash="MPx_CHAR_SET_RP_GIFT_ADMIN", Value=1308100 },
    };

    /// <summary>
    /// 设置玩家等级为120
    /// </summary>
    public static readonly List<StatInfo> CHAR_SET_RP120 = new()
    {
        new StatInfo(){ Hash="MPx_CHAR_SET_RP_GIFT_ADMIN", Value=2165850 },
    };
    #endregion

    #region 车友会
    /// <summary>
    /// 设置车友会等级为1
    /// </summary>
    public static readonly List<StatInfo> CAR_CLUB_REP1 = new()
    {
        new StatInfo(){ Hash="MPx_CAR_CLUB_REP", Value=5 },
    };

    /// <summary>
    /// 设置车友会等级为50
    /// </summary>
    public static readonly List<StatInfo> CAR_CLUB_REP50 = new()
    {
        new StatInfo(){ Hash="MPx_CAR_CLUB_REP", Value=10540 },
    };

    /// <summary>
    /// 设置车友会等级为100
    /// </summary>
    public static readonly List<StatInfo> CAR_CLUB_REP100 = new()
    {
        new StatInfo(){ Hash="MPx_CAR_CLUB_REP", Value=33665 },
    };

    /// <summary>
    /// 设置车友会等级为200
    /// </summary>
    public static readonly List<StatInfo> CAR_CLUB_REP200 = new()
    {
        new StatInfo(){ Hash="MPx_CAR_CLUB_REP", Value=117430 },
    };

    /// <summary>
    /// 设置车友会等级为500
    /// </summary>
    public static readonly List<StatInfo> CAR_CLUB_REP500 = new()
    {
        new StatInfo(){ Hash="MPx_CAR_CLUB_REP", Value=447430 },
    };
    #endregion

    #region 资产
    /// <summary>
    /// 补满夜总会人气（使用后切换战局）
    /// </summary>
    public static readonly List<StatInfo> CLUB_POPULARITY = new()
    {
        new StatInfo(){ Hash="MPx_CLUB_POPULARITY", Value=1000 },
    };

    /// <summary>
    /// 摩托帮和地堡自动进货（使用后切换战局）
    /// </summary>
    public static readonly List<StatInfo> PAYRESUPPLYTIMER = new()
    {
        new StatInfo(){ Hash="MPx_PAYRESUPPLYTIMER0", Value=1 },
        new StatInfo(){ Hash="MPx_PAYRESUPPLYTIMER1", Value=1 },
        new StatInfo(){ Hash="MPx_PAYRESUPPLYTIMER2", Value=1 },
        new StatInfo(){ Hash="MPx_PAYRESUPPLYTIMER3", Value=1 },
        new StatInfo(){ Hash="MPx_PAYRESUPPLYTIMER4", Value=1 },
        new StatInfo(){ Hash="MPx_PAYRESUPPLYTIMER5", Value=1 },
    };

    /// <summary>
    /// 取消摩托帮和地堡自动进货（使用后切换战局）
    /// </summary>
    public static readonly List<StatInfo> PAYRESUPPLYTIMER0 = new()
    {
        new StatInfo(){ Hash="MPx_PAYRESUPPLYTIMER0", Value=0 },
        new StatInfo(){ Hash="MPx_PAYRESUPPLYTIMER1", Value=0 },
        new StatInfo(){ Hash="MPx_PAYRESUPPLYTIMER2", Value=0 },
        new StatInfo(){ Hash="MPx_PAYRESUPPLYTIMER3", Value=0 },
        new StatInfo(){ Hash="MPx_PAYRESUPPLYTIMER4", Value=0 },
        new StatInfo(){ Hash="MPx_PAYRESUPPLYTIMER5", Value=0 },
    };
    #endregion

    #region 抢劫任务
    /// <summary>
    /// 佩里科岛抢劫-玩家x1/100%分红/困难模式/无精英/不拿保险柜/人均245W（粉钻x1+画作x2）
    /// </summary>
    public static readonly List<StatInfo> H4CNF_1 = new()
    {
        new StatInfo(){ Hash="MPx_H4CNF_BS_GEN", Value=131071 },
        new StatInfo(){ Hash="MPx_H4CNF_BS_ENTR", Value=63 },
        new StatInfo(){ Hash="MPx_H4CNF_BS_ABIL", Value=63 },
        new StatInfo(){ Hash="MPx_H4CNF_APPROACH", Value=-1 },
        new StatInfo(){ Hash="MPx_H4_PROGRESS", Value=131055 },
        new StatInfo(){ Hash="MPx_H4CNF_TARGET", Value=3 },
        new StatInfo(){ Hash="MPx_H4LOOT_PAINT", Value=-1 },
        new StatInfo(){ Hash="MPx_H4LOOT_PAINT_SCOPED", Value=-1 },
        new StatInfo(){ Hash="MPx_H4LOOT_PAINT_V", Value=677045 },
        new StatInfo(){ Hash="MPx_H4_MISSIONS", Value=65535 },
        new StatInfo(){ Hash="MPx_H4CNF_WEAPONS", Value=2 },
        new StatInfo(){ Hash="MPx_H4CNF_WEP_DISRP", Value=3 },
        new StatInfo(){ Hash="MPx_H4CNF_ARM_DISRP", Value=3 },
        new StatInfo(){ Hash="MPx_H4CNF_HEL_DISRP", Value=3 },
        new StatInfo(){ Hash="MPx_H4CNF_GRAPPEL", Value=-1 },
        new StatInfo(){ Hash="MPx_H4CNF_UNIFORM", Value=-1 },
        new StatInfo(){ Hash="MPx_H4CNF_BOLTCUT", Value=-1 },
        new StatInfo(){ Hash="MPx_H4CNF_TROJAN", Value=4 },
        new StatInfo(){ Hash="MPx_H4_PLAYTHROUGH_STATUS", Value=10 },
    };

    /// <summary>
    /// 佩里科岛抢劫-玩家x2/50%50%分红/困难模式/无精英/不拿保险柜/人均245W（粉钻x1+画作x4）
    /// </summary>
    public static readonly List<StatInfo> H4CNF_2 = new()
    {
        new StatInfo(){ Hash="MPx_H4CNF_BS_GEN", Value=131071 },
        new StatInfo(){ Hash="MPx_H4CNF_BS_ENTR", Value=63 },
        new StatInfo(){ Hash="MPx_H4CNF_BS_ABIL", Value=63 },
        new StatInfo(){ Hash="MPx_H4CNF_APPROACH", Value=-1 },
        new StatInfo(){ Hash="MPx_H4_PROGRESS", Value=131055 },
        new StatInfo(){ Hash="MPx_H4CNF_TARGET", Value=3 },
        new StatInfo(){ Hash="MPx_H4LOOT_PAINT", Value=-1 },
        new StatInfo(){ Hash="MPx_H4LOOT_PAINT_SCOPED", Value=-1 },
        new StatInfo(){ Hash="MPx_H4LOOT_PAINT_V", Value=1034545 },
        new StatInfo(){ Hash="MPx_H4_MISSIONS", Value=65535 },
        new StatInfo(){ Hash="MPx_H4CNF_WEAPONS", Value=2 },
        new StatInfo(){ Hash="MPx_H4CNF_WEP_DISRP", Value=3 },
        new StatInfo(){ Hash="MPx_H4CNF_ARM_DISRP", Value=3 },
        new StatInfo(){ Hash="MPx_H4CNF_HEL_DISRP", Value=3 },
        new StatInfo(){ Hash="MPx_H4CNF_GRAPPEL", Value=-1 },
        new StatInfo(){ Hash="MPx_H4CNF_UNIFORM", Value=-1 },
        new StatInfo(){ Hash="MPx_H4CNF_BOLTCUT", Value=-1 },
        new StatInfo(){ Hash="MPx_H4CNF_TROJAN", Value=4 },
        new StatInfo(){ Hash="MPx_H4_PLAYTHROUGH_STATUS", Value=10 },
    };

    /// <summary>
    /// 佩里科岛抢劫-玩家x3/35%35%30%分红/困难模式/无精英/不拿保险柜/人均245W（粉钻x1+画作x6）
    /// </summary>
    public static readonly List<StatInfo> H4CNF_3 = new()
    {
        new StatInfo(){ Hash="MPx_H4CNF_BS_GEN", Value=131071 },
        new StatInfo(){ Hash="MPx_H4CNF_BS_ENTR", Value=63 },
        new StatInfo(){ Hash="MPx_H4CNF_BS_ABIL", Value=63 },
        new StatInfo(){ Hash="MPx_H4CNF_APPROACH", Value=-1 },
        new StatInfo(){ Hash="MPx_H4_PROGRESS", Value=131055 },
        new StatInfo(){ Hash="MPx_H4CNF_TARGET", Value=3 },
        new StatInfo(){ Hash="MPx_H4LOOT_PAINT", Value=-1 },
        new StatInfo(){ Hash="MPx_H4LOOT_PAINT_SCOPED", Value=-1 },
        new StatInfo(){ Hash="MPx_H4LOOT_PAINT_V", Value=1087424 },
        new StatInfo(){ Hash="MPx_H4_MISSIONS", Value=65535 },
        new StatInfo(){ Hash="MPx_H4CNF_WEAPONS", Value=2 },
        new StatInfo(){ Hash="MPx_H4CNF_WEP_DISRP", Value=3 },
        new StatInfo(){ Hash="MPx_H4CNF_ARM_DISRP", Value=3 },
        new StatInfo(){ Hash="MPx_H4CNF_HEL_DISRP", Value=3 },
        new StatInfo(){ Hash="MPx_H4CNF_GRAPPEL", Value=-1 },
        new StatInfo(){ Hash="MPx_H4CNF_UNIFORM", Value=-1 },
        new StatInfo(){ Hash="MPx_H4CNF_BOLTCUT", Value=-1 },
        new StatInfo(){ Hash="MPx_H4CNF_TROJAN", Value=4 },
        new StatInfo(){ Hash="MPx_H4_PLAYTHROUGH_STATUS", Value=10 },
    };

    /// <summary>
    /// 佩里科岛抢劫-玩家x4/100%分红/困难模式/无精英/不拿保险柜/人均245W（粉钻x1+画作x7）
    /// </summary>
    public static readonly List<StatInfo> H4CNF_4 = new()
    {
        new StatInfo(){ Hash="MPx_H4CNF_BS_GEN", Value=131071 },
        new StatInfo(){ Hash="MPx_H4CNF_BS_ENTR", Value=63 },
        new StatInfo(){ Hash="MPx_H4CNF_BS_ABIL", Value=63 },
        new StatInfo(){ Hash="MPx_H4CNF_APPROACH", Value=-1 },
        new StatInfo(){ Hash="MPx_H4_PROGRESS", Value=131055 },
        new StatInfo(){ Hash="MPx_H4CNF_TARGET", Value=3 },
        new StatInfo(){ Hash="MPx_H4LOOT_PAINT", Value=-1 },
        new StatInfo(){ Hash="MPx_H4LOOT_PAINT_SCOPED", Value=-1 },
        new StatInfo(){ Hash="MPx_H4LOOT_PAINT_V", Value=1213295 },
        new StatInfo(){ Hash="MPx_H4_MISSIONS", Value=65535 },
        new StatInfo(){ Hash="MPx_H4CNF_WEAPONS", Value=2 },
        new StatInfo(){ Hash="MPx_H4CNF_WEP_DISRP", Value=3 },
        new StatInfo(){ Hash="MPx_H4CNF_ARM_DISRP", Value=3 },
        new StatInfo(){ Hash="MPx_H4CNF_HEL_DISRP", Value=3 },
        new StatInfo(){ Hash="MPx_H4CNF_GRAPPEL", Value=-1 },
        new StatInfo(){ Hash="MPx_H4CNF_UNIFORM", Value=-1 },
        new StatInfo(){ Hash="MPx_H4CNF_BOLTCUT", Value=-1 },
        new StatInfo(){ Hash="MPx_H4CNF_TROJAN", Value=4 },
        new StatInfo(){ Hash="MPx_H4_PLAYTHROUGH_STATUS", Value=10 },
    };

    /// <summary>
    /// 赌场抢劫面板重置
    /// </summary>
    public static readonly List<StatInfo> H3OPT = new()
    {
        new StatInfo(){ Hash="MPx_H3OPT_BITSET1", Value=0 },
        new StatInfo(){ Hash="MPx_H3OPT_BITSET0", Value=0 },
        new StatInfo(){ Hash="MPx_H3OPT_POI", Value=0 },
        new StatInfo(){ Hash="MPx_H3OPT_ACCESSPOINTS", Value=0 },
        new StatInfo(){ Hash="MPx_H3OPT_BITSET1", Value=-1 },
        new StatInfo(){ Hash="MPx_H3OPT_BITSET0", Value=-1 },
    };

    /// <summary>
    /// 佩里克岛抢劫面板重置
    /// </summary>
    public static readonly List<StatInfo> H4 = new()
    {
        new StatInfo(){ Hash="MPx_H4_MISSIONS", Value=0 },
        new StatInfo(){ Hash="MPx_H4_PROGRESS", Value=0 },
        new StatInfo(){ Hash="MPx_H4_PLAYTHROUGH_STATUS", Value=0 },
        new StatInfo(){ Hash="MPx_H4CNF_APPROACH", Value=0 },
        new StatInfo(){ Hash="MPx_H4CNF_BS_ENTR", Value=0 },
        new StatInfo(){ Hash="MPx_H4CNF_BS_GEN", Value=0 },
    };

    /// <summary>
    /// 跳过公寓抢劫准备任务
    /// </summary>
    public static readonly List<StatInfo> HEIST_PLANNING_STAGE = new()
    {
        new StatInfo(){ Hash="MPx_HEIST_PLANNING_STAGE", Value=-1 },
    };

    /// <summary>
    /// 取消抢劫并重新开始
    /// </summary>
    public static readonly List<StatInfo> CAS_HEIST_NOTS = new()
    {
        new StatInfo(){ Hash="MPx_CAS_HEIST_NOTS", Value=-1 },
        new StatInfo(){ Hash="MPx_CAS_HEIST_FLOW", Value=-1 },
    };

    /// <summary>
    /// 末日抢劫-1数据泄露（M键-设施管理-关闭/开启策划大屏）
    /// </summary>
    public static readonly List<StatInfo> GANGOPS_FLOW_MISSION_PROG1 = new()
    {
        new StatInfo(){ Hash="MPx_GANGOPS_FLOW_MISSION_PROG", Value=503 },
        new StatInfo(){ Hash="MPx_GANGOPS_HEIST_STATUS", Value=-229383 },
        new StatInfo(){ Hash="MPx_GANGOPS_FLOW_NOTIFICATIONS", Value=1557 },
    };

    /// <summary>
    /// 末日抢劫-2波格丹危机（M键-设施管理-关闭/开启策划大屏）
    /// </summary>
    public static readonly List<StatInfo> GANGOPS_FLOW_MISSION_PROG2 = new()
    {
        new StatInfo(){ Hash="MPx_GANGOPS_FLOW_MISSION_PROG", Value=240 },
        new StatInfo(){ Hash="MPx_GANGOPS_HEIST_STATUS", Value=-229382 },
        new StatInfo(){ Hash="MPx_GANGOPS_FLOW_NOTIFICATIONS", Value=1557 },
    };

    /// <summary>
    /// 末日抢劫-3末日将至（M键-设施管理-关闭/开启策划大屏）
    /// </summary>
    public static readonly List<StatInfo> GANGOPS_FLOW_MISSION_PROG3 = new()
    {
        new StatInfo(){ Hash="MPx_GANGOPS_FLOW_MISSION_PROG", Value=16368 },
        new StatInfo(){ Hash="MPx_GANGOPS_HEIST_STATUS", Value=-229380 },
        new StatInfo(){ Hash="MPx_GANGOPS_FLOW_NOTIFICATIONS", Value=1557 },
    };
    #endregion

    #region CEO
    /// <summary>
    /// CEO办公室满地钱+小金人（银行里必须有2000万以上存款）
    /// </summary>
    public static readonly List<StatInfo> LIFETIME_BUY_UNDERTAKEN = new()
    {
        new StatInfo(){ Hash="MPx_LIFETIME_BUY_UNDERTAKEN", Value=1000 },
        new StatInfo(){ Hash="MPx_LIFETIME_BUY_COMPLETE", Value=1000 },
        new StatInfo(){ Hash="MPx_LIFETIME_SELL_UNDERTAKEN", Value=100 },
        new StatInfo(){ Hash="MPx_LIFETIME_SELL_COMPLETE", Value=100 },
        new StatInfo(){ Hash="MPx_LIFETIME_CONTRA_EARNINGS", Value=28000000 },
    };

    /// <summary>
    /// 取消CEO办公室满地钱+小金人
    /// </summary>
    public static readonly List<StatInfo> LIFETIME_BUY_UNDERTAKEN0 = new()
    {
        new StatInfo(){ Hash="MPx_LIFETIME_BUY_UNDERTAKEN", Value=0 },
        new StatInfo(){ Hash="MPx_LIFETIME_BUY_COMPLETE", Value=0 },
        new StatInfo(){ Hash="MPx_LIFETIME_SELL_UNDERTAKEN", Value=0 },
        new StatInfo(){ Hash="MPx_LIFETIME_SELL_COMPLETE", Value=0 },
        new StatInfo(){ Hash="MPx_LIFETIME_CONTRA_EARNINGS", Value=0 },
    };
    #endregion

    #region 解锁
    /// <summary>
    /// 解锁电话联系人功能
    /// </summary>
    public static readonly List<StatInfo> FM_ACT_PHN = new()
    {
        new StatInfo(){ Hash="MPx_FM_ACT_PHN", Value=-1 },
        new StatInfo(){ Hash="MPx_FM_ACT_PH2", Value=-1 },
        new StatInfo(){ Hash="MPx_FM_ACT_PH3", Value=-1 },
        new StatInfo(){ Hash="MPx_FM_ACT_PH4", Value=-1 },
        new StatInfo(){ Hash="MPx_FM_ACT_PH5", Value=-1 },
        new StatInfo(){ Hash="MPx_FM_VEH_TX1", Value=-1 },
        new StatInfo(){ Hash="MPx_FM_ACT_PH6", Value=-1 },
        new StatInfo(){ Hash="MPx_FM_ACT_PH7", Value=-1 },
        new StatInfo(){ Hash="MPx_FM_ACT_PH8", Value=-1 },
        new StatInfo(){ Hash="MPx_FM_ACT_PH9", Value=-1 },
        new StatInfo(){ Hash="MPx_FM_CUT_DONE", Value=-1 },
        new StatInfo(){ Hash="MPx_FM_CUT_DONE_2", Value=-1 },
    };

    /// <summary>
    /// 限定载具节日涂装
    /// </summary>
    public static readonly List<StatInfo> MPPLY_XMASLIVERIES0 = new()
    {
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES0", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES1", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES2", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES3", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES4", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES5", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES6", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES7", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES8", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES9", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES10", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES11", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES12", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES13", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES14", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES15", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES16", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES17", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES18", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES19", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES20", Value=-1 },
    };

    /// <summary>
    /// 解锁-外星人全能之眼纹身
    /// </summary>
    public static readonly List<StatInfo> TATTOO_FM_CURRENT = new()
    {
        new StatInfo(){ Hash="MPx_TATTOO_FM_CURRENT_32", Value=-1 },
    };

    /// <summary>
    /// 解锁-地堡外星人彩蛋
    /// </summary>
    public static readonly List<StatInfo> LFETIME_BIKER_BUY = new()
    {
        new StatInfo(){ Hash="MPx_LFETIME_BIKER_BUY_COMPLET5", Value=600 },
        new StatInfo(){ Hash="MPx_LFETIME_BIKER_BUY_UNDERTA5", Value=600 },
    };

    /// <summary>
    /// 解锁-全部游艇任务
    /// </summary>
    public static readonly List<StatInfo> YACHT_MISSION_PROG = new()
    {
        new StatInfo(){ Hash="MPx_YACHT_MISSION_PROG", Value=0 },
        new StatInfo(){ Hash="MPx_YACHT_MISSION_FLOW", Value=21845 },
        new StatInfo(){ Hash="MPx_CASINO_DECORATION_GIFT_1", Value=-1 },
    };

    /// <summary>
    /// 解锁-载具金属质感喷漆与铬合金轮毂
    /// </summary>
    public static readonly List<StatInfo> CHAR_FM_CARMOD_1_UNLCK = new()
    {
        new StatInfo(){ Hash="MPx_CHAR_FM_CARMOD_1_UNLCK", Value=-1 },
        new StatInfo(){ Hash="MPx_CHAR_FM_CARMOD_2_UNLCK", Value=-1 },
        new StatInfo(){ Hash="MPx_CHAR_FM_CARMOD_3_UNLCK", Value=-1 },
        new StatInfo(){ Hash="MPx_CHAR_FM_CARMOD_4_UNLCK", Value=-1 },
        new StatInfo(){ Hash="MPx_CHAR_FM_CARMOD_5_UNLCK", Value=-1 },
        new StatInfo(){ Hash="MPx_CHAR_FM_CARMOD_6_UNLCK", Value=-1 },
        new StatInfo(){ Hash="MPx_CHAR_FM_CARMOD_7_UNLCK", Value=-1 },
        new StatInfo(){ Hash="MPx_NUMBER_TURBO_STARTS_IN_RACE", Value=50 },
        new StatInfo(){ Hash="MPx_USJS_COMPLETED", Value=50 },
        new StatInfo(){ Hash="MPx_AWD_FM_RACES_FASTEST_LAP", Value=50 },
        new StatInfo(){ Hash="MPx_NUMBER_SLIPSTREAMS_IN_RACE", Value=100 },
        new StatInfo(){ Hash="MPx_AWD_WIN_CAPTURES", Value=50 },
        new StatInfo(){ Hash="MPx_AWD_DROPOFF_CAP_PACKAGES", Value=1 },
        new StatInfo(){ Hash="MPx_AWD_KILL_CARRIER_CAPTURE", Value=1 },
        new StatInfo(){ Hash="MPx_AWD_FINISH_HEISTS", Value=50 },
        new StatInfo(){ Hash="MPx_AWD_FINISH_HEIST_SETUP_JOB", Value=50 },
        new StatInfo(){ Hash="MPx_AWD_NIGHTVISION_KILLS", Value=1 },
        new StatInfo(){ Hash="MPx_AWD_WIN_LAST_TEAM_STANDINGS", Value=50 },
        new StatInfo(){ Hash="MPx_AWD_ONLY_PLAYER_ALIVE_LTS", Value=50 },
        new StatInfo(){ Hash="MPx_AWD_FMRALLYWONDRIVE", Value=1 },
        new StatInfo(){ Hash="MPx_AWD_FMRALLYWONNAV", Value=1 },
        new StatInfo(){ Hash="MPx_AWD_FMWINSEARACE", Value=1 },
        new StatInfo(){ Hash="MPx_AWD_FMWINAIRRACE", Value=1 },
        new StatInfo(){ Hash="MPx_AWD_RACES_WON", Value=50 },
        new StatInfo(){ Hash="MPx_RACES_WON", Value=50 },
        new StatInfo(){ Hash="MPPLY_TOTAL_RACES_WON", Value=50 },
    };

    /// <summary>
    /// 解锁-GTA线上载具圣诞涂装
    /// </summary>
    public static readonly List<StatInfo> XMASLIVERIES0 = new()
    {
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES0", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES1", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES2", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES3", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES4", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES5", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES6", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES7", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES8", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES9", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES10", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES11", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES12", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES13", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES14", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES15", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES16", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES17", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES18", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES19", Value=-1 },
        new StatInfo(){ Hash="MPPLY_XMASLIVERIES20", Value=-1 },
    };

    /// <summary>
    /// 解锁-竞技场-25级解锁出租车（使用后赢得一场竞技场比赛）
    /// </summary>
    public static readonly List<StatInfo> ARENAWARS_AP_TIER25 = new()
    {
        new StatInfo(){ Hash="MPx_ARENAWARS_AP_TIER", Value=24 },
        new StatInfo(){ Hash="MPx_ARENAWARS_AP", Value=280 },
    };

    /// <summary>
    /// 解锁-竞技场-50级解锁推土机（使用后赢得一场竞技场比赛）
    /// </summary>
    public static readonly List<StatInfo> ARENAWARS_AP_TIER50 = new()
    {
        new StatInfo(){ Hash="MPx_ARENAWARS_AP_TIER", Value=49 },
        new StatInfo(){ Hash="MPx_ARENAWARS_AP", Value=530 },
    };

    /// <summary>
    /// 解锁-竞技场-75级解锁小丑花车（使用后赢得一场竞技场比赛）
    /// </summary>
    public static readonly List<StatInfo> ARENAWARS_AP_TIER75 = new()
    {
        new StatInfo(){ Hash="MPx_ARENAWARS_AP_TIER", Value=74 },
        new StatInfo(){ Hash="MPx_ARENAWARS_AP", Value=780 },
    };

    /// <summary>
    /// 解锁-竞技场-100级解锁垃圾大王（使用后赢得一场竞技场比赛）
    /// </summary>
    public static readonly List<StatInfo> ARENAWARS_AP_TIER100 = new()
    {
        new StatInfo(){ Hash="MPx_ARENAWARS_AP_TIER", Value=99 },
        new StatInfo(){ Hash="MPx_ARENAWARS_AP", Value=1030 },
    };

    /// <summary>
    /// 解锁-竞技场-200级解锁地霸王拖车（使用后赢得一场竞技场比赛）
    /// </summary>
    public static readonly List<StatInfo> ARENAWARS_AP_TIER200 = new()
    {
        new StatInfo(){ Hash="MPx_ARENAWARS_AP_TIER", Value=199 },
        new StatInfo(){ Hash="MPx_ARENAWARS_AP", Value=2030 },
    };

    /// <summary>
    /// 解锁-竞技场-300级解锁混凝土搅拌车（使用后赢得一场竞技场比赛）
    /// </summary>
    public static readonly List<StatInfo> ARENAWARS_AP_TIER300 = new()
    {
        new StatInfo(){ Hash="MPx_ARENAWARS_AP_TIER", Value=299 },
        new StatInfo(){ Hash="MPx_ARENAWARS_AP", Value=3030 },
    };

    /// <summary>
    /// 解锁-竞技场-500级解锁星际码头（使用后赢得一场竞技场比赛）
    /// </summary>
    public static readonly List<StatInfo> ARENAWARS_AP_TIER500 = new()
    {
        new StatInfo(){ Hash="MPx_ARENAWARS_AP_TIER", Value=499 },
        new StatInfo(){ Hash="MPx_ARENAWARS_AP", Value=5030 },
    };

    /// <summary>
    /// 解锁-竞技场-1000级解锁老式拖拉机（使用后赢得一场竞技场比赛）
    /// </summary>
    public static readonly List<StatInfo> ARENAWARS_AP_TIER1000 = new()
    {
        new StatInfo(){ Hash="MPx_ARENAWARS_AP_TIER", Value=999 },
        new StatInfo(){ Hash="MPx_ARENAWARS_AP", Value=10030 },
    };

    /// <summary>
    /// 解锁-竞技场-冲冲猴旅行家购买权限（使用后赢得一场竞技场比赛）
    /// </summary>
    public static readonly List<StatInfo> ARENAWARS_SKILL_LEVEL = new()
    {
        new StatInfo(){ Hash="MPx_ARENAWARS_SKILL_LEVEL", Value=19 },
        new StatInfo(){ Hash="MPx_ARENAWARS_SP", Value=209 },
    };

    /// <summary>
    /// 解锁-解锁CEO特殊载具任务
    /// </summary>
    public static readonly List<StatInfo> AT_FLOW_IMPEXP_NUM = new()
    {
        new StatInfo(){ Hash="MPx_LFETIME_IE_STEAL_STARTED", Value=32 },
        new StatInfo(){ Hash="MPx_AT_FLOW_IMPEXP_NUM", Value=32 },
    };
    #endregion

    #region 其他
    /// <summary>
    /// 解决赌场侦察拍照问题
    /// </summary>
    public static readonly List<StatInfo> H3OPT_ACCESSPOINTS = new()
    {
        new StatInfo(){ Hash="MPx_H3OPT_ACCESSPOINTS", Value=0 },
        new StatInfo(){ Hash="MPx_H3OPT_POI", Value=0 },
    };

    /// <summary>
    /// 清除举报（建议单人战局使用）
    /// </summary>
    public static readonly List<StatInfo> MPPLY_REPORT_STRENGTH = new()
    {
        new StatInfo(){ Hash="MPPLY_REPORT_STRENGTH", Value=0 },
        new StatInfo(){ Hash="MPPLY_COMMEND_STRENGTH", Value=0 },
        new StatInfo(){ Hash="MPPLY_FRIENDLY", Value=0 },
        new StatInfo(){ Hash="MPPLY_HELPFUL", Value=0 },
        new StatInfo(){ Hash="MPPLY_GRIEFING", Value=0 },
        new StatInfo(){ Hash="MPPLY_VC_ANNOYINGME", Value=0 },
        new StatInfo(){ Hash="MPPLY_VC_HATE", Value=0 },
        new StatInfo(){ Hash="MPPLY_TC_ANNOYINGME", Value=0 },
        new StatInfo(){ Hash="MPPLY_TC_HATE", Value=0 },
        new StatInfo(){ Hash="MPPLY_OFFENSIVE_LANGUAGE", Value=0 },
        new StatInfo(){ Hash="MPPLY_OFFENSIVE_TAGPLATE", Value=0 },
        new StatInfo(){ Hash="MPPLY_OFFENSIVE_UGC", Value=0 },
        new StatInfo(){ Hash="MPPLY_BAD_CREW_NAME", Value=0 },
        new StatInfo(){ Hash="MPPLY_BAD_CREW_MOTTO", Value=0 },
        new StatInfo(){ Hash="MPPLY_BAD_CREW_STATUS", Value=0 },
        new StatInfo(){ Hash="MPPLY_BAD_CREW_EMBLEM", Value=0 },
        new StatInfo(){ Hash="MPPLY_EXPLOITS", Value=0 },
        new StatInfo(){ Hash="MPPLY_BECAME_BADSPORT_NUM", Value=0 },
        new StatInfo(){ Hash="MPPLY_DESTROYED_PVEHICLES", Value=0 },
        new StatInfo(){ Hash="MPPLY_BECAME_CHEATER_NUM", Value=0 },
        new StatInfo(){ Hash="MPPLY_BADSPORT_MESSAGE", Value=0 },
        new StatInfo(){ Hash="MPPLY_GAME_EXPLOITS", Value=0 },
        new StatInfo(){ Hash="MPPLY_PLAYER_MENTAL_STATE", Value=0 },
        new StatInfo(){ Hash="MPPLY_PLAYERMADE_TITLE", Value=0 },
        new StatInfo(){ Hash="MPPLY_PLAYERMADE_DESC", Value=0 },
        new StatInfo(){ Hash="MPPLY_ISPUNISHED", Value=0 },
        new StatInfo(){ Hash="MPPLY_WAS_I_BAD_SPORT", Value=0 },
        new StatInfo(){ Hash="MPPLY_WAS_I_CHEATER", Value=0 },
        new StatInfo(){ Hash="MPPLY_CHAR_IS_BADSPORT", Value=0 },
        new StatInfo(){ Hash="MPPLY_OVERALL_BADSPORT", Value=0 },
        new StatInfo(){ Hash="MPPLY_OVERALL_CHEAT", Value=0 },
    };
    #endregion

    /// <summary>
    /// Stat数据分类列表
    /// </summary>
    public static readonly List<StatClass> StatClasses = new()
    {
        new StatClass(){ Name="玩家-护甲全满", StatInfos=MP_CHAR_ARMOUR },
        new StatClass(){ Name="玩家-零食全满", StatInfos=NO_BOUGHT },
        new StatClass(){ Name="玩家-属性全满", StatInfos=SCRIPT_INCREASE },
        new StatClass(){ Name="玩家-隐藏属性全满", StatInfos=CHAR_ABILITY },
        new StatClass(){ Name="玩家-重置隐藏属性", StatInfos=CHAR_ABILITY0 },
        new StatClass(){ Name="玩家-启用性别修改（去重新捏脸）", StatInfos=GENDER_CHANGE_ON },
        new StatClass(){ Name="玩家-关闭性别修改（去重新捏脸）", StatInfos=GENDER_CHANGE_OFF },
        new StatClass(){ Name="玩家-修改等级为1", StatInfos=CHAR_SET_RP1 },
        new StatClass(){ Name="玩家-修改等级为30", StatInfos=CHAR_SET_RP30 },
        new StatClass(){ Name="玩家-修改等级为60", StatInfos=CHAR_SET_RP60 },
        new StatClass(){ Name="玩家-修改等级为90", StatInfos=CHAR_SET_RP90 },
        new StatClass(){ Name="玩家-修改等级为120", StatInfos=CHAR_SET_RP120 },

        new StatClass(){ Name="车友会-修改等级为1", StatInfos=CAR_CLUB_REP1 },
        new StatClass(){ Name="车友会-修改等级为50", StatInfos=CAR_CLUB_REP50 },
        new StatClass(){ Name="车友会-修改等级为100", StatInfos=CAR_CLUB_REP100 },
        new StatClass(){ Name="车友会-修改等级为200", StatInfos=CAR_CLUB_REP200 },
        new StatClass(){ Name="车友会-修改等级为500", StatInfos=CAR_CLUB_REP500 },

        new StatClass(){ Name="资产-补满夜总会人气（使用后切换战局）", StatInfos=CLUB_POPULARITY },
        new StatClass(){ Name="资产-摩托帮和地堡自动进货（使用后切换战局）", StatInfos=PAYRESUPPLYTIMER },
        new StatClass(){ Name="资产-取消摩托帮和地堡自动进货（使用后切换战局）", StatInfos=PAYRESUPPLYTIMER0 },

        new StatClass(){ Name="佩里科岛抢劫-玩家x1/100%分红/困难模式/无精英/不拿保险柜/人均245W（粉钻x1+画作x2）", StatInfos=H4CNF_1 },
        new StatClass(){ Name="佩里科岛抢劫-玩家x2/50%50%分红/困难模式/无精英/不拿保险柜/人均245W（粉钻x1+画作x4）", StatInfos=H4CNF_2 },
        new StatClass(){ Name="佩里科岛抢劫-玩家x3/35%35%30%分红/困难模式/无精英/不拿保险柜/人均245W（粉钻x1+画作x6）", StatInfos=H4CNF_3 },
        new StatClass(){ Name="佩里科岛抢劫-玩家x4/25%25%25%25%分红/困难模式/无精英/不拿保险柜/人均245W（粉钻x1+画作x7）", StatInfos=H4CNF_4 },

        new StatClass(){ Name="抢劫任务-赌场抢劫面板重置", StatInfos=H3OPT },
        new StatClass(){ Name="抢劫任务-解决赌场侦察拍照问题", StatInfos=H3OPT_ACCESSPOINTS },
        new StatClass(){ Name="抢劫任务-佩里克岛抢劫面板重置", StatInfos=H4 },
        new StatClass(){ Name="抢劫任务-跳过公寓抢劫准备任务", StatInfos=HEIST_PLANNING_STAGE },
        new StatClass(){ Name="抢劫任务-取消抢劫并重新开始", StatInfos=CAS_HEIST_NOTS },

        new StatClass(){ Name="末日抢劫-1数据泄露（M键-设施管理-关闭/开启策划大屏）", StatInfos=GANGOPS_FLOW_MISSION_PROG1 },
        new StatClass(){ Name="末日抢劫-2波格丹危机（M键-设施管理-关闭/开启策划大屏）", StatInfos=GANGOPS_FLOW_MISSION_PROG2 },
        new StatClass(){ Name="末日抢劫-3末日将至（M键-设施管理-关闭/开启策划大屏）", StatInfos=GANGOPS_FLOW_MISSION_PROG3 },

        new StatClass(){ Name="CEO-办公室满地钱+小金人（银行里必须有2000万以上存款）", StatInfos=LIFETIME_BUY_UNDERTAKEN },
        new StatClass(){ Name="CEO-取消办公室满地钱+小金人", StatInfos=LIFETIME_BUY_UNDERTAKEN0 },

        new StatClass(){ Name="解锁-电话联系人", StatInfos=FM_ACT_PHN },
        new StatClass(){ Name="解锁-限定载具节日涂装", StatInfos=MPPLY_XMASLIVERIES0 },
        new StatClass(){ Name="解锁-外星人全能之眼纹身", StatInfos=TATTOO_FM_CURRENT },
        new StatClass(){ Name="解锁-地堡外星人彩蛋", StatInfos=LFETIME_BIKER_BUY },
        new StatClass(){ Name="解锁-全部游艇任务", StatInfos=YACHT_MISSION_PROG },
        new StatClass(){ Name="解锁-载具金属质感喷漆与铬合金轮毂", StatInfos=CHAR_FM_CARMOD_1_UNLCK },
        new StatClass(){ Name="解锁-GTA线上载具圣诞涂装", StatInfos=XMASLIVERIES0 },

        new StatClass(){ Name="解锁-竞技场-25级解锁出租车（使用后赢得一场竞技场比赛）", StatInfos=ARENAWARS_AP_TIER25 },
        new StatClass(){ Name="解锁-竞技场-50级解锁推土机（使用后赢得一场竞技场比赛）", StatInfos=ARENAWARS_AP_TIER50 },
        new StatClass(){ Name="解锁-竞技场-75级解锁小丑花车（使用后赢得一场竞技场比赛）", StatInfos=ARENAWARS_AP_TIER75 },
        new StatClass(){ Name="解锁-竞技场-100级解锁垃圾大王（使用后赢得一场竞技场比赛）", StatInfos=ARENAWARS_AP_TIER100 },
        new StatClass(){ Name="解锁-竞技场-200级解锁地霸王拖车（使用后赢得一场竞技场比赛）", StatInfos=ARENAWARS_AP_TIER200 },
        new StatClass(){ Name="解锁-竞技场-300级解锁混凝土搅拌车（使用后赢得一场竞技场比赛）", StatInfos=ARENAWARS_AP_TIER300 },
        new StatClass(){ Name="解锁-竞技场-500级解锁星际码头（使用后赢得一场竞技场比赛）", StatInfos=ARENAWARS_AP_TIER500 },
        new StatClass(){ Name="解锁-竞技场-1000级解锁老式拖拉机（使用后赢得一场竞技场比赛）", StatInfos=ARENAWARS_AP_TIER1000 },
        new StatClass(){ Name="解锁-竞技场-解锁冲冲猴旅行家购买权限（使用后赢得一场竞技场比赛）", StatInfos=ARENAWARS_SKILL_LEVEL },

        new StatClass(){ Name="解锁-解锁CEO特殊载具任务", StatInfos=AT_FLOW_IMPEXP_NUM },

        new StatClass(){ Name="其他-清除举报（建议邀请战局使用）", StatInfos=MPPLY_REPORT_STRENGTH },

    };
}
