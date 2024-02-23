using GTA5Core.Native;
using GTA5Core.Offsets;

namespace GTA5Core.Features;

public static class Locals
{
    /// <summary>
    /// 获取指定脚本指针
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static long LocalAddress(string name)
    {
        var pLocalScripts = Memory.Read<long>(Pointers.LocalScriptsPTR);
        if (!Memory.IsValid(pLocalScripts))
            return 0;

        for (var i = 0; i < 54; i++)
        {
            var pointer = Memory.Read<long>(pLocalScripts + i * 0x08);
            if (!Memory.IsValid(pointer))
                continue;

            var script = Memory.ReadString(pointer + 0xD4, name.Length + 1);

            if (script.ToLower() == name.ToLower())
                return pointer + 0xB0;
        }

        return 0;
    }

    /// <summary>
    /// 获取指定脚本指针
    /// </summary>
    /// <param name="name"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static long LocalAddress(string name, int index)
    {
        var pScript = LocalAddress(name);
        if (!Memory.IsValid(pScript))
            return 0;

        var pointer = Memory.Read<long>(pScript);
        if (!Memory.IsValid(pointer))
            return 0;

        return pointer + index * 0x08;
    }

    /// <summary>
    /// 读取脚本值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name">脚本名称</param>
    /// <param name="index">脚本索引</param>
    /// <returns>读取到的脚本值</returns>
    public static T ReadLocalAddress<T>(string name, int index) where T : struct
    {
        var pointer = LocalAddress(name, index);
        if (!Memory.IsValid(pointer))
            return default;

        return Memory.Read<T>(pointer);
    }

    /// <summary>
    /// 写入脚本值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name">脚本名称</param>
    /// <param name="index">脚本索引</param>
    /// <param name="value">脚本值</param>
    public static void WriteLocalAddress<T>(string name, int index, T value) where T : struct
    {
        var pointer = LocalAddress(name, index);
        if (!Memory.IsValid(pointer))
            return;

        Memory.Write(pointer, value);
    }
}
