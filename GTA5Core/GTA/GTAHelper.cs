namespace GTA5Core.GTA;

public static class GTAHelper
{
    /// <summary>
    /// 获取载具对应预览图
    /// </summary>
    /// <param name="vehicleName">载具名称</param>
    /// <returns></returns>
    public static string GetVehicleImage(string vehicleName)
    {
        return $"pack://application:,,,/GTA5Core;component/Assets/Vehicles/{vehicleName}.png";
    }

    /// <summary>
    /// 获取武器对应预览图
    /// </summary>
    /// <param name="weaponName">武器名称</param>
    /// <returns></returns>
    public static string GetWeaponImage(string weaponName)
    {
        return $"pack://application:,,,/GTA5Core;component/Assets/Weapons/{weaponName}.png";
    }

    /// <summary>
    /// 获取Blip预览图
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public static string GetBlipImage(int index)
    {
        return $"pack://application:,,,/GTA5Core;component/Assets/Blips/Blip_{index}.png";
    }

    /// <summary>
    /// 计算字符串Hash值
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static uint JOAAT(string data)
    {
        uint hash = 0u;

        foreach (char c in data.ToLower())
        {
            hash += c;
            hash += hash << 10;
            hash ^= hash >> 6;
        }

        hash += hash << 3;
        hash ^= hash >> 11;
        hash += hash << 15;

        return hash;
    }
}
