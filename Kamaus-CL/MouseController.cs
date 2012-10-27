using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace Kamaus_CL
{
    public class MouseController
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        [Flags]
        private enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MOVE = 0x00000001,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        private MouseListenerMock mlm = new MouseListenerMock();

        public MouseController()
        {
            mlm.MouseMove += mlm_MouseMove;
            mlm.MouseLeftClick += mlm_MouseLeftClick;
            mlm.MouseRightClick += mlm_MouseRightClick;
            mlm.MouseDoubleClick += mlm_MouseDoubleClick;
        }
        
        void mlm_MouseDoubleClick(object sender, EventArgs e)
        {
            mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

        void mlm_MouseRightClick(object sender, EventArgs e)
        {
            mouse_event((uint)MouseEventFlags.RIGHTDOWN, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.RIGHTUP, 0, 0, 0, 0);
        }

        void mlm_MouseLeftClick(object sender, EventArgs e)
        {
            mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

        void mlm_MouseMove(object sender, EventArgs e)
        {
            Interfaces.MouseMoveEventArgs moveEvent = (Interfaces.MouseMoveEventArgs)e;
            SetCursorPos(moveEvent.newX, moveEvent.newY);
        }
    }
}
