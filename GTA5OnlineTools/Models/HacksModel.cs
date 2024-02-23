using CommunityToolkit.Mvvm.ComponentModel;

namespace GTA5OnlineTools.Models;

public partial class HacksModel : ObservableObject
{
    /// <summary>
    /// Kiddion运行状态
    /// </summary>
    [ObservableProperty]
    private bool kiddionIsRun;

    /// <summary>
    /// GTAHax运行状态
    /// </summary>
    [ObservableProperty]
    private bool gTAHaxIsRun;

    /// <summary>
    /// BincoHax运行状态
    /// </summary>
    [ObservableProperty]
    private bool bincoHaxIsRun;

    /// <summary>
    /// LSCHax运行状态
    /// </summary>
    [ObservableProperty]
    private bool lSCHaxIsRun;
}
