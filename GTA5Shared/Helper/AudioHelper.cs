namespace GTA5Shared.Helper;

public static class AudioHelper
{
    public static readonly SoundPlayer SP_Click01 = new(Properties.Resources.Click_01);
    public static readonly SoundPlayer SP_Click02 = new(Properties.Resources.Click_02);
    public static readonly SoundPlayer SP_Click03 = new(Properties.Resources.Click_03);
    public static readonly SoundPlayer SP_Click04 = new(Properties.Resources.Click_04);
    public static readonly SoundPlayer SP_Click05 = new(Properties.Resources.Click_05);

    /// <summary>
    /// 点击提示音索引
    /// </summary>
    public static Audio ClickAudio { get; set; } = Audio.None;

    /// <summary>
    /// 播放点击音效
    /// </summary>
    public static void PlayClickSound()
    {
        switch (ClickAudio)
        {
            case Audio.None:
                break;
            case Audio.Sound1:
                SP_Click01.Play();
                break;
            case Audio.Sound2:
                SP_Click02.Play();
                break;
            case Audio.Sound3:
                SP_Click03.Play();
                break;
            case Audio.Sound4:
                SP_Click04.Play();
                break;
            case Audio.Sound5:
                SP_Click05.Play();
                break;
        }
    }

    public enum Audio
    {
        None,
        Sound1,
        Sound2,
        Sound3,
        Sound4,
        Sound5
    }
}
