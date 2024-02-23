using Chinese;

namespace GTA5Shared.Helper;

public static class ChsHelper
{
    /// <summary>
    /// 预热简繁库
    /// </summary>
    public static void PreHeat()
    {
        ToTraditional("免费，跨平台，开源！");
    }

    /// <summary>
    /// 文字简体转繁体
    /// </summary>
    /// <param name="simpleStr"></param>
    /// <returns></returns>
    public static string ToTraditional(string simpleStr)
    {
        return ChineseConverter.ToTraditional(simpleStr);
    }

    /// <summary>
    /// 文字繁体转简体
    /// </summary>
    /// <param name="traditionalStr"></param>
    /// <returns></returns>
    public static string ToSimplified(string traditionalStr)
    {
        return ChineseConverter.ToSimplified(traditionalStr);
    }

    /// <summary>
    /// 文字转拼音
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static string ToPinyin(string message)
    {
       return Pinyin.GetString(message, PinyinFormat.WithoutTone);
    }
}