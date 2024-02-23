using GTA5Core.Native;
using GTA5Core.Offsets;

namespace GTA5Core.Features;

public static class Player
{
    /// <summary>
    /// 玩家无敌模式
    /// </summary>
    public static void GodMode(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        Memory.Write(pCPed + CPed.God, (byte)(isEnable ? 0x01 : 0x00));
    }

    /// <summary>
    /// 玩家生命值
    /// </summary>
    /// <param name="value"></param>
    public static void Health(float value)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        Memory.Write(pCPed + CPed.Health, value);
    }

    /// <summary>
    /// 玩家最大生命值
    /// </summary>
    /// <param name="value"></param>
    public static void HealthMax(float value)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        Memory.Write(pCPed + CPed.HealthMax, value);
    }

    /// <summary>
    /// 玩家护甲值
    /// </summary>
    /// <param name="value"></param>
    public static void Armor(float value)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        Memory.Write(pCPed + CPed.Armor, value);
    }

    /// <summary>
    /// 玩家通缉等级，0x00,0x01,0x02,0x03,0x04,0x05
    /// </summary>
    public static void WantedLevel(byte level)
    {
        var pCPlayerInfo = Game.GetCPlayerInfo();
        if (!Memory.IsValid(pCPlayerInfo))
            return;

        Memory.Write(pCPlayerInfo + CPlayerInfo.WantedLevel, level);
    }

    /// <summary>
    /// 玩家奔跑速度
    /// </summary>
    /// <param name="value"></param>
    public static void RunSpeed(float value)
    {
        var pCPlayerInfo = Game.GetCPlayerInfo();
        if (!Memory.IsValid(pCPlayerInfo))
            return;

        Memory.Write(pCPlayerInfo + CPlayerInfo.RunSpeed, value);
    }

    /// <summary>
    /// 玩家游泳速度
    /// </summary>
    /// <param name="value"></param>
    public static void SwimSpeed(float value)
    {
        var pCPlayerInfo = Game.GetCPlayerInfo();
        if (!Memory.IsValid(pCPlayerInfo))
            return;

        Memory.Write(pCPlayerInfo + CPlayerInfo.SwimSpeed, value);
    }

    /// <summary>
    /// 玩家行走速度
    /// </summary>
    /// <param name="value"></param>
    public static void WalkSpeed(float value)
    {
        var pCPlayerInfo = Game.GetCPlayerInfo();
        if (!Memory.IsValid(pCPlayerInfo))
            return;

        Memory.Write(pCPlayerInfo + CPlayerInfo.WalkSpeed, value);
    }

    /// <summary>
    /// 无布娃娃
    /// </summary>
    public static void NoRagdoll(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        Memory.Write(pCPed + CPed.Ragdoll, (byte)(isEnable ? 0x01 : 0x20));
    }

    /// <summary>
    /// 角色隐形（虚假）
    /// </summary>
    public static void Invisible(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        Memory.Write(pCPed + CPed.Invisible, (byte)(isEnable ? 0x01 : 0x27));
    }

    /// <summary>
    /// 补满血量
    /// </summary>
    public static void FillHealth()
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        var oHealth = Memory.Read<float>(pCPed + CPed.Health);
        var oHealthMax = Memory.Read<float>(pCPed + CPed.HealthMax);
        if (oHealth <= oHealthMax)
            Memory.Write(pCPed + CPed.Health, oHealthMax);
        else
            Memory.Write(pCPed + CPed.Health, 328.0f);
    }

    /// <summary>
    /// 补满护甲
    /// </summary>
    public static void FillArmor()
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        Memory.Write(pCPed + CPed.Armor, Globals.IsOnlineMode() ? 50.0f : 100.0f);
    }

    /// <summary>
    /// 玩家自杀（设置当前生命值为1.0）
    /// </summary>
    public static void Suicide()
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        Memory.Write(pCPed + CPed.Health, 1.0f);
    }

    /// <summary>
    /// 雷达影踪（最大生命值为0，以线上模式最大生命值为准）
    /// </summary>
    public static void UndeadOffRadar(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        Memory.Write(pCPed + CPed.HealthMax, isEnable ? 0.0f : 328.0f);
    }

    /// <summary>
    /// 永不通缉
    /// </summary>
    public static void WantedCanChange(bool isEnable)
    {
        var pCPlayerInfo = Game.GetCPlayerInfo();
        if (!Memory.IsValid(pCPlayerInfo))
            return;

        Memory.Write(pCPlayerInfo + CPlayerInfo.WantedCanChange, isEnable ? 1.0f : 0.0f);
    }

    /// <summary>
    /// NPC无视玩家
    /// </summary>
    /// <param name="value"></param>
    public static void NPCIgnore(int value)
    {
        var pCPlayerInfo = Game.GetCPlayerInfo();
        if (!Memory.IsValid(pCPlayerInfo))
            return;

        Memory.Write(pCPlayerInfo + CPlayerInfo.NPCIgnore, value);
    }

    /// <summary>
    /// 无碰撞体积
    /// </summary>
    public static void NoCollision(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        var pCNavigation = Memory.Read<long>(pCPed + CPed.CNavigation);
        var pointer = Memory.Read<long>(pCNavigation + 0x10);
        pointer = Memory.Read<long>(pointer + 0x20);
        pointer = Memory.Read<long>(pointer + 0x70);
        pointer = Memory.Read<long>(pointer + 0x00);

        Memory.Write(pointer + 0x2C, isEnable ? -1.0f : 0.25f);
    }

    /// <summary>
    /// 角色防子弹
    /// </summary>
    public static void ProofBullet(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        var oProof = Memory.Read<uint>(pCPed + CPed.Proof);

        oProof = isEnable ? oProof | 1 << 4 : (uint)(oProof & ~(1 << 4));
        Memory.Write(pCPed + CPed.Proof, oProof);
    }

    /// <summary>
    /// 角色防火烧
    /// </summary>
    public static void ProofFire(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        var oProof = Memory.Read<uint>(pCPed + CPed.Proof);

        oProof = isEnable ? oProof | 1 << 5 : (uint)(oProof & ~(1 << 5));
        Memory.Write(pCPed + CPed.Proof, oProof);
    }

    /// <summary>
    /// 角色防撞击
    /// </summary>
    public static void ProofCollision(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        var oProof = Memory.Read<uint>(pCPed + CPed.Proof);

        oProof = isEnable ? oProof | 1 << 6 : (uint)(oProof & ~(1 << 6));
        Memory.Write(pCPed + CPed.Proof, oProof);
    }

    /// <summary>
    /// 角色防近战
    /// </summary>
    public static void ProofMelee(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        var oProof = Memory.Read<uint>(pCPed + CPed.Proof);

        oProof = isEnable ? oProof | 1 << 7 : (uint)(oProof & ~(1 << 7));
        Memory.Write(pCPed + CPed.Proof, oProof);
    }

    /// <summary>
    /// 角色防无敌
    /// </summary>
    public static void ProofGod(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        var oProof = Memory.Read<uint>(pCPed + CPed.Proof);

        oProof = isEnable ? oProof | 1 << 8 : (uint)(oProof & ~(1 << 8));
        Memory.Write(pCPed + CPed.Proof, oProof);
    }

    /// <summary>
    /// 角色防爆炸
    /// </summary>
    public static void ProofExplosion(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        var oProof = Memory.Read<uint>(pCPed + CPed.Proof);

        oProof = isEnable ? oProof | 1 << 11 : (uint)(oProof & ~(1 << 11));
        Memory.Write(pCPed + CPed.Proof, oProof);
    }

    /// <summary>
    /// 角色防蒸汽
    /// </summary>
    public static void ProofSteam(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        var oProof = Memory.Read<uint>(pCPed + CPed.Proof);

        oProof = isEnable ? oProof | 1 << 15 : (uint)(oProof & ~(1 << 15));
        Memory.Write(pCPed + CPed.Proof, oProof);
    }

    /// <summary>
    /// 角色防溺水
    /// </summary>
    public static void ProofDrown(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        var oProof = Memory.Read<uint>(pCPed + CPed.Proof);

        oProof = isEnable ? oProof | 1 << 16 : (uint)(oProof & ~(1 << 16));
        Memory.Write(pCPed + CPed.Proof, oProof);
    }

    /// <summary>
    /// 角色防海水
    /// </summary>
    public static void ProofWater(bool isEnable)
    {
        var pCPed = Game.GetCPed();
        if (!Memory.IsValid(pCPed))
            return;

        var oProof = Memory.Read<uint>(pCPed + CPed.Proof);

        oProof = isEnable ? oProof | 1 << 24 : (uint)(oProof & ~(1 << 24));
        Memory.Write(pCPed + CPed.Proof, oProof);
    }
}
