using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UniformUI.Module.Model
{
    
    #region 窗体动画效果相关常量
    public enum WindowsEffect
    {
        AW_SLIDE = 0x40000,//使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略。    
        AW_ACTIVATE = 0x20000,//激活窗口。在使用了AW_HIDE标志后不要使用这个标志。    
        AW_BLEND = 0x80000,//使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。    
        AW_HIDE = 0x10000,//隐藏窗口，缺省则显示窗口。(关闭窗口用)    
        AW_CENTER = 0x0010,//若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展。    
        AW_HOR_POSITIVE = 0x0001,//自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。    
        AW_VER_POSITIVE = 0x0004,//自顶向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。    
        AW_HOR_NEGATIVE = 0x0002,//自右向左显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。    
        AW_VER_NEGATIVE = 0x0008//自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。    
    }
    #endregion
    
    #region 登陆模式
    public enum LoginMode 
    {
        PRODUCTION_MODE = 0,
        ENGINEERING_MODE = 1,
        CPKGRR_MODE = 2
    }
    #endregion

    #region Excel输出格式
    public enum SaveDataFormat
    {
        XLS = 0,
        CSV = 1,
        XLSX = 2
    }
    #endregion

     
    public static class Common
    {
        public static bool isShowKeyBoard = false;
        public static Action<string> AppendUiLog { get; set; }
    }

    public class GUIEventArgs : EventArgs
    {
        public string Info { get; private set; }

        public GUIEventArgs(string msg)
        {
            Info = msg;
        }
    }

    public class Utility
    {
        public static void Delay(int milliSeconds)
        {
            if (milliSeconds < 10)
            {
                Thread.Sleep(milliSeconds);
            }
            else
            {
                DateTime tStop = DateTime.Now.AddMilliseconds(milliSeconds);
                while (true)
                {
                    Thread.Sleep(10);
                    if (Application.MessageLoop) Application.DoEvents();

                    if (DateTime.Now > tStop) break;
                }
            }
        }

        public static string GetImageFilter()
        {
            return "All image types (*.bmp;*.tif;*.png;*.jpg;*.apd)|*.bmp;*.tif;*.png;*.jpg;*.apd|Bitmaps (*.bmp)|*.bmp|TIFF files (*.tif)|*.tif|PNG files (*.png)|*.png|JPEG files (*.jpg)|*.jpg|AIPD files (*.apd)|*.apd||";
        }

        public static IntPtr CheckSingleton()
        {
            IntPtr h = CreateMutex(IntPtr.Zero, true, Assembly.GetEntryAssembly().FullName);
            if (h != IntPtr.Zero)
            {
                if (Marshal.GetLastWin32Error() == ERROR_ALREADY_EXISTS)
                {
                    MessageBox.Show("应用程序已经运行！");
                    CloseHandle(h);
                    h = IntPtr.Zero;
                    return h;
                }
            }
            else
            {
                MessageBox.Show("Last Error : " + Marshal.GetLastWin32Error().ToString());
                return h;
            }

            return h;
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, bool bInitialOwner, string lpName);
        public const int ERROR_ALREADY_EXISTS = 183;

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);
    }
}
