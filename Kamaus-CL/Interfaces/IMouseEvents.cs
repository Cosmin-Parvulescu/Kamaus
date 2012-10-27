using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamaus_CL.Interfaces
{
    public interface IMouseEvents
    {
        event EventHandler MouseMove;
        event EventHandler MouseLeftClick;
        event EventHandler MouseRightClick;
        event EventHandler MouseDoubleClick;
    }

    public class MouseMoveEventArgs : EventArgs
    {
        public int newX, newY;
    }

    public class MouseEventArgs : EventArgs
    {
    }
}
