using GTA5Core.Native;
using GTA5OnlineTools.Views.ReadMe;
using GTA5Shared.Helper;

namespace GTA5OnlineTools.Utils;

public static class HackUtil
{
    /// <summary>
    /// 批量导入GTAHax代码
    /// </summary>
    /// <param name="statTxt"></param>
    public static async void ImportGTAHax(string statTxt = "")
    {
        try
        {
            var isOnleyRun = string.IsNullOrWhiteSpace(statTxt);

            if (!isOnleyRun)
                File.WriteAllText(FileHelper.File_Cache_Stat, statTxt);

            if (!ProcessHelper.IsAppRun("GTAHax"))
                ProcessHelper.OpenProcessWithWorkDir(FileHelper.File_Cache_GTAHax);

            Process pGTAHax = null;

            for (int i = 0; i < 8; i++)
            {
                // 尝试获取GTAHax进程
                var pArray = Process.GetProcessesByName("GTAHax");
                if (pArray.Length > 0)
                    pGTAHax = pArray.First();

                if (pGTAHax != null)
                    break;

                await Task.Delay(250);
            }

            if (pGTAHax is null)
            {
                NotifierHelper.Show(NotifierType.Error, "发生错误，无法获取GTAHax进程信息");
                return;
            }

            var menuHandle = IntPtr.Zero;
            var childHandle = IntPtr.Zero;
            for (int i = 0; i < 8; i++)
            {
                menuHandle = pGTAHax.MainWindowHandle;
                childHandle = Win32.FindWindowEx(menuHandle, IntPtr.Zero, "Static", null);

                if (menuHandle != IntPtr.Zero && 
                    childHandle != IntPtr.Zero)
                    break;

                await Task.Delay(250);
            }

            childHandle = Win32.FindWindowEx(menuHandle, childHandle, "Static", null);
            childHandle = Win32.FindWindowEx(menuHandle, childHandle, "Static", null);
            childHandle = Win32.FindWindowEx(menuHandle, childHandle, "Static", null);

            childHandle = Win32.FindWindowEx(menuHandle, childHandle, "Edit", null);
            childHandle = Win32.FindWindowEx(menuHandle, childHandle, "Edit", null);

            childHandle = Win32.FindWindowEx(menuHandle, childHandle, "Button", null);
            childHandle = Win32.FindWindowEx(menuHandle, childHandle, "Button", null);

            childHandle = Win32.FindWindowEx(menuHandle, childHandle, "Button", null);

            if (childHandle == IntPtr.Zero)
            {
                NotifierHelper.Show(NotifierType.Error, "GTAHax按键模拟失败，请手动点击GTAHax程序左下角《导入》按钮");
                return;
            }

            _ = Win32.SendMessage(childHandle, Win32.WM_LBUTTONDOWN, IntPtr.Zero, null);
            _ = Win32.SendMessage(childHandle, Win32.WM_LBUTTONUP, IntPtr.Zero, null);

            if (!isOnleyRun)
                NotifierHelper.Show(NotifierType.Success, "导入到GTAHax成功！游戏内应该会出现大受好评奖章\n如果无反应，请手动点击GTAHax程序左下角《导入》按钮");
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }
}
