namespace GTA5Core.GTA.Onlines;

public static class OnlineData
{
    public class OnlineInfo
    {
        public string Name;
        public int Value;
    }

    public static readonly List<OnlineInfo> Blips = new()
    {
        new OnlineInfo(){ Name="街头毒贩", Value=47 },
        new OnlineInfo(){ Name="游艇", Value=455 },
        new OnlineInfo(){ Name="特种货物仓库", Value=473 },
        new OnlineInfo(){ Name="办公室", Value=475 },
        new OnlineInfo(){ Name="摩托帮会所", Value=492 },
        new OnlineInfo(){ Name="大麻种植场", Value=496 },
        new OnlineInfo(){ Name="可卡因作坊", Value=497 },
        new OnlineInfo(){ Name="证件伪造办公室", Value=498 },
        new OnlineInfo(){ Name="冰毒实验室", Value=499 },
        new OnlineInfo(){ Name="假钞工厂", Value=500 },
        new OnlineInfo(){ Name="载具仓库", Value=524 },
        new OnlineInfo(){ Name="地堡", Value=557 },
        new OnlineInfo(){ Name="机动作战中心", Value=564 },
        new OnlineInfo(){ Name="隐藏包裹", Value=568 },
        new OnlineInfo(){ Name="机库", Value=569 },
        new OnlineInfo(){ Name="复仇者", Value=589 },
        new OnlineInfo(){ Name="设施", Value=590 },
        new OnlineInfo(){ Name="夜总会", Value=614 },
        new OnlineInfo(){ Name="恐霸", Value=632 },
        new OnlineInfo(){ Name="竞技场工作室", Value=643 },
        new OnlineInfo(){ Name="赌场", Value=679 },
        new OnlineInfo(){ Name="游戏厅", Value=740 },
        new OnlineInfo(){ Name="虎鲸", Value=760 },
        new OnlineInfo(){ Name="洛圣都车友会", Value=777 },
        new OnlineInfo(){ Name="改装铺", Value=779 },
        new OnlineInfo(){ Name="录音A工作室", Value=819 },
        new OnlineInfo(){ Name="事务所", Value=826 },
        new OnlineInfo(){ Name="拉机能量高空跳伞", Value=829 },
        new OnlineInfo(){ Name="豪华汽车", Value=830 },
        new OnlineInfo(){ Name="顶级豪华车业", Value=832 },
        new OnlineInfo(){ Name="致幻剂实验室", Value=840 },
        new OnlineInfo(){ Name="杰拉德包裹", Value=842 },
        new OnlineInfo(){ Name="枪支厢型车", Value=844 },
        new OnlineInfo(){ Name="藏匿屋", Value=845 },
        new OnlineInfo(){ Name="怪胎店", Value=847 },
        new OnlineInfo(){ Name="好麦坞车友俱乐部", Value=857 },
    };

    public static readonly List<OnlineInfo> Sessions = new()
    {
        new OnlineInfo(){ Name="离开线上模式", Value=-1 },
        new OnlineInfo(){ Name="公共战局", Value=0 },
        new OnlineInfo(){ Name="创建公共战局", Value=1 },
        new OnlineInfo(){ Name="私人帮会战局", Value=2 },
        new OnlineInfo(){ Name="帮会战局", Value=3 },
        new OnlineInfo(){ Name="加入好友", Value=9 },
        new OnlineInfo(){ Name="私人好友战局", Value=6 },
        new OnlineInfo(){ Name="单人战局", Value=10 },
        new OnlineInfo(){ Name="仅限邀请战局", Value=11 },
        new OnlineInfo(){ Name="加入帮会伙伴", Value=12 },
    };

    public static readonly List<OnlineInfo> RPxNs = new()
    {
        new OnlineInfo(){ Name="RPx1", Value=1 },
        new OnlineInfo(){ Name="RPx2", Value=2 },
        new OnlineInfo(){ Name="RPx5", Value=5 },
        new OnlineInfo(){ Name="RPx10", Value=10 },
        new OnlineInfo(){ Name="RPx20", Value=20 },
        new OnlineInfo(){ Name="RPx50", Value=50 },
        new OnlineInfo(){ Name="RPx100", Value=100 },
        new OnlineInfo(){ Name="RPx500", Value=500 },
        new OnlineInfo(){ Name="RPx1000", Value=1000 },
    };

