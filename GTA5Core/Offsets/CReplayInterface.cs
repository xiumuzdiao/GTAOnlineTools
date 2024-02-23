namespace GTA5Core.Offsets;

public struct CReplayInterface
{
    public const int CVehicleInterface = 0x10;
    public const int CPedInterface = 0x18;
    public const int CPickupInterface = 0x20;
    public const int CObjectInterface = 0x28;
}

public struct CVehicleInterface                 // 0x10
{
    public const int CVehicleList = 0x180;      // array size 300 offset + i * 0x10
    public const int MaxVehicles = 0x188;       // int32
    public const int CurVehicles = 0x190;
}

public struct CPedInterface                     // 0x18
{
    public const int CPedList = 0x100;          // array size 256 offset + i * 0x10
    public const int MaxPeds = 0x108;           // int32
    public const int CurPeds = 0x110;
}

public struct CPickupInterface                  // 0x20
{
    public const int CPickupList = 0x100;       // array size 73 offset + i * 0x10
    public const int MaxPickups = 0x108;        // int32
    public const int CurPickups = 0x110;
}

public struct CObjectInterface                  // 0x28
{
    public const int CObjectList = 0x158;       // array size 2300 offset + i * 0x10
    public const int MaxObjects = 0x160;        // int32
    public const int CurObjects = 0x168;
}