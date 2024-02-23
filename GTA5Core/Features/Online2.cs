using GTA5Core.Offsets;

namespace GTA5Core.Features;

/// <summary>
/// 2023/06/17
/// 这里的功能可能会有风险， 暂时遗弃
/// </summary>
public static class Online2
{
    /// <summary>
    /// 设置CEO板条箱每箱出售单价为2W
    /// </summary>
    /// <param name="isEnable"></param>
    public static void CEOPricePerCrateAtCrates(bool isEnable)
    {
        // -1445480509 joaat("EXEC_CONTRABAND_SALE_VALUE_THRESHOLD1")
        Globals.Set_Global_Value(Base.Default + 15963, isEnable ? 20000 : 10000);            // 1
        Globals.Set_Global_Value(Base.Default + 15963 + 1, isEnable ? 20000 : 11000);        // 2
        Globals.Set_Global_Value(Base.Default + 15963 + 2, isEnable ? 20000 : 12000);        // 3
        Globals.Set_Global_Value(Base.Default + 15963 + 3, isEnable ? 20000 : 13000);        // 4-5
        Globals.Set_Global_Value(Base.Default + 15963 + 4, isEnable ? 20000 : 13500);        // 6-7
        Globals.Set_Global_Value(Base.Default + 15963 + 5, isEnable ? 20000 : 14000);        // 8-9
        Globals.Set_Global_Value(Base.Default + 15963 + 6, isEnable ? 20000 : 14500);        // 10-14
        Globals.Set_Global_Value(Base.Default + 15963 + 7, isEnable ? 20000 : 15000);        // 15-19
        Globals.Set_Global_Value(Base.Default + 15963 + 8, isEnable ? 20000 : 15500);        // 20-24
        Globals.Set_Global_Value(Base.Default + 15963 + 9, isEnable ? 20000 : 16000);        // 25-29
        Globals.Set_Global_Value(Base.Default + 15963 + 10, isEnable ? 20000 : 16500);       // 30-34
        Globals.Set_Global_Value(Base.Default + 15963 + 11, isEnable ? 20000 : 17000);       // 35-39
        Globals.Set_Global_Value(Base.Default + 15963 + 12, isEnable ? 20000 : 17500);       // 40-44
        Globals.Set_Global_Value(Base.Default + 15963 + 13, isEnable ? 20000 : 17750);       // 45-49
        Globals.Set_Global_Value(Base.Default + 15963 + 14, isEnable ? 20000 : 18000);       // 50-59
        Globals.Set_Global_Value(Base.Default + 15963 + 15, isEnable ? 20000 : 18250);       // 60-69
        Globals.Set_Global_Value(Base.Default + 15963 + 16, isEnable ? 20000 : 18500);       // 70-79
        Globals.Set_Global_Value(Base.Default + 15963 + 17, isEnable ? 20000 : 18750);       // 80-89
        Globals.Set_Global_Value(Base.Default + 15963 + 18, isEnable ? 20000 : 19000);       // 90-990
        Globals.Set_Global_Value(Base.Default + 15963 + 19, isEnable ? 20000 : 19500);       // 100-11
        Globals.Set_Global_Value(Base.Default + 15963 + 20, isEnable ? 20000 : 20000);       // 111
    }


    /// <summary>
    /// 设置地堡生产和研究时间为指定时间，单位秒
    /// </summary>
    /// <param name="isEnable"></param>
    /// <param name="produce_time"></param>
    public static void SetBunkerProduceResearchTime(bool isEnable, int produce_time = 1)
    {
        // Base Time to Produce                                                         // tuneables_processing.c
        Globals.Set_Global_Value(Base.Default + 21532, isEnable ? produce_time : 600000);        // Product                  215868155 
        Globals.Set_Global_Value(Base.Default + 21548, isEnable ? produce_time : 300000);        // Research                 -676414773 joaat("GR_RESEARCH_PRODUCTION_TIME")

        // Time to Produce Reductions
        Globals.Set_Global_Value(Base.Default + 21533, isEnable ? produce_time : 90000);         // Production Equipment     631477612
        Globals.Set_Global_Value(Base.Default + 21534, isEnable ? produce_time : 90000);         // Production Staff         818645907
        Globals.Set_Global_Value(Base.Default + 21593, isEnable ? produce_time : 45000);         // Research Equipment       -1148432846
        Globals.Set_Global_Value(Base.Default + 21594, isEnable ? produce_time : 45000);         // Research Staff           510883248
    }