    public static readonly List<OnlineInfo> REPxNs = new()
    {
        new OnlineInfo(){ Name="REPx1", Value=1 },
        new OnlineInfo(){ Name="REPx2", Value=2 },
        new OnlineInfo(){ Name="REPx5", Value=5 },
        new OnlineInfo(){ Name="REPx10", Value=10 },
        new OnlineInfo(){ Name="REPx20", Value=20 },
        new OnlineInfo(){ Name="REPx50", Value=50 },
        new OnlineInfo(){ Name="REPx100", Value=100 },
        new OnlineInfo(){ Name="REPx500", Value=500 },
        new OnlineInfo(){ Name="REPx1000", Value=1000 },
    };

    // Set Global_1946791 to 1, otherwise you'll see regular crates.
    // Set Global_1946637 to one of these: 2, 4, 6, 7, 8, 9.
    // Now you'll see the unique cargo in your terrorbyte.

    public static readonly List<OnlineInfo> CEOCargos = new()
    {
        new OnlineInfo(){ Name="医疗用品", Value=0 },
        new OnlineInfo(){ Name="烟酒", Value=1 },
        new OnlineInfo(){ Name="古董艺术品", Value=2 },
        new OnlineInfo(){ Name="电子产品", Value=3 },
        new OnlineInfo(){ Name="武器弹药", Value=4 },
        new OnlineInfo(){ Name="迷幻药", Value=5 },
        new OnlineInfo(){ Name="宝石", Value=6 },
        new OnlineInfo(){ Name="动物材料", Value=7 },
        new OnlineInfo(){ Name="仿制品", Value=8 },
        new OnlineInfo(){ Name="珠宝", Value=9 },
        new OnlineInfo(){ Name="银块", Value=10 },
    };

    public static readonly List<OnlineInfo> CEOSpecialCargos = new()
    {
        new OnlineInfo(){ Name="古董艺术品（华丽彩蛋）", Value=2 },
        new OnlineInfo(){ Name="武器弹药（黄金火神机枪）", Value=4 },
        new OnlineInfo(){ Name="宝石（一大颗钻石）", Value=6 },
        new OnlineInfo(){ Name="动物材料（稀有皮草）", Value=7 },
        new OnlineInfo(){ Name="仿制品（电影胶卷）", Value=8 },
        new OnlineInfo(){ Name="珠宝（稀有怀表）", Value=9 },
    };

    public static readonly List<OnlineInfo> MerryWeatherServices = new()
    {
        new OnlineInfo(){ Name="请求弹药空投", Value=891 },       // NETWORK::NETWORK_IS_SCRIPT_ACTIVE("AM_AMMO_DROP", -1, true, 0)
        new OnlineInfo(){ Name="请求重型防弹装甲", Value=901 },    // NETWORK::NETWORK_IS_SCRIPT_ACTIVE("AM_AMMO_DROP", PLAYER::PLAYER_ID(), true, 0)
        new OnlineInfo(){ Name="请求牛鲨睾酮", Value=899 },       // NETWORK::NETWORK_IS_SCRIPT_ACTIVE("AM_BRU_BOX", PLAYER::PLAYER_ID(), true, 0)
        new OnlineInfo(){ Name="请求船只接送", Value=892 },       // NETWORK::NETWORK_IS_SCRIPT_ACTIVE("AM_BOAT_TAXI", PLAYER::PLAYER_ID(), true, 0)
        new OnlineInfo(){ Name="请求直升机接送", Value=893 },      // NETWORK::NETWORK_IS_SCRIPT_ACTIVE("AM_HELI_TAXI", -1, true, 0)
    };

