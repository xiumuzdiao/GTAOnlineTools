namespace GTA5Core.GTA.Teleports;

public static class TeleportData
{
    public static readonly List<TeleportInfo> Common = new()
    {
        new TeleportInfo(){ Name="洛圣都改车王", X=-365.425f, Y=-131.809f, Z=-225.0f },
        new TeleportInfo(){ Name="洛圣都机场", X=-1336.0f, Y=-3044.0f, Z=-225.0f },
        new TeleportInfo(){ Name="赛诺拉沙漠机场", X=1747.0f, Y=3273.0f, Z=-225.0f },
        new TeleportInfo(){ Name="乞力耶德山", X=489.979f, Y=5587.527f, Z=794.3f },
    };

    public static readonly List<TeleportInfo> Indoor = new()
    {
        new TeleportInfo(){ Name="FIB大楼楼顶", X=136.0f, Y=-750.0f, Z=262.0f },
        new TeleportInfo(){ Name="服装厂", X=712.716f, Y=-962.906f, Z=30.6f },
        new TeleportInfo(){ Name="富兰克林家", X=7.119f, Y=536.615f, Z=176.2f },
        new TeleportInfo(){ Name="麦克家", X=-813.603f, Y=179.474f, Z=72.5f },
        new TeleportInfo(){ Name="崔佛家", X=1972.610f, Y=3817.040f, Z=33.65f },
        new TeleportInfo(){ Name="丹尼斯阿姨家", X=-14.380f, Y=-1438.510f, Z=31.3f },
        new TeleportInfo(){ Name="弗洛伊德家", X=-1151.770f, Y=-1518.138f, Z=10.85f },
        new TeleportInfo(){ Name="莱斯特家", X=1273.898f, Y=-1719.304f, Z=54.8f },
        new TeleportInfo(){ Name="脱衣舞俱乐部", X=97.271f, Y=-1290.994f, Z=29.45f },
        new TeleportInfo(){ Name="银行金库（太平洋标准）", X=255.85f, Y=217.0f, Z=101.9f },
        new TeleportInfo(){ Name="喜剧俱乐部", X=378.100f, Y=-999.964f, Z=-98.6f },
        new TeleportInfo(){ Name="人道实验室", X=3614.394f, Y=3744.803f, Z=28.9f },
        new TeleportInfo(){ Name="人道实验室地道", X=3525.201f, Y=3709.625f, Z=21.2f },
        new TeleportInfo(){ Name="IAA办公室", X=113.568f, Y=-619.001f, Z=206.25f },
        new TeleportInfo(){ Name="刑讯室", X=142.746f, Y=-2201.189f, Z=4.9f },
        new TeleportInfo(){ Name="军事基地高塔", X=-2358.132f, Y=3249.754f, Z=101.65f },
        new TeleportInfo(){ Name="矿井", X=-595.342f, Y=2086.008f, Z=131.6f },
    };

    public static readonly List<TeleportInfo> Mission = new()
    {
        new TeleportInfo(){ Name="虎鲸内部座椅", X=1560.086f, Y=381.474f, Z=-49.685f },
        new TeleportInfo(){ Name="海岛正门入口", X=4977.915f, Y=-5707.789f, Z=19.886f },
        new TeleportInfo(){ Name="海岛主要目标", X=5006.896f, Y=-5755.963f, Z=15.487f },
        new TeleportInfo(){ Name="海岛正门出口", X=4992.854f, Y=-5718.537f, Z=19.880f },
        new TeleportInfo(){ Name="海洋安全场所", X=4771.792f, Y=-6166.055f, Z=-40.266f },
    };

    public static readonly List<TeleportClass> TeleportClasses = new()
    {
        new TeleportClass(){ Icon="\xe616", Name="常用地点", TeleportInfos=Common },
        new TeleportClass(){ Icon="\xe616", Name="室内场景", TeleportInfos=Indoor },
        new TeleportClass(){ Icon="\xe616", Name="任务地点", TeleportInfos=Mission },
    };
}

public class TeleportClass
{
    public string Icon { get; set; }
    public string Name { get; set; }
    public List<TeleportInfo> TeleportInfos { get; set; }
}

public class TeleportInfo
{
    public string Name { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
}