    /// <summary>
    /// 设置地堡进货单价为200元
    /// </summary>
    /// <param name="isEnable"></param>
    public static void SetBunkerResupplyCosts(bool isEnable)
    {
        Globals.Set_Global_Value(Base.Default + 21347, isEnable ? 200 : 15000);          // 2022/12/19 未更新
        Globals.Set_Global_Value(Base.Default + 21348, isEnable ? 200 : 15000);
    }

    /// <summary>
    /// 设置地堡远近出货倍数
    /// </summary>
    /// <param name="isEnable"></param>
    public static void SetBunkerSaleMultipliers(bool isEnable)
    {
        // Sale Multipliers                                             // tuneables_processing.c
        Globals.Set_Global_Value(Base.Default + 21509, isEnable ? 2.0f : 1.0f);          // Near         1865029244
        Globals.Set_Global_Value(Base.Default + 21510, isEnable ? 3.0f : 1.5f);          // Far          1021567941
    }

    /// <summary>
    /// 设置摩托帮远近出货倍数
    /// </summary>
    /// <param name="isEnable"></param>
    public static void SetMCSaleMultipliers(bool isEnable)
    {
        // Sale Multipliers                                             // tuneables_processing.c
        Globals.Set_Global_Value(Base.Default + 19111, isEnable ? 2.0f : 1.0f);          // Near         -823848572
        Globals.Set_Global_Value(Base.Default + 19112, isEnable ? 3.0f : 1.5f);          // Far          1763638426
    }

    /// <summary>
    /// 设置地堡原材料消耗量
    /// </summary>
    /// <param name="isEnable"></param>
    public static void SetBunkerSuppliesPerUnitProduced(bool isEnable)
    {
        // Supplies Per Unit Produced                                   // tuneables_processing.c
        Globals.Set_Global_Value(Base.Default + 21579, isEnable ? 1 : 10);               // Product Base              -1652502760
        Globals.Set_Global_Value(Base.Default + 21580, isEnable ? 1 : 5);                // Product Upgraded          1647327744
        Globals.Set_Global_Value(Base.Default + 21595, isEnable ? 1 : 2);                // Research Base             1485279815
        Globals.Set_Global_Value(Base.Default + 21596, isEnable ? 1 : 1);                // Research Upgraded         2041812011
    }

    /// <summary>
    /// 设置摩托帮原材料消耗量
    /// </summary>
    /// <param name="isEnable"></param>
    public static void SetMCSuppliesPerUnitProduced(bool isEnable)
    {
        // Supplies Per Unit Produced                                   // tuneables_processing.c
        Globals.Set_Global_Value(Base.Default + 17461, isEnable ? 1 : 4);                // Documents Base            -1839004359
        Globals.Set_Global_Value(Base.Default + 17462, isEnable ? 1 : 10);               // Cash Base
        Globals.Set_Global_Value(Base.Default + 17463, isEnable ? 1 : 50);               // Cocaine Base
        Globals.Set_Global_Value(Base.Default + 17464, isEnable ? 1 : 24);               // Meth Base
        Globals.Set_Global_Value(Base.Default + 17465, isEnable ? 1 : 4);                // Weed Base
        Globals.Set_Global_Value(Base.Default + 17466, isEnable ? 1 : 2);                // Documents Upgraded
        Globals.Set_Global_Value(Base.Default + 17467, isEnable ? 1 : 5);                // Cash Upgraded
        Globals.Set_Global_Value(Base.Default + 17468, isEnable ? 1 : 25);               // Cocaine Upgraded
        Globals.Set_Global_Value(Base.Default + 17469, isEnable ? 1 : 12);               // Meth Upgraded
        Globals.Set_Global_Value(Base.Default + 17470, isEnable ? 1 : 2);                // Weed Upgraded
    }

