using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockScreen
{
    /// <summary>
    /// 键盘钩子(屏蔽键盘按键)
    /// </summary>
    public class Hook
    {

        //键盘Hook结构函数 
        [StructLayout(LayoutKind.Sequential)]
        public class KeyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        //委托 
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);

        private static int hHook = 0;
        public const int WH_KEYBOARD_LL = 13;

        //LowLevel键盘截获，如果是WH_KEYBOARD＝2，并不能对系统键盘截取，Acrobat Reader会在你截取之前获得键盘。 
        public HookProc KeyBoardHookProcedure;

        #region [DllImport("user32.dll")]

        //设置钩子 
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //取消钩子
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll")]
        //调用下一个钩子 
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        #endregion

        #region 安装键盘钩子

        /// <summary>
        /// 安装键盘钩子
        /// </summary>
        public void Hook_Start()
        {
            if (hHook == 0)
            {
                KeyBoardHookProcedure = new HookProc(KeyBoardHookProc);
                //MessageBox.Show(Process.GetCurrentProcess().MainModule.ModuleName);

                //MessageBox.Show(GetCurrentThreadId().ToString());
                //MessageBox.Show(GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName).ToString());
                hHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyBoardHookProcedure,
                GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);

                //如果设置钩子失败. 
                if (hHook == 0)
                {
                    Hook_Clear();
                }
            }
        }

        #endregion

        #region 取消钩子事件

        /// <summary>
        /// 取消钩子事件
        /// </summary>
        public void Hook_Clear()
        {
            bool retKeyboard = true;
            if (hHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hHook);
                hHook = 0;
            }
        }

        #endregion

        #region 屏蔽键盘

        /// <summary>
        /// 屏蔽键盘
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public static int KeyBoardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                KeyBoardHookStruct kbh = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));
                
                
                // 屏蔽左"f1-f12"
                if ((kbh.vkCode == (int)Keys.F1) || (kbh.vkCode == (int)Keys.F2) ||
                   (kbh.vkCode == (int)Keys.F3) || (kbh.vkCode == (int)Keys.F4) ||
                  (kbh.vkCode == (int)Keys.F4) || (kbh.vkCode == (int)Keys.F5) ||
                 (kbh.vkCode == (int)Keys.F6) || (kbh.vkCode == (int)Keys.F7) ||
                (kbh.vkCode == (int)Keys.F8) || (kbh.vkCode == (int)Keys.F9) ||
               (kbh.vkCode == (int)Keys.F10) || (kbh.vkCode == (int)Keys.F11) || (kbh.vkCode == (int)Keys.F1))
                {
                    return 1;
                }
                
                
                // 屏蔽左"Ctrl"、右"Ctrl"
                if ((kbh.vkCode == (int)Keys.LControlKey) || (kbh.vkCode == (int)Keys.RControlKey))
                {
                    return 1;
                }
                // 屏蔽左"alt"
                if ((kbh.vkCode == (int)Keys.Alt))
                {
                    return 1;
                }
                /* 屏蔽左"WIN"、右"Win"
                if ((kbh.vkCode == (int)Keys.LWin) || (kbh.vkCode == (int)Keys.RWin))
                {
                    return 1;
                }*/
                //屏蔽Ctrl+Esc
                if (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control)
                {
                    return 1;
                }
                //屏蔽Alt+f4 
                if (kbh.vkCode == (int)Keys.F4 && (int)Control.ModifierKeys == (int)Keys.Alt)
                {
                    return 1;
                }
                //屏蔽Alt+Esc
                if (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Alt)
                {
                    return 1;
                }
                //屏蔽Alt+Tab 
                if (kbh.vkCode == (int)Keys.Tab && (int)Control.ModifierKeys == (int)Keys.Alt)
                {
                    return 1;
                }
                //截获Ctrl+Shift+Esc 
                if (kbh.vkCode == (int)Keys.Escape &&
                (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Shift)
                {
                    return 1;
                }

                //截获Ctrl+Alt+Dle 
                if (kbh.vkCode == (int)Keys.Delete &&
                (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt)
                {
                    return 1;
                }
            }
            return CallNextHookEx(hHook, nCode, wParam, lParam);
        }

        #endregion
    }
}
