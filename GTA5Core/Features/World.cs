using GTA5Core.Native;
using GTA5Core.Offsets;
using GTA5Core.GTA.Rage;
using GTA5Core.GTA.Objects;

namespace GTA5Core.Features;

public static class World
{
    /// <summary>
    /// 设置本地天气
    /// 
    /// -1, Default
    ///  0, Extra Sunny
    ///  1, Clear
    ///  2, Clouds
    ///  3, Smog
    ///  4, Foggy
    ///  5, Overcast
    ///  6, Rain
    ///  7, Thunder
    ///  8, Light Rain
    ///  9, Smoggy Light Rain
    /// 10, Very Light Snow
    /// 11, Windy Snow
    /// 12, Light Snow
    /// 14, Halloween
    /// </summary>
    /// <param name="weatherId">天气Id</param>
    public static void SetLocalWeather(int weatherId)
    {
        if (weatherId == -1)
            Memory.Write(Pointers.WeatherPTR + 0x24, -1);

        if (weatherId == 13)
            Memory.Write(Pointers.WeatherPTR + 0x24, 13);

        Memory.Write(Pointers.WeatherPTR + 0x104, weatherId);
    }

    /// <summary>
    /// 获取CPed指针列表
    /// </summary>
    /// <returns></returns>
    public static List<long> GetCPedPointers()
    {
        var pCPeds = new List<long>();

        var pCPedList = Game.GetCPedList();
        for (var i = 0; i < Base.oMaxPeds; i++)
        {
            var pCPed = Memory.Read<long>(pCPedList + i * 0x10);
            if (!Memory.IsValid(pCPed))
                continue;

            // 跳过玩家
            var pCPlayerInfo = Memory.Read<long>(pCPed + CPed.CPlayerInfo);
            if (Memory.IsValid(pCPlayerInfo))
                continue;

            pCPeds.Add(pCPed);
        }

        return pCPeds;
    }

    /// <summary>
    /// 获取CVehicle指针列表
    /// </summary>
    /// <returns></returns>
    public static List<long> GetCVehiclePointers()
    {
        var pCVehicles = new List<long>();

        var pCVehicleList = Game.GetCVehicleList();
        for (var i = 0; i < Base.oMaxVehicles; i++)
        {
            var pCVehicle = Memory.Read<long>(pCVehicleList + i * 0x10);
            if (!Memory.IsValid(pCVehicle))
                continue;

            pCVehicles.Add(pCVehicle);
        }

        return pCVehicles;
    }

    /// <summary>
    /// 获取Object指针列表
    /// </summary>
    /// <returns></returns>
    public static List<long> GetCObjectPointers()
    {
        var pObjects = new List<long>();

        var pObjectList = Game.GetCObjectList();
        for (var i = 0; i < Base.oMaxObjects; i++)
        {
            var pObject = Memory.Read<long>(pObjectList + i * 0x10);
            if (!Memory.IsValid(pObject))
                continue;

            pObjects.Add(pObject);
        }

        return pObjects;
    }

    /// <summary>
    /// 击杀NPC
    /// </summary>
    /// <param name="isOnlyEnemy">仅敌人</param>
    public static void KillNPC(bool isOnlyEnemy = false)
    {
        var pCPeds = GetCPedPointers();
        foreach (var pCPed in pCPeds)
        {
            if (isOnlyEnemy)
            {
                var oHostility = Memory.Read<byte>(pCPed + CPed.Hostility);
                if (oHostility > 0x01)
                {
                    Memory.Write(pCPed + CPed.Health, 0.0f);
                }
            }
            else
            {
                Memory.Write(pCPed + CPed.Health, 0.0f);
            }
        }
    }

    /// <summary>
    /// 击杀警察
    /// </summary>
    public static void KillPolice()
    {
        var pCPeds = GetCPedPointers();
        foreach (var pCPed in pCPeds)
        {
            var ped_type = Memory.Read<int>(pCPed + CPed.Ragdoll);
            ped_type = ped_type << 11 >> 25;

            if (ped_type == (int)PedType.COP ||
                ped_type == (int)PedType.SWAT ||
                ped_type == (int)PedType.ARMY)
            {
                Memory.Write(pCPed + CPed.Health, 0.0f);
            }
        }
    }

    /// <summary>
    /// 设置载具生命值
    /// </summary>
    /// <param name="pCVehicle"></param>
    public static void SetVehicleHealth(long pCVehicle)
    {
        Memory.Write(pCVehicle + CVehicle.Health, -1.0f);
        Memory.Write(pCVehicle + CVehicle.HealthBody, -1.0f);
        Memory.Write(pCVehicle + CVehicle.HealthPetrolTank, -1.0f);
        Memory.Write(pCVehicle + CVehicle.HealthEngine, -1.0f);
    }

