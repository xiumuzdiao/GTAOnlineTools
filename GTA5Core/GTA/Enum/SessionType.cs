namespace GTA5Core.GTA.Enum;

public enum SessionType : int
{
    /// <summary>
    /// 公共战局
    /// </summary>
    Join_Public,
    /// <summary>
    /// 创建公共战局
    /// </summary>
    New_Public,
    /// <summary>
    /// 私人帮会战局
    /// </summary>
    Closed_Crew,
    /// <summary>
    /// 帮会战局
    /// </summary>
    Crew,
    /// <summary>
    /// 私人好友战局
    /// </summary>
    Closed_Friends = 6,
    /// <summary>
    /// 加入好友
    /// </summary>
    Find_Friend = 9,
    /// <summary>
    /// 单人战局
    /// </summary>
    Solo,
    /// <summary>
    /// 仅限邀请战局
    /// </summary>
    Invite_Only,
    /// <summary>
    /// 加入帮会伙伴
    /// </summary>
    Join_Crew,
    /// <summary>
    /// 战局观看
    /// </summary>
    Sc_Tv,
    /// <summary>
    /// 离开线上模式
    /// </summary>
    Leave_Online = -1
}