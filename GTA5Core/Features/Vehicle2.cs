using GTA5Core.Native;
using GTA5Core.Offsets;
using GTA5Core.GTA.Vehicles;

namespace GTA5Core.Features;

public static class Vehicle2
{
    /// <summary>
    /// 具有Mod黑名单的载具列表
    /// </summary>
    private readonly static List<string> ModBlackLists = new()
    {
        "banshee",
        "sentinel",
        "turismo2" ,
        "deveste",
        "hakuchou2",
        "entity3",
        "issi8",
        "brioso",
        "monstrociti"
    };

    /// <summary>
    /// 刷出线上载具
    /// </summary>
    /// <param name="model"></param>
    /// <param name="mods"></param>
    /// <param name="isMax"></param>
    /// <param name="isInRoom"></param>
    /// <returns></returns>
    public static async Task SpawnVehicle(string model, int[] mods, bool isMax, bool isInRoom = false)
    {
        await Task.Run(() =>
        {
            var dist = 5.0f;

            if (string.IsNullOrEmpty(model))
                return;

            var pCPed = Game.GetCPed();
            var vector3 = Memory.Read<Vector3>(pCPed + CPed.VisualX);
            var temp_z = vector3.Z;

            var pCNavigation = Memory.Read<long>(pCPed + CPed.CNavigation);

            var sin = Memory.Read<float>(pCNavigation + CNavigation.RightX);
            var cos = Memory.Read<float>(pCNavigation + CNavigation.ForwardX);

            vector3.X += cos * dist;
            vector3.Y += sin * dist;

            if (isInRoom)
                vector3.Z += 1.0f;
            else
                vector3.Z = -255.0f;

            var plate = Guid.NewGuid().ToString()[..8];
            var hash = STATS.JOATT(model);

            Globals.Set_Global_Value(Base.oVMCreate + 7 + 0, vector3.X);         // 载具坐标x
            Globals.Set_Global_Value(Base.oVMCreate + 7 + 1, vector3.Y);         // 载具坐标y
            Globals.Set_Global_Value(Base.oVMCreate + 7 + 2, vector3.Z);         // 载具坐标z

            Globals.Set_Global_Value(Base.oVMCreate + 27 + 66, hash);            // 载具哈希值

            Globals.Set_Global_Value(Base.oVMCreate + 3, 0);                     // pegasus
            Globals.Set_Global_Value(Base.oVMCreate + 5, 1);                     // 开始生成载具1 can spawn flag must be odd
            Globals.Set_Global_Value(Base.oVMCreate + 2, 1);                     // 开始生成载具2 spawn toggle gets reset to 0 on car spawn

            Globals.Set_Global_String(Base.oVMCreate + 27 + 1, plate);      // License plate  车牌

            // 使用Mods
            if (isMax)
                UseVehicleMods(model, mods);
            else
                RestoreVehicleMods();

            Globals.Set_Global_Value(Base.oVMCreate + 27 + 77, 0xF0400200);      // 载具状态

            Globals.Set_Global_Value(Base.oVMCreate + 27 + 95, 14);              // 拥有载具标志 Ownerflag
            Globals.Set_Global_Value(Base.oVMCreate + 27 + 94, 2);               // 个人载具标志 Personal car ownerflag
        });
    }

    /// <summary>
    /// 使用载具mod
    /// </summary>
    /// <param name="model"></param>
    /// <param name="mods"></param>
    private static void UseVehicleMods(string model, int[] mods)
    {
        // 值设置-1代表载具默认配置

        // 过滤会崩溃的载具mod
        if (ModBlackLists.Contains(model))
            return;

        ////////////////////////////////////////////////////

        // 27 + 10 ~ 27 + 58
        for (var i = 0; i < 48; i++)
        {
            // 27 + 27  (17)  涡轮增压
            // 27 + 28  (18)  武器化标志
            // 27 + 29  (19)  ???
            // 27 + 30  (20)  ???
            // 27 + 31  (21)  ???
            // 27 + 32  (22)  大灯颜色

            Globals.Set_Global_Value(Base.oVMCreate + 27 + 10 + i, mods[i]);
        }

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 58, RandomMod(mods[48]));    // 随机涂装

