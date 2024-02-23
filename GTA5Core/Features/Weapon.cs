using GTA5Core.Native;
using GTA5Core.Offsets;

namespace GTA5Core.Features;

public static class Weapon
{
    /// <summary>
    /// 补满当前武器弹药
    /// </summary>
    public static void FillCurrentAmmo()
    {
        var pCWeaponInfo = Game.GetCWeaponInfo();
        if (!Memory.IsValid(pCWeaponInfo))
            return;

        var pCAmmoInfo = Memory.Read<long>(pCWeaponInfo + CWeaponInfo.CAmmoInfo);
        if (!Memory.IsValid(pCAmmoInfo))
            return;

        var getMaxAmmo = Memory.Read<int>(pCAmmoInfo + 0x28);

        long offset_1 = pCAmmoInfo;
        long offset_2;
        byte ammo_type;

        do
        {
            offset_1 = Memory.Read<long>(offset_1 + 0x08);
            offset_2 = Memory.Read<long>(offset_1 + 0x00);

            if (!Memory.IsValid(offset_1) ||
                !Memory.IsValid(offset_2))
                return;

            ammo_type = Memory.Read<byte>(offset_2 + 0x0C);

        } while (ammo_type == 0x00);

        Memory.Write(offset_2 + 0x18, getMaxAmmo);
    }

    /// <summary>
    /// 补满全部武器弹药
    /// </summary>
    public static void FillAllAmmo()
    {
        var pCPedInventory = Game.GetCPedInventory();
        if (!Memory.IsValid(pCPedInventory))
            return;

        var pWeapon = Memory.Read<long>(pCPedInventory + 0x48);
        if (!Memory.IsValid(pWeapon))
            return;

        var count = 0;
        var offset_1 = Memory.Read<long>(pWeapon + count * 0x08);
        var offset_2 = Memory.Read<long>(offset_1 + 0x08);

        while (Memory.IsValid(offset_1) && Memory.IsValid(offset_2))
        {
            var ammo_1 = Memory.Read<int>(offset_2 + 0x28);
            var ammo_2 = Memory.Read<int>(offset_2 + 0x34);

            var max_ammo = Math.Max(ammo_1, ammo_2);

            if (max_ammo <= 0 || max_ammo > 9999)
                continue;

            Memory.Write(offset_1 + 0x20, max_ammo);

            count++;
            offset_1 = Memory.Read<long>(pWeapon + count * 0x08);
            offset_2 = Memory.Read<long>(offset_1 + 0x08);
        }
    }

    /// <summary>
    /// 弹药编辑（字节），默认0x00，无限弹药0x01，无限弹夹0x02，无限弹药和弹夹0x03
    /// </summary>
    public static void AmmoModifier(byte flag)
    {
        var pCPedInventory = Game.GetCPedInventory();
        if (!Memory.IsValid(pCPedInventory))
            return;

        Memory.Write(pCPedInventory + CPedInventory.AmmoModifier, flag);
    }

    /// <summary>
    /// 无后坐力（普通武器 + 狙击枪）
    /// </summary>
    public static void NoRecoil()
    {
        var pCPedWeaponManager = Game.GetCPedWeaponManager();
        if (!Memory.IsValid(pCPedWeaponManager))
            return;

        var pCWeaponInfo = Memory.Read<long>(pCPedWeaponManager + CPedWeaponManager.CWeaponInfo);
        if (!Memory.IsValid(pCWeaponInfo))
            return;

        // 普通武器后坐力
        Memory.Write(pCWeaponInfo + CWeaponInfo.Recoil, 0.0f);

        var offset = Memory.Read<long>(pCPedWeaponManager + 0x78);
        if (!Memory.IsValid(offset))
            return;

        offset = Memory.Read<long>(offset + 0x20);
        offset = Memory.Read<long>(offset + 0x160);
        offset = Memory.Read<long>(offset + 0x00);
        offset = Memory.Read<long>(offset + 0x138);
        offset = Memory.Read<long>(offset + 0x08);
        if (!Memory.IsValid(offset))
            return;

        // 狙击枪后坐力
        Memory.Write(offset + 0x4C, 0.0f);
    }

    /// <summary>
    /// 无子弹扩散
    /// </summary>
    public static void NoSpread()
    {
        var pCWeaponInfo = Game.GetCWeaponInfo();
        if (!Memory.IsValid(pCWeaponInfo))
            return;

        Memory.Write(pCWeaponInfo + CWeaponInfo.Spread, 0.0f);
    }

    /// <summary>
    /// 启用子弹类型（字节），0x02:Fists，0x03:Bullet，0x05:Explosion
    /// </summary>
    public static void ImpactType(byte type)
    {
        var pCWeaponInfo = Game.GetCWeaponInfo();
        if (!Memory.IsValid(pCWeaponInfo))
            return;

        Memory.Write(pCWeaponInfo + CWeaponInfo.ImpactType, type);
    }

    /// <summary>
    /// 设置子弹类型
    /// </summary>
    public static void ImpactExplosion(int id)
    {
        var pCWeaponInfo = Game.GetCWeaponInfo();
        if (!Memory.IsValid(pCWeaponInfo))
            return;

        Memory.Write(pCWeaponInfo + CWeaponInfo.ImpactExplosion, id);
    }

    /// <summary>
    /// 武器射程
    /// </summary>
    public static void LongRange()
    {
        var pCWeaponInfo = Game.GetCWeaponInfo();
        if (!Memory.IsValid(pCWeaponInfo))
            return;

        Memory.Write(pCWeaponInfo + CWeaponInfo.LockRange, 1000.0f);
        Memory.Write(pCWeaponInfo + CWeaponInfo.Range, 2000.0f);
    }

    /// <summary>
    /// 武器快速换弹
    /// </summary>
    public static void FastReload(bool isEnable)
    {
        var pCWeaponInfo = Game.GetCWeaponInfo();
        if (!Memory.IsValid(pCWeaponInfo))
            return;

        // 载具中换弹速度
        Memory.Write(pCWeaponInfo + CWeaponInfo.ReloadVehicleMult, isEnable ? 0.0f : 1.0f);
        // 步行换弹速度
        Memory.Write(pCWeaponInfo + CWeaponInfo.ReloadMult, isEnable ? 5.0f : 1.0f);
    }
}
