namespace GTA5Core.Offsets;

public struct CPedFactory
{
    public const int CPed = 0x08;
}

public struct CPed                                      // 0x08
{
    public const int CBaseModelInfo = 0x20;
    public const int EntityType = 0x2B;                 // 实体类型 byte 156:Player 152:Other
    public const int Invisible = 0x2C;                  // 可见性 byte 0x01:on 0x24:off
    public const int CNavigation = 0x30;
    public const int VisualX = 0x90;
    public const int VisualY = 0x94;
    public const int VisualZ = 0x98;
    public const int Proof = 0x188;
    public const int God = 0x189;
    public const int Hostility = 0x18C;
    public const int Health = 0x280;
    public const int HealthMax = 0x284;
    public const int CVehicle = 0xD10;
    public const int InVehicle = 0xE32;                 // int 0:false 1:true
    public const int Ragdoll = 0x1098;
    public const int CPlayerInfo = 0x10A8;
    public const int CPedInventory = 0x10B0;
    public const int CPedWeaponManager = 0x10B8;
    public const int Seatbelt = 0x143C;                 // byte 55:false 56:true
    public const int Armor = 0x150C;                    // float, 50:Online 100:Story Mode
}

public struct CBaseModelInfo                            // 0x20
{
    public const int Hash = 0x18;                       // uint
    public const int ModelType = 0x9D;                  // enum class eModelType : std::uint8_t
}

public struct CNavigation                               // 0x30
{
    public const int RightX = 0x20;
    public const int RightY = 0x24;
    public const int RightZ = 0x28;
    public const int ForwardX = 0x30;                   // float, vector3
    public const int ForwardY = 0x34;
    public const int ForwardZ = 0x38;
    public const int UpX = 0x40;                        // float, vector3
    public const int UpY = 0x44;
    public const int UpZ = 0x48;
    public const int PositionX = 0x50;                  // float, vector3
    public const int PositionY = 0x54;
    public const int PositionZ = 0x58;
}

public struct CVehicle                                  // 0xD10
{
    public const int CModelInfo = 0x20;
    public const int Invisible = 0x2C;                  // byte 0x01:on 0x27:off
    public const int CNavigation = 0x30;
    public const int VisualX = 0x90;                    // float, vector3
    public const int VisualY = 0x94;
    public const int VisualZ = 0x98;
    public const int State = 0xD8;                      // int 0:Player 1:NPC 2:Unused 3:Destroyed
    public const int God = 0x189;                       // int8 0:false 1:true
    public const int Health = 0x280;                    // float
    public const int HealthMax = 0x284;
    public const int HealthBody = 0x820;
    public const int HealthPetrolTank = 0x824;
    public const int HealthEngine = 0x8E8;
    public const int Passenger = 0xC42;                 // byte 载具座位人数
}

public struct CPlayerInfo                               // 0x10A8
{
    public const int RelayIP = 0x70;                    // byte
    public const int RelayPort = 0x74;                  // short
    public const int ExternalIP = 0xC8;
    public const int ExternalPort = 0xCC;
    public const int InternalIP = 0xD0;
    public const int InternalPort = 0xD4;

    public const int HostToken = 0xE0;                  // int64
    public const int RockstarID = 0xE8;
    public const int Name = 0xFC;                       // string[20]
    public const int SwimSpeed = 0x1C8;                 // float
    public const int WaterProof = 0x1E0;
    public const int WalkSpeed = 0x1E4;
    public const int GameState = 0x230;                 // byte
    public const int CPed = 0x240;
    public const int FrameFlags = 0x270;
    public const int CrossHairX = 0x350;                // float
    public const int CrossHairY = 0x354;
    public const int CrossHairZ = 0x358;
    public const int WantedCanChange = 0x78C;           // float
    public const int NPCIgnore = 0x8C0;                 // int32
    public const int WantedLevel = 0x8D8;               // int32
    public const int WantedLevelDisplay = 0x8DC;        // int32
    public const int RunSpeed = 0xD40;                  // float
    public const int Stamina = 0xD44;                   // float
    public const int StaminaRegen = 0xD48;              // float
    public const int WeaponDamageMult = 0xD5C;          // float
    public const int WeaponDefenceMult = 0xD60;
    public const int MeleeWeaponDamageMult = 0xD68;
    public const int MeleeDamageMult = 0xD6C;
    public const int MeleeDefenceMult = 0xD70;
    public const int MeleeWeaponDefenceMult = 0xD7C;
}

public struct CPedInventory                             // 0x10B0
{
    public const int AmmoModifier = 0x78;
}

public struct CPedWeaponManager                         // 0x10B8
{
    public const int CWeaponInfo = 0x20;
}

public struct CModelInfo                                // 0x20
{
    public const int ModelHash = 0x18;                  // int
    public const int CamDist = 0x38;                    // float
    public const int Name = 0x298;                      // string [10]
    public const int Maker = 0x2A4;                     // string [10]
    public const int Extras = 0x58B;                    // short
    public const int Parachute = 0x58C;
}

public struct CWeaponInfo                               // 0x20
{
    public const int ImpactType = 0x20;                 // byte
    public const int ImpactExplosion = 0x24;
    public const int CAmmoInfo = 0x60;
    public const int CVehicleWeapon = 0x70;
    public const int Spread = 0x74;                     // float
    public const int Damage = 0xB0;
    public const int Force = 0xD8;
    public const int ForcePed = 0xDC;                   // float
    public const int ForceVehicle = 0xE0;               // float
    public const int ForceFlying = 0xE4;                // float
    public const int ReloadVehicleMult = 0x130;
    public const int ReloadMult = 0x134;
    public const int ShotTime = 0x13C;
    public const int LockRange = 0x288;
    public const int Range = 0x28C;
    public const int Recoil = 0x2F4;
}
