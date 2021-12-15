using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace AutoQuickAssist
{
    internal enum SHOW_WINDOW_COMMANDS : int
    {
        HIDE = 0,
        NORMAL = 1,
        MINIMIZED = 2,
        MAXIMIZED = 3,
    }

    internal struct WINDOWPLACEMENT
    {
        public int length;
        public int flags;
        public SHOW_WINDOW_COMMANDS showc_cmd;
        public Point min_position;
        public Point max_position;
        public Rectangle normal_position;
    }
    class QuickAssistProsess
    {
        
        [DllImport("USER32.DLL", SetLastError = true)]
        public static extern IntPtr FindWindow(string class_name, string window_name);

        [DllImport("user32.dll")]
        internal static extern bool GetWindowPlacement(IntPtr handle, ref WINDOWPLACEMENT placement);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr windowHandle);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr quick, int howshow);
        private const int showNORMAL = 1;


        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern IntPtr GetDesktopWindow();
        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern IntPtr GetWindowDC(IntPtr window);
        //[DllImport("gdi32.dll", SetLastError = true)]
        //public static extern uint GetPixel(IntPtr dc, int x, int y);
        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern int ReleaseDC(IntPtr window, IntPtr dc);

        //public static Color GetColorAt(int x, int y)
        //{
        //    IntPtr desk = GetDesktopWindow();
        //    IntPtr dc = GetWindowDC(desk);
        //    int a = (int)GetPixel(dc, x, y);
        //    ReleaseDC(desk, dc);
        //    return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        //}


        public static int WM_QUERYENDSESSION = 0x0011;
        Mouse MouseControl = new Mouse();
        Display display = new Display();
        Color displayColor = new Color();
        Color displayColor2 = new Color();
        
        public string QuickAssistUserID { get; set; }
        Point point = new Point();
        Size size = new Size();
        IntPtr quickAssistHandle;
        public void StartQuickAssist(string ID)
        {
            this.QuickAssistUserID = ID;
            QuickAssistLogin();
        }
        private void QuickAssistLogin()
        {

            ControlQuickAssist();
            
        

            quickAssistHandle = GetQuickAssistHandle();

            if (!quickAssistHandle.Equals(IntPtr.Zero))
            {
                ShowWindowAsync(quickAssistHandle, showNORMAL);
            }

            GetWindowPos(quickAssistHandle, ref point, ref size);

            MouseControl.SaveMouseCursor();
            Cursor.Position = new Point(point.X + 122, point.Y + 535);
            displayColor = display.GetColorAt(point.X + 122, point.Y + 535);
      
            SetForegroundWindow(quickAssistHandle);
            MouseControl.LeftClick();
            // msclick(quickAssistHandle);

            Cursor.Position = new Point(MouseControl.beforeMouseCursorX, MouseControl.beforeMouseCursorY);

            displayColor = display.GetColorAt(point.X+ 306, point.Y+ 158);
            displayColor2 = display.GetColorAt(point.X + 306, point.Y + 285);
            Color color = new Color();
            color = Color.FromArgb(0, 103, 184);
            int tryCount = 0;
            while(true)
            {
                GetWindowPos(quickAssistHandle, ref point, ref size);
                displayColor2 = display.GetColorAt(point.X + 308, point.Y + 285);

                if (color.ToArgb().Equals(displayColor2.ToArgb())|| tryCount > 20)
                {
                    Cursor.Position = new Point(point.X + 306, point.Y + 158);
                    MouseControl.LeftClick();

                    Cursor.Position = new Point(point.X + 306, point.Y + 285);
                    SendKeys.SendWait("^{V}");                    
                    break;

                }
                tryCount++;
                Thread.Sleep(500);
            }
           
           // if(Color.FromArgb(0,93,163)==displayColor.ToArgb())
            //if(displayColor.R == 255 && displayColor.G == 255 && displayColor.B = 255
            //    &&displayColor2.R=0 && displayColor2.G == 93 && displayColor2.B = 166)
            //{

            //}
            //displayColor.
                

            //displayColor.ToArgb();
        }

        private void ControlQuickAssist()
        {

            SendKeys.SendWait("^{ESC}");
            SendKeys.SendWait("빠른 지원");
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(3000);
           
        }

        public IntPtr GetQuickAssistHandle()
        {
            return FindWindow(null, "빠른 지원");
        }
        private void GetWindowPos(IntPtr hwnd, ref Point point, ref Size size)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = System.Runtime.InteropServices.Marshal.SizeOf(placement);

            GetWindowPlacement(hwnd, ref placement);

            size = new Size(placement.normal_position.Right - (placement.normal_position.Left * 2), placement.normal_position.Bottom - (placement.normal_position.Top * 2));
            point = new Point(placement.normal_position.Left, placement.normal_position.Top);
        }
        
    }
}