    public static readonly List<OnlineInfo> LocalWeathers = new()
    {
        new OnlineInfo(){ Name="默认", Value=-1 },
        new OnlineInfo(){ Name="格外晴朗", Value=0 },
        new OnlineInfo(){ Name="晴朗", Value=1 },
        new OnlineInfo(){ Name="多云", Value=2 },
        new OnlineInfo(){ Name="阴霾", Value=3 },
        new OnlineInfo(){ Name="大雾", Value=4 },
        new OnlineInfo(){ Name="阴天", Value=5 },
        new OnlineInfo(){ Name="下雨", Value=6 },
        new OnlineInfo(){ Name="雷雨", Value=7 },
        new OnlineInfo(){ Name="雨转晴", Value=8 },
        new OnlineInfo(){ Name="阴雨", Value=9 },
        new OnlineInfo(){ Name="下雪", Value=10 },
        new OnlineInfo(){ Name="暴雪", Value=11 },
        new OnlineInfo(){ Name="小雪", Value=12 },
        new OnlineInfo(){ Name="圣诞", Value=13 },
        new OnlineInfo(){ Name="万圣节", Value=14 },
    };

    public static readonly List<OnlineInfo> ImpactExplosions = new()
    {
        new OnlineInfo(){ Name="### 未选择 ###", Value=-1 },
        new OnlineInfo(){ Name="默认", Value=-1 },
        new OnlineInfo(){ Name="手榴弹", Value=0 },
        new OnlineInfo(){ Name="榴弹发射器", Value=1 },
        new OnlineInfo(){ Name="粘弹", Value=2 },
        new OnlineInfo(){ Name="燃烧瓶", Value=3 },
        new OnlineInfo(){ Name="火箭弹", Value=4 },
        new OnlineInfo(){ Name="坦克炮弹", Value=5 },
        new OnlineInfo(){ Name="火球爆炸", Value=6 },
        new OnlineInfo(){ Name="汽车爆炸", Value=7 },
        new OnlineInfo(){ Name="飞机爆炸", Value=8 },
        new OnlineInfo(){ Name="加油站爆炸", Value=9 },
        new OnlineInfo(){ Name="摩托车爆炸", Value=10 },
        new OnlineInfo(){ Name="蒸汽", Value=11 },
        new OnlineInfo(){ Name="火焰", Value=12 },
        new OnlineInfo(){ Name="消防栓", Value=13 },
        new OnlineInfo(){ Name="燃气罐", Value=14 },
        new OnlineInfo(){ Name="小艇", Value=15 },
        new OnlineInfo(){ Name="船只", Value=16 },
        new OnlineInfo(){ Name="卡车爆炸", Value=17 },
        new OnlineInfo(){ Name="MKⅡ爆炸子弹", Value=18 },
        new OnlineInfo(){ Name="烟雾弹发射器", Value=19 },
        new OnlineInfo(){ Name="烟雾弹", Value=20 },
        new OnlineInfo(){ Name="毒气弹", Value=21 },
        new OnlineInfo(){ Name="信号弹", Value=22 },
        new OnlineInfo(){ Name="带特效的爆炸", Value=23 },
        new OnlineInfo(){ Name="灭火器", Value=24 },
        new OnlineInfo(){ Name="可调榴弹", Value=25 },
        new OnlineInfo(){ Name="火车爆炸", Value=26 },
        new OnlineInfo(){ Name="油桶", Value=27 },
        new OnlineInfo(){ Name="丙烷", Value=28 },
        new OnlineInfo(){ Name="飞艇", Value=29 },
        new OnlineInfo(){ Name="火焰 ", Value=30 },
        new OnlineInfo(){ Name="油罐车", Value=31 },
        new OnlineInfo(){ Name="飞机导弹", Value=32 },
        new OnlineInfo(){ Name="汽车导弹", Value=33 },
        new OnlineInfo(){ Name="燃油泵", Value=34 },
        new OnlineInfo(){ Name="鸟屎", Value=35 },
        new OnlineInfo(){ Name="电磁步枪", Value=36 },
        new OnlineInfo(){ Name="飞艇爆炸", Value=37 },
        new OnlineInfo(){ Name="烟花发射器", Value=38 },
        new OnlineInfo(){ Name="雪球", Value=39 },
        new OnlineInfo(){ Name="地雷", Value=40 },
        new OnlineInfo(){ Name="女武神机炮", Value=41 },
        new OnlineInfo(){ Name="游艇防御", Value=42 },
        new OnlineInfo(){ Name="爆破筒", Value=43 },
        new OnlineInfo(){ Name="汽车炸弹", Value=44 },
        new OnlineInfo(){ Name="MK2 定向导弹", Value=45 },
        new OnlineInfo(){ Name="APC炮弹", Value=46 },
        new OnlineInfo(){ Name="飞机集束炸弹", Value=47 },
        new OnlineInfo(){ Name="飞机瓦斯", Value=48 },
        new OnlineInfo(){ Name="飞机燃烧弹", Value=49 },
        new OnlineInfo(){ Name="飞机炸弹", Value=50 },
        new OnlineInfo(){ Name="鱼雷", Value=51 },
        new OnlineInfo(){ Name="水下鱼雷", Value=52 },
        new OnlineInfo(){ Name="邦布须卡炮", Value=53 },
        new OnlineInfo(){ Name="第二集束炸弹", Value=54 },
        new OnlineInfo(){ Name="猎杀者连发导弹", Value=55 },
        new OnlineInfo(){ Name="FH-1 猎杀者 机炮", Value=56 },
        new OnlineInfo(){ Name="流氓大炮", Value=57 },
        new OnlineInfo(){ Name="水下地雷", Value=58 },
        new OnlineInfo(){ Name="天基炮", Value=59 },
        new OnlineInfo(){ Name="轨道炮", Value=60 },
        new OnlineInfo(){ Name="MK2爆炸子弹霰弹枪", Value=61 },
        new OnlineInfo(){ Name="MK2导弹", Value=62 },
        new OnlineInfo(){ Name="武装坦帕迫击炮", Value=63 },
        new OnlineInfo(){ Name="追踪地雷", Value=64 },
        new OnlineInfo(){ Name="电磁脉冲地雷", Value=65 },
        new OnlineInfo(){ Name="尖刺式地雷", Value=66 },
        new OnlineInfo(){ Name="感应式地雷", Value=67 },
        new OnlineInfo(){ Name="定时地雷", Value=68 },
        new OnlineInfo(){ Name="无人机自爆", Value=69 },
        new OnlineInfo(){ Name="原子能枪", Value=70 },
        new OnlineInfo(){ Name="跳雷", Value=71 },
        new OnlineInfo(){ Name="脚本化导弹", Value=72 },
        new OnlineInfo(){ Name="RC坦克火箭", Value=73 },
        new OnlineInfo(){ Name="爆炸水", Value=74 },
        new OnlineInfo(){ Name="二次爆炸水", Value=75 },
        new OnlineInfo(){ Name="灭火器", Value=76 },
        new OnlineInfo(){ Name="灭火器1", Value=77 },
        new OnlineInfo(){ Name="灭火器2", Value=78 },
        new OnlineInfo(){ Name="灭火器3", Value=79 },
        new OnlineInfo(){ Name="灭火器4", Value=80 },
        new OnlineInfo(){ Name="大脚本导弹", Value=81 },
        new OnlineInfo(){ Name="潜艇导弹", Value=82 },
        new OnlineInfo(){ Name="EMP发射器EMP", Value=83 },
        new OnlineInfo(){ Name="轨道炮MX3", Value=84 },
        new OnlineInfo(){ Name="无伤害爆炸", Value=99 },
    };

    public static readonly List<OnlineInfo> VehicleExtras = new()
    {
        new OnlineInfo(){ Name="### 未选择 ###", Value=-1 },
        new OnlineInfo(){ Name="默认", Value=0x00 },
        new OnlineInfo(){ Name="载具跳跃", Value=0x20 },
        new OnlineInfo(){ Name="火箭推进", Value=0x40 },
        new OnlineInfo(){ Name="载具降落伞", Value=0x100 },
        new OnlineInfo(){ Name="跳台魔宝", Value=0x200 },
        new OnlineInfo(){ Name="载具跳跃+火箭推进", Value=0x60 },
        new OnlineInfo(){ Name="载具跳跃+载具降落伞", Value=0x120 },
        new OnlineInfo(){ Name="火箭推进+载具降落伞", Value=0x140 },
        new OnlineInfo(){ Name="载具跳跃+火箭推进+载具降落伞", Value=0x160 },
        new OnlineInfo(){ Name="火箭推进+载具降落伞+跳台魔宝", Value=0x340 },
        new OnlineInfo(){ Name="载具跳跃+火箭推进+载具降落伞+跳台魔宝", Value=0x360 },
    };
}
