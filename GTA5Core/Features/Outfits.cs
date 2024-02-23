namespace GTA5Core.Features;

public static class Outfits
{
    // Outfit Editor Globals from VenomKY
    private const int oWardrobeG = 2359296;
    private const int oWPointA = 5568;
    private const int oWPointB = 681;
    private const int oWComponent = 1336;
    private const int oWComponentTex = 1610;
    private const int oWProp = 1884;
    private const int oWPropTex = 2095;

    /// <summary>
    /// 范围0~19
    /// </summary>
    public static int OutfitIndex = 0;

    /// <summary>
    /// 公共使用的偏移
    /// </summary>
    private const int PublicUse = oWardrobeG + 0 * oWPointA + oWPointB;

    /// <summary>
    /// 通过索引获取服装名字
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public static string GetOutfitNameByIndex()
    {
        return Globals.Get_Global_String(PublicUse + oWComponent + OutfitIndex * 13 + 1126 - OutfitIndex * 5);
    }

    /// <summary>
    /// 通过索引设置服装名字
    /// </summary>
    /// <param name="index"></param>
    /// <param name="name"></param>
    public static void SetOutfitNameByIndex(string name)
    {
        Globals.Set_Global_String(PublicUse + oWComponent + OutfitIndex * 13 + 1126 - OutfitIndex * 5, name);
    }

    //////////////////////// 0 Head ////////////////////////

