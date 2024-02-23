using GTA5Menu.Data;

using GTA5Core.Native;
using GTA5Core.Offsets;
using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// PlayerListView.xaml 的交互逻辑
/// </summary>
public partial class PlayerListView : UserControl
{
    public ObservableCollection<NetPlayerInfo> NetPlayerInfos { get; set; } = new();

    public PlayerListView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        GTA5MenuWindow.WindowClosingEvent -= GTA5MenuWindow_WindowClosingEvent;
    }

    /////////////////////////////////////////////////

    private float GetDistance(Vector3 myPosV3, Vector3 pedPosV3)
    {
        return (float)Math.Sqrt(
            Math.Pow(myPosV3.X - pedPosV3.X, 2) +
            Math.Pow(myPosV3.Y - pedPosV3.Y, 2) +
            Math.Pow(myPosV3.Z - pedPosV3.Z, 2));
    }

    private void AppendPlayerInfo(string msg = "")
    {
        TextBox_PlayerInfo.AppendText($"{msg}\n");
    }

    private string BoolToYES(bool value)
    {
        return value ? "YES" : "NO";
    }

    /////////////////////////////////////////////////

    private void Button_RefreshPlayerList_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        NetPlayerInfos.Clear();
        TextBox_PlayerInfo.Clear();

        var index = 1;

        ///////////////////////////////////////

        var pCNetworkInfo = Memory.Read<long>(Pointers.NetworkInfoPTR);
        var pCNetworkPlayerMgr = Memory.Read<long>(Pointers.NetworkPlayerMgrPTR);

        // 当前战局主机token
        var hostToken1 = Memory.Read<long>(pCNetworkInfo + 0x9E0);      // oHostNetToken

        for (var i = 0; i < Base.oMaxPlayers; i++)
        {
            var pCNetGamePlayer = Memory.Read<long>(pCNetworkPlayerMgr + CNetworkPlayerMgr.CNetGamePlayer + i * 0x08);
            if (!Memory.IsValid(pCNetGamePlayer))
                continue;

            var pCPlayerInfo = Memory.Read<long>(pCNetGamePlayer + CNetGamePlayer.CPlayerInfo);
            if (!Memory.IsValid(pCPlayerInfo))
                continue;

            var pCPed = Memory.Read<long>(pCPlayerInfo + CPlayerInfo.CPed);
            if (!Memory.IsValid(pCPed))
                continue;

            // 当前玩家战局token
            var hostToken2 = Memory.Read<long>(pCPlayerInfo + CPlayerInfo.HostToken);

            // 是否为战局主机
            var isHost = hostToken1 == hostToken2;

            // 是否为脚本主机
            var scriptHost = Globals.Get_Global_Value<int>(2650208 + 1);

            ////////////////////////////////////////////

            var relayIP = new byte[4];
            var externalIP = new byte[4];
            var internalIP = new byte[4];

            for (int j = 0; j < 4; j++)
            {
                relayIP[j] = Memory.Read<byte>(pCPlayerInfo + CPlayerInfo.RelayIP + j);
            }
            short relayPort = Memory.Read<short>(pCPlayerInfo + CPlayerInfo.RelayPort);

            for (int j = 0; j < 4; j++)
            {
                externalIP[j] = Memory.Read<byte>(pCPlayerInfo + CPlayerInfo.ExternalIP + j);
            }
            short externalPort = Memory.Read<short>(pCPlayerInfo + CPlayerInfo.ExternalPort);

            for (int j = 0; j < 4; j++)
            {
                internalIP[j] = Memory.Read<byte>(pCPlayerInfo + CPlayerInfo.InternalIP + j);
            }
            short internalPort = Memory.Read<short>(pCPlayerInfo + CPlayerInfo.InternalPort);

            ////////////////////////////////////////////

            var god = Memory.Read<byte>(pCPed + CPed.God);
            var godMode = (god & 1) == 1;
            var position = Memory.Read<Vector3>(pCPed + CPed.VisualX);
            var health = Memory.Read<float>(pCPed + CPed.Health);
            var healthMax = Memory.Read<float>(pCPed + CPed.HealthMax);
            var armor = Memory.Read<float>(pCPed + CPed.Armor);
            var noRagdoll = Memory.Read<byte>(pCPed + CPed.Ragdoll);

            var rank = Globals.Get_Global_Value<int>(1853988 + 1 + i * 867 + 205 + 6);
            var money = Globals.Get_Global_Value<long>(1853988 + 1 + i * 867 + 205 + 56);     // _MPPLY_STAT_SET_INT(joaat("MPPLY_GLOBALXP"), iParam0);
            var cash = Globals.Get_Global_Value<long>(1853988 + 1 + i * 867 + 205 + 3);

            var rid = Memory.Read<long>(pCPlayerInfo + CPlayerInfo.RockstarID);
            var name = Memory.ReadString(pCPlayerInfo + CPlayerInfo.Name, 20);
            var wantedLevel = Memory.Read<byte>(pCPlayerInfo + CPlayerInfo.WantedLevel);
            var walkSpeed = Memory.Read<float>(pCPlayerInfo + CPlayerInfo.WalkSpeed);
            var runSpeed = Memory.Read<float>(pCPlayerInfo + CPlayerInfo.RunSpeed);
            var swimSpeed = Memory.Read<float>(pCPlayerInfo + CPlayerInfo.SwimSpeed);

            var clanTag = Memory.ReadString(pCNetGamePlayer + CNetGamePlayer.ClanTag, 5);
            var clanName = Memory.ReadString(pCNetGamePlayer + CNetGamePlayer.ClanName, 25);
            var clanMotto = Memory.ReadString(pCNetGamePlayer + CNetGamePlayer.ClanMotto, 65);

            ////////////////////////////////////////////

            NetPlayerInfos.Add(new()
            {
                Index = index++,
                Avatar = $"https://prod.cloud.rockstargames.com/members/sc/5605/{rid}/publish/gta5/mpchars/0.png",
                IsHost = isHost,
                IsScriptHost = i == scriptHost,

                Rank = rank,
                RockstarId = rid,
                PlayerName = name,

                Money = money,
                Cash = cash,
                Bank = money - cash,

                GodMode = godMode,
                Health = health,
                HealthMax = healthMax,
                Armor = armor,
                NoRagdoll = noRagdoll != 0x20,

                Distance = GetDistance(Teleport.GetPlayerPosition(), position),
                Position = position,

                WantedLevel = wantedLevel,
                WalkSpeed = walkSpeed,
                RunSpeed = runSpeed,
                SwimSpeed = swimSpeed,

                ClanTag = clanTag,
                ClanName = clanName,
                ClanMotto = clanMotto,

                ClanTagUpper = clanTag.ToUpper(),
                GodModeFlag = BoolToYES(godMode),

                RelayIP = $"{relayIP[3]}.{relayIP[2]}.{relayIP[1]}.{relayIP[0]} : {relayPort}",
                ExternalIP = $"{externalIP[3]}.{externalIP[2]}.{externalIP[1]}.{externalIP[0]} : {externalPort}",
                InternalIP = $"{internalIP[3]}.{internalIP[2]}.{internalIP[1]}.{internalIP[0]} : {internalPort}",
            });
        }
    }

    private void Button_TeleportToPlayer_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_NetPlayers.SelectedItem is NetPlayerInfo info)
        {
            Teleport.SetTeleportPosition(info.Position);
        }
    }

    private void ListBox_NetPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TextBox_PlayerInfo.Clear();

        if (ListBox_NetPlayers.SelectedItem is NetPlayerInfo info)
        {
            AppendPlayerInfo($"等级 : {info.Rank}");
            AppendPlayerInfo();

            AppendPlayerInfo($"昵称 : {info.PlayerName}");
            AppendPlayerInfo($"R星ID : {info.RockstarId}");
            AppendPlayerInfo();

            AppendPlayerInfo($"战局主机 : {BoolToYES(info.IsHost)}");
            AppendPlayerInfo($"脚本主机 : {BoolToYES(info.IsScriptHost)}");
            AppendPlayerInfo();

            AppendPlayerInfo($"中继IP地址 : {info.RelayIP}");
            AppendPlayerInfo($"外部IP地址 : {info.ExternalIP}");
            AppendPlayerInfo($"内部IP地址 : {info.InternalIP}");
            AppendPlayerInfo();

            AppendPlayerInfo($"帮会标签 : {info.ClanTag}");
            AppendPlayerInfo($"帮会名称 : {info.ClanName}");
            AppendPlayerInfo($"帮会描述 : {info.ClanMotto}");
            AppendPlayerInfo();

            AppendPlayerInfo($"$ 总计 : {info.Money}");
            AppendPlayerInfo($"$ 银行 : {info.Bank}");
            AppendPlayerInfo($"$ 现金 : {info.Cash}");
            AppendPlayerInfo();

            AppendPlayerInfo($"护甲值 : {info.Armor:0.0}");
            AppendPlayerInfo($"生命值 : {info.Health:0.0}");
            AppendPlayerInfo($"最大生命值 : {info.HealthMax:0.0}");
            AppendPlayerInfo();

            AppendPlayerInfo($"无敌状态 : {BoolToYES(info.GodMode)}");
            AppendPlayerInfo($"无布娃娃 : {BoolToYES(info.NoRagdoll)}");
            AppendPlayerInfo($"通缉等级 : {info.WantedLevel}");
            AppendPlayerInfo();

            AppendPlayerInfo($"步行速度 : {info.WalkSpeed:0.0}");
            AppendPlayerInfo($"奔跑速度 : {info.RunSpeed:0.0}");
            AppendPlayerInfo($"游泳速度 : {info.SwimSpeed:0.0}");
            AppendPlayerInfo();

            AppendPlayerInfo($"与我距离 : {info.Distance:0.000}");
            AppendPlayerInfo($"坐标数据 : {info.Position.X:0.000}, {info.Position.Y:0.000}, {info.Position.Z:0.000}");
        }
    }
}