    /// <summary>
    /// 设置夜总会生产时间为指定时间，单位秒
    /// </summary>
    /// <param name="isEnable"></param>
    /// <param name="produce_time"></param>
    public static void SetNightclubProduceTime(bool isEnable, int produce_time)
    {
        // Time to Produce                                                      // tuneables_processing.c
        Globals.Set_Global_Value(Base.Default + 24394, isEnable ? produce_time : 4800000);       // Sporting Goods               -147565853
        Globals.Set_Global_Value(Base.Default + 24395, isEnable ? produce_time : 14400000);      // South American Imports
        Globals.Set_Global_Value(Base.Default + 24396, isEnable ? produce_time : 7200000);       // Pharmaceutical Research
        Globals.Set_Global_Value(Base.Default + 24397, isEnable ? produce_time : 2400000);       // Organic Produce
        Globals.Set_Global_Value(Base.Default + 24398, isEnable ? produce_time : 1800000);       // Printing and Copying
        Globals.Set_Global_Value(Base.Default + 24399, isEnable ? produce_time : 3600000);       // Cash Creation
        Globals.Set_Global_Value(Base.Default + 24400, isEnable ? produce_time : 8400000);       // Cargo and Shipments          1607981264
    }

    /// <summary>
    /// 设置摩托帮生产时间为指定时间，单位秒
    /// </summary>
    /// <param name="isEnable"></param>
    /// <param name="produce_time"></param>
    public static void SetMCProduceTime(bool isEnable, int produce_time)
    {
        // Base Time to Produce                                                 // tuneables_processing.c
        Globals.Set_Global_Value(Base.Default + 17446, isEnable ? produce_time : 360000);        // Weed                     -635596193
        Globals.Set_Global_Value(Base.Default + 17447, isEnable ? produce_time : 1800000);       // Meth
        Globals.Set_Global_Value(Base.Default + 17448, isEnable ? produce_time : 3000000);       // Cocaine
        Globals.Set_Global_Value(Base.Default + 17449, isEnable ? produce_time : 300000);        // Documents
        Globals.Set_Global_Value(Base.Default + 17450, isEnable ? produce_time : 720000);        // Cash                     1310272402

        // Time to Produce Reductions
        Globals.Set_Global_Value(Base.Default + 17451, isEnable ? 1 : 60000);                    // Documents Equipment      1672482518
        Globals.Set_Global_Value(Base.Default + 17452, isEnable ? 1 : 120000);                   // Cash Equipment
        Globals.Set_Global_Value(Base.Default + 17453, isEnable ? 1 : 600000);                   // Cocaine Equipment
        Globals.Set_Global_Value(Base.Default + 17454, isEnable ? 1 : 360000);                   // Meth Equipment
        Globals.Set_Global_Value(Base.Default + 17455, isEnable ? 1 : 60000);                    // Weed Equipment
        Globals.Set_Global_Value(Base.Default + 17456, isEnable ? 1 : 60000);                    // Documents Staff
        Globals.Set_Global_Value(Base.Default + 17457, isEnable ? 1 : 120000);                   // Cash Staff
        Globals.Set_Global_Value(Base.Default + 17458, isEnable ? 1 : 600000);                   // Cocaine Staff
        Globals.Set_Global_Value(Base.Default + 17459, isEnable ? 1 : 360000);                   // Meth Staff
        Globals.Set_Global_Value(Base.Default + 17460, isEnable ? 1 : 60000);                    // Weed Staff               1575359233
    }

    /// <summary>
    /// 设置摩托帮进货单价为200元
    /// </summary>
    /// <param name="isEnable"></param>
    public static void SetMCResupplyCosts(bool isEnable)
    {
        Globals.Set_Global_Value(Base.Default + 18998, isEnable ? 200 : 15000);      // Discounted Resupply Cost, BIKER_PURCHASE_SUPPLIES_COST_PER_SEGMENT
    }

    /// <summary>
    /// 夜总会托尼洗钱费用
    /// </summary>
    /// <param name="isEnable"></param>
    public static void NightclubNoTonyLaunderingMoney(bool isEnable)
    {
        Globals.Set_Global_Value(Base.Default + 24496, isEnable ? 0.000001f : 0.1f);        // -1002770353  tuneables_processing.c
    }
}