    public static int HEAD
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponent + OutfitIndex * 13 + 3);
        set => Globals.Set_Global_Value(PublicUse + oWComponent + OutfitIndex * 13 + 3, value);
    }

    public static int HEAD_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponentTex + OutfitIndex * 13 + 3);
        set => Globals.Set_Global_Value(PublicUse + oWComponentTex + OutfitIndex * 13 + 3, value);
    }

    //////////////////////// 1 Masks ////////////////////////

    public static int MASKS
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponent + OutfitIndex * 13 + 4);
        set => Globals.Set_Global_Value(PublicUse + oWComponent + OutfitIndex * 13 + 4, value);
    }

    public static int MASKS_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponentTex + OutfitIndex * 13 + 4);
        set => Globals.Set_Global_Value(PublicUse + oWComponentTex + OutfitIndex * 13 + 4, value);
    }

    //////////////////////// 2 Hair Styles ////////////////////////

    public static int HAIR
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponent + OutfitIndex * 13 + 5);
        set => Globals.Set_Global_Value(PublicUse + oWComponent + OutfitIndex * 13 + 5, value);
    }

    public static int HAIR_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponentTex + OutfitIndex * 13 + 5);
        set => Globals.Set_Global_Value(PublicUse + oWComponentTex + OutfitIndex * 13 + 5, value);
    }

    //////////////////////// 3 Torsos ////////////////////////

    public static int TORSOS
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponent + OutfitIndex * 13 + 6);
        set => Globals.Set_Global_Value(PublicUse + oWComponent + OutfitIndex * 13 + 6, value);
    }

    public static int TORSOS_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponentTex + OutfitIndex * 13 + 6);
        set => Globals.Set_Global_Value(PublicUse + oWComponentTex + OutfitIndex * 13 + 6, value);
    }

    //////////////////////// 4 Legs ////////////////////////

    public static int LEGS
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponent + OutfitIndex * 13 + 7);
        set => Globals.Set_Global_Value(PublicUse + oWComponent + OutfitIndex * 13 + 7, value);
    }

    public static int LEGS_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponentTex + OutfitIndex * 13 + 7);
        set => Globals.Set_Global_Value(PublicUse + oWComponentTex + OutfitIndex * 13 + 7, value);
    }

    //////////////////////// 5 Bags and Parachutes ////////////////////////

    public static int BAGS
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponent + OutfitIndex * 13 + 8);
        set => Globals.Set_Global_Value(PublicUse + oWComponent + OutfitIndex * 13 + 8, value);
    }

    public static int BAGS_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponentTex + OutfitIndex * 13 + 8);
        set => Globals.Set_Global_Value(PublicUse + oWComponentTex + OutfitIndex * 13 + 8, value);
    }

    //////////////////////// 6 Shoes ////////////////////////

    public static int SHOES
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponent + OutfitIndex * 13 + 9);
        set => Globals.Set_Global_Value(PublicUse + oWComponent + OutfitIndex * 13 + 9, value);
    }

    public static int SHOES_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponentTex + OutfitIndex * 13 + 9);
        set => Globals.Set_Global_Value(PublicUse + oWComponentTex + OutfitIndex * 13 + 9, value);
    }

    //////////////////////// 7 Accessories ////////////////////////

    public static int ACCESSORIES
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponent + OutfitIndex * 13 + 10);
        set => Globals.Set_Global_Value(PublicUse + oWComponent + OutfitIndex * 13 + 10, value);
    }

    public static int ACCESSORIES_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponentTex + OutfitIndex * 13 + 10);
        set => Globals.Set_Global_Value(PublicUse + oWComponentTex + OutfitIndex * 13 + 10, value);
    }

    //////////////////////// 8 Undershirts ////////////////////////

    public static int UNDERSHIRTS
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponent + OutfitIndex * 13 + 11);
        set => Globals.Set_Global_Value(PublicUse + oWComponent + OutfitIndex * 13 + 11, value);
    }

    public static int UNDERSHIRTS_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponentTex + OutfitIndex * 13 + 11);
        set => Globals.Set_Global_Value(PublicUse + oWComponentTex + OutfitIndex * 13 + 11, value);
    }

    //////////////////////// 9 Body Armors ////////////////////////

    public static int ARMORS
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponent + OutfitIndex * 13 + 12);
        set => Globals.Set_Global_Value(PublicUse + oWComponent + OutfitIndex * 13 + 12, value);
    }

    public static int ARMORS_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponentTex + OutfitIndex * 13 + 12);
        set => Globals.Set_Global_Value(PublicUse + oWComponentTex + OutfitIndex * 13 + 12, value);
    }

    //////////////////////// 10 Decals ////////////////////////

    public static int DECALS
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponent + OutfitIndex * 13 + 13);
        set => Globals.Set_Global_Value(PublicUse + oWComponent + OutfitIndex * 13 + 13, value);
    }

    public static int DECALS_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponentTex + OutfitIndex * 13 + 13);
        set => Globals.Set_Global_Value(PublicUse + oWComponentTex + OutfitIndex * 13 + 13, value);
    }

    //////////////////////// 11 Tops ////////////////////////

    public static int TOPS
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponent + OutfitIndex * 13 + 14);
        set => Globals.Set_Global_Value(PublicUse + oWComponent + OutfitIndex * 13 + 14, value);
    }

    public static int TOPS_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWComponentTex + OutfitIndex * 13 + 14);
        set => Globals.Set_Global_Value(PublicUse + oWComponentTex + OutfitIndex * 13 + 14, value);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    //////////////////////// 0 Hats ////////////////////////

    public static int HATS
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWProp + OutfitIndex * 10 + 3);
        set => Globals.Set_Global_Value(PublicUse + oWProp + OutfitIndex * 10 + 3, value);
    }

    public static int HATS_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWPropTex + OutfitIndex * 10 + 3);
        set => Globals.Set_Global_Value(PublicUse + oWPropTex + OutfitIndex * 10 + 3, value);
    }

    //////////////////////// 1 Glasses ////////////////////////

    public static int GLASSES
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWProp + OutfitIndex * 10 + 4);
        set => Globals.Set_Global_Value(PublicUse + oWProp + OutfitIndex * 10 + 4, value);
    }

    public static int GLASSES_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWPropTex + OutfitIndex * 10 + 4);
        set => Globals.Set_Global_Value(PublicUse + oWPropTex + OutfitIndex * 10 + 4, value);
    }

    //////////////////////// 2 Ears ////////////////////////

    public static int EARS
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWProp + OutfitIndex * 10 + 5);
        set => Globals.Set_Global_Value(PublicUse + oWProp + OutfitIndex * 10 + 5, value);
    }

    public static int EARS_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWPropTex + OutfitIndex * 10 + 5);
        set => Globals.Set_Global_Value(PublicUse + oWPropTex + OutfitIndex * 10 + 5, value);
    }

    //////////////////////// 6 Watches ////////////////////////

    public static int WATCHES
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWProp + OutfitIndex * 10 + 9);
        set => Globals.Set_Global_Value(PublicUse + oWProp + OutfitIndex * 10 + 9, value);
    }

    public static int WATCHES_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWPropTex + OutfitIndex * 10 + 9);
        set => Globals.Set_Global_Value(PublicUse + oWPropTex + OutfitIndex * 10 + 9, value);
    }

    //////////////////////// 7 Bracelets ////////////////////////

    public static int BRACELETS
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWProp + OutfitIndex * 10 + 10);
        set => Globals.Set_Global_Value(PublicUse + oWProp + OutfitIndex * 10 + 10, value);
    }

    public static int BRACELETS_TEX
    {
        get => Globals.Get_Global_Value<int>(PublicUse + oWPropTex + OutfitIndex * 10 + 10);
        set => Globals.Set_Global_Value(PublicUse + oWPropTex + OutfitIndex * 10 + 10, value);
    }
}