    /// <summary>
    /// 摧毁NPC载具
    /// </summary>
    /// <param name="isOnlyEnemy">仅敌人</param>
    public static void DestroyNPCVehicles(bool isOnlyEnemy = false)
    {
        var pCPeds = GetCPedPointers();
        foreach (var pCPed in pCPeds)
        {
            var pCVehicle = Memory.Read<long>(pCPed + CPed.CVehicle);
            if (!Memory.IsValid(pCVehicle))
                continue;

            if (isOnlyEnemy)
            {
                var oHostility = Memory.Read<byte>(pCPed + CPed.Hostility);
                if (oHostility > 0x01)
                {
                    SetVehicleHealth(pCVehicle);
                }
            }
            else
            {
                SetVehicleHealth(pCVehicle);
            }
        }
    }

    /// <summary>
    /// 摧毁载具（玩家自己的载具也会摧毁）
    /// </summary>
    public static void DestroyVehicles()
    {
        var pCVehicles = GetCVehiclePointers();
        foreach (var pCVehicle in pCVehicles)
        {
            SetVehicleHealth(pCVehicle);
        }
    }

    /// <summary>
    /// 摧毁警察载具
    /// </summary>
    public static void DestroyPoliceVehicles()
    {
        var pCPeds = GetCPedPointers();
        foreach (var pCPed in pCPeds)
        {
            var pCVehicle = Memory.Read<long>(pCPed + CPed.CVehicle);
            if (!Memory.IsValid(pCVehicle))
                continue;

            var ped_type = Memory.Read<int>(pCPed + CPed.Ragdoll);
            ped_type = ped_type << 11 >> 25;

            if (ped_type == (int)PedType.COP ||
                ped_type == (int)PedType.SWAT ||
                ped_type == (int)PedType.ARMY)
            {
                SetVehicleHealth(pCVehicle);
            }
        }
    }

    /// <summary>
    /// 传送NPC
    /// </summary>
    /// <param name="vector3"></param>
    /// <param name="isOnlyEnemy"></param>
    public static void TeleportNPC(Vector3 vector3, bool isOnlyEnemy = false)
    {
        var pCPeds = GetCPedPointers();
        foreach (var pCPed in pCPeds)
        {
            var pCNavigation = Memory.Read<long>(pCPed + CPed.CNavigation);
            if (!Memory.IsValid(pCNavigation))
                continue;

            if (isOnlyEnemy)
            {
                var oHostility = Memory.Read<byte>(pCPed + CPed.Hostility);
                if (oHostility > 0x01)
                {
                    Memory.Write(pCPed + CVehicle.VisualX, vector3);
                    Memory.Write(pCNavigation + CNavigation.PositionX, vector3);
                }
            }
            else
            {
                Memory.Write(pCPed + CVehicle.VisualX, vector3);
                Memory.Write(pCNavigation + CNavigation.PositionX, vector3);
            }
        }
    }

    /// <summary>
    /// 传送NPC到我这里
    /// </summary>
    /// <param name="isOnlyEnemy">仅敌人</param>
    public static void TeleportNPCToMe(bool isOnlyEnemy = false)
    {
        var myPosV3 = Teleport.GetPlayerPosition();
        TeleportNPC(myPosV3, isOnlyEnemy);
    }

    /// <summary>
    /// 传送NPC到太空
    /// </summary>
    /// <param name="isOnlyEnemy">仅敌人</param>
    public static void TeleporNPCTo9999(bool isOnlyEnemy = false)
    {
        TeleportNPC(CCTV.SpacePos, isOnlyEnemy);
    }

    /// <summary>
    /// 移除摄像头
    /// </summary>
    public static void RemoveCCTV()
    {
        var pCObjects = GetCObjectPointers();
        foreach (var pCObject in pCObjects)
        {
            var pCBaseModelInfo = Memory.Read<long>(pCObject + CPed.CBaseModelInfo);
            var hash = Memory.Read<uint>(pCBaseModelInfo + CBaseModelInfo.Hash);

            if (!CCTV.CameraHashs.Contains(hash))
                continue;

            var pCNavigation = Memory.Read<long>(pCObject + CPed.CNavigation);

            Memory.Write(pCObject + CPed.VisualX, CCTV.SpacePos);
            Memory.Write(pCNavigation + CNavigation.PositionX, CCTV.SpacePos);
        }
    }
}
