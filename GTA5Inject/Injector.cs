using System;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace GTA5Inject;

public static class Injector
{
    /// <summary>
    /// 根据进程id注入dll
    /// </summary>
    /// <param name="pid">目标进程id</param>
    /// <param name="dllPath">dll路径</param>
    /// <param name="isSetForeWin">注入成功后是否窗口置前</param>
    public static InjectResult DLLInjector(int pid, string dllPath, bool isSetForeWin)
    {
        var result = new InjectResult
        {
            IsSuccess = false,
            Content = string.Empty
        };

        try
        {
            if (pid <= 0)
            {
                result.Content = "目标进程id不正确";
                return result;
            }

            if (!File.Exists(dllPath))
            {
                result.Content = "目标dll文件路径不存在";
                return result;
            }

            var dllName = Path.GetFileName(dllPath);
            var bytes = Encoding.Unicode.GetBytes(dllPath);

            var process = Process.GetProcessById(pid);

            if (CheckIsInjected(process, dllPath))
            {
                result.Content = $"进程 {process.ProcessName} 已经注入过dll {dllName}，请勿重复注入";
                return result;
            }

            var procHandle = Win32.OpenProcess(ProcessAccessFlags.All, false, process.Id);
            if (procHandle == IntPtr.Zero)
            {
                result.Content = $"打开进程 {process.ProcessName} 失败";
                return result;
            }

            var dllSpace = Win32.VirtualAllocEx(procHandle, IntPtr.Zero, (IntPtr)bytes.Length, AllocationType.Reserve | AllocationType.Commit, MemoryProtection.ExecuteReadWrite);
            if (dllSpace == IntPtr.Zero)
            {
                result.Content = $"为进程 {process.ProcessName} 申请内存空间 {bytes.Length} 失败";
                return result;
            }

            if (!Win32.WriteProcessMemory(procHandle, dllSpace, bytes, bytes.Length, out _))
            {
                result.Content = $"进程 {process.ProcessName} 写入DLL失败";
                return result;
            }

            var kernel32Handle = Win32.GetModuleHandle("Kernel32.dll");
            if (kernel32Handle == IntPtr.Zero)
            {
                result.Content = $"获取进程 {process.ProcessName} Kernel32.dll 模块句柄失败";
                return result;
            }

            var loadLibraryAAddress = Win32.GetProcAddress(kernel32Handle, "LoadLibraryW");
            if (loadLibraryAAddress == IntPtr.Zero)
            {
                result.Content = $"获取进程 {process.ProcessName}  LoadLibraryW 函数入口地址失败";
                return result;
            }

            var remoteThreadHandle = Win32.CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAAddress, dllSpace, 0, IntPtr.Zero);
            if (remoteThreadHandle == IntPtr.Zero)
            {
                result.Content = $"进程 {process.ProcessName} 创建远程线程失败";
                return result;
            }

            Win32.CloseHandle(remoteThreadHandle);
            Win32.CloseHandle(procHandle);

            if (isSetForeWin)
                _ = Win32.SetForegroundWindow(process.MainWindowHandle);

            result.IsSuccess = true;
            result.Content = $"进程 {process.ProcessName} 注入 {dllName} 成功";
            return result;
        }
        catch (Exception ex)
        {
            result.Content = ex.Message;
            return result;
        }
    }

    /// <summary>
    /// 检测进程是否已注入目标dll
    /// </summary>
    /// <param name="process"></param>
    /// <param name="dllPath"></param>
    /// <returns></returns>
    public static bool CheckIsInjected(Process process, string dllPath)
    {
        foreach (ProcessModule module in process.Modules)
        {
            if (module.FileName == dllPath)
            {
                return true;
            }
        }

        return false;
    }
}

public class InjectResult
{
    public bool IsSuccess { get; set; }
    public string Content { get; set; }
}