        ////////////////////////////////////////////////////

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 5, -1);       // 主色调  primary -1 auto 159  
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 6, -1);       // 副色调  secondary -1 auto 159  
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 7, -1);       // 珠光色  pearlescent  

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 8, -1);       // 车轮颜色 wheel color  
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 69, -1);      // 车轮类型 Wheel type  
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 33, -1);      // 车轮选择 wheel selection  

        //Globals.WriteGA(Base.oVMCreate + 27 + 15, mods[5]);         // 主武器 primary weapon
        //Globals.WriteGA(Base.oVMCreate + 27 + 30, mods[20]);        // 副武器 secondary weapon

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 24, -1);      // 喇叭

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 27, 1);       // Turbo (0-1)  涡轮增压
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 28, 1);       // weaponised ownerflag

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 30, -1);      // 烧胎烟雾
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 32, -1);      // 氙气车灯 (0-14)

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 60, 1);       // landinggear/vehstate  起落架/载具状态
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 62, RandomMod(255));      // 烧胎烟雾颜色  Tire smoke color R  
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 63, RandomMod(255));      // G
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 64, RandomMod(255));      // B
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 65, RandomMod(6));        // 窗户  Window tint 0-6  

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 74, RandomMod(255));      // 霓虹灯颜色  Red Neon Amount 1-255 100%-0%  
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 75, RandomMod(255));      // G
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 76, RandomMod(255));      // B
    }

    /// <summary>
    /// 恢复载具Mods为默认
    /// </summary>
    private static void RestoreVehicleMods()
    {
        // 值设置-1代表载具默认配置

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 5, -1);       // 主色调  primary -1 auto 159  
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 6, -1);       // 副色调  secondary -1 auto 159  
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 7, -1);       // 珠光色  pearlescent  

        // 27 + 10 ~ 27 + 58
        for (var i = 0; i < 49; i++)
        {
            Globals.Set_Global_Value(Base.oVMCreate + 27 + 10 + i, -1);
        }

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 8, -1);       // 车轮颜色 wheel color  
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 69, -1);      // 车轮类型 Wheel type  
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 33, -1);      // 车轮选择 wheel selection  

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 24, -1);      // 喇叭

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 27, -1);      // Turbo (0-1)  涡轮增压
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 28, -1);      // weaponised ownerflag

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 30, -1);      // 烧胎烟雾
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 32, -1);      // 氙气车灯 (0-14)

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 60, -1);      // landinggear/vehstate  起落架/载具状态
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 62, -1);      // 烧胎烟雾颜色  Tire smoke color R  
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 63, -1);      // G
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 64, -1);      // B
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 65, -1);      // 窗户  Window tint 0-6  

        Globals.Set_Global_Value(Base.oVMCreate + 27 + 74, -1);      // 霓虹灯颜色  Red Neon Amount 1-255 100%-0%  
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 75, -1);      // G
        Globals.Set_Global_Value(Base.oVMCreate + 27 + 76, -1);      // B
    }

    /// <summary>
    /// 获取随机值
    /// </summary>
    /// <param name="mod"></param>
    /// <returns></returns>
    private static int RandomMod(int mod)
    {
        return mod > 0 ? new Random().Next(0, mod + 1) : mod;
    }

    /// <summary>
    /// 通过Hash值查找载具信息
    /// </summary>
    /// <param name="hash"></param>
    /// <returns></returns>
    public static VehicleInfo FindVehicleNameByHash(long hash)
    {
        var result = VehicleHash.AllVehicles.Find(v => v.Hash == hash);
        if (result != null)
            return result;

        return null;
    }
}
