using GTA5Core.Native;
using GTA5Core.Offsets;

namespace GTA5Core.Features;

public static class Game
{
    /// <summary>
    /// 获取 CPed 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCPed()
    {
        var pCPedFactory = Memory.Read<long>(Pointers.WorldPTR);
        return Memory.Read<long>(pCPedFactory + CPedFactory.CPed);
    }

    /// <summary>
    /// 获取 CPlayerInfo 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCPlayerInfo()
    {
        var pCPed = GetCPed();
        return Memory.Read<long>(pCPed + CPed.CPlayerInfo);
    }

    /// <summary>
    /// 获取 CVehicle 指针
    /// </summary>
    /// <param name="pCVehicle"></param>
    /// <returns></returns>
    public static bool GetCVehicle(out long pCVehicle)
    {
        pCVehicle = 0;

        var pCPed = GetCPed();
        var mInVehicle = Memory.Read<byte>(pCPed + CPed.InVehicle);

        if (mInVehicle == 0x01)
        {
            pCVehicle = Memory.Read<long>(pCPed + CPed.CVehicle);
            return true;
        }

        return false;
    }

    /// <summary>
    /// 获取 CPedWeaponManager 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCPedWeaponManager()
    {
        var pCPed = GetCPed();
        return Memory.Read<long>(pCPed + CPed.CPedWeaponManager);
    }

    /// <summary>
    /// 获取 CPedInventory 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCPedInventory()
    {
        var pCPed = GetCPed();
        return Memory.Read<long>(pCPed + CPed.CPedInventory);
    }

    /// <summary>
    /// 获取 CWeaponInfo 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCWeaponInfo()
    {
        var pCPedWeaponManager = GetCPedWeaponManager();
        return Memory.Read<long>(pCPedWeaponManager + CPedWeaponManager.CWeaponInfo);
    }

    /// <summary>
    /// 获取 CReplayInterface 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCReplayInterface()
    {
        return Memory.Read<long>(Pointers.ReplayInterfacePTR);
    }

    /// <summary>
    /// 获取 CPedInterface 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCPedInterface()
    {
        var pCReplayInterface = GetCReplayInterface();
        return Memory.Read<long>(pCReplayInterface + CReplayInterface.CPedInterface);
    }

    /// <summary>
    /// 获取 CVehicleInterface 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCVehicleInterface()
    {
        var pCReplayInterface = GetCReplayInterface();
        return Memory.Read<long>(pCReplayInterface + CReplayInterface.CVehicleInterface);
    }

    /// <summary>
    /// 获取 CObjectInterface 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCObjectInterface()
    {
        var pCReplayInterface = GetCReplayInterface();
        return Memory.Read<long>(pCReplayInterface + CReplayInterface.CObjectInterface);
    }

    /// <summary>
    /// 获取 CPedList 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCPedList()
    {
        var pCPedInterface = GetCPedInterface();
        return Memory.Read<long>(pCPedInterface + CPedInterface.CPedList);
    }

    /// <summary>
    /// 获取 CVehicleList 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCVehicleList()
    {
        var pCVehicleInterface = GetCVehicleInterface();
        return Memory.Read<long>(pCVehicleInterface + CVehicleInterface.CVehicleList);
    }

    /// <summary>
    /// 获取 CObjectList 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCObjectList()
    {
        var pCObjectInterface = GetCObjectInterface();
        return Memory.Read<long>(pCObjectInterface + CObjectInterface.CObjectList);
    }
}
