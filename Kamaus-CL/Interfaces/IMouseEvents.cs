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

        protected virtual void OnMouseMove(MouseMoveEventArgs e);
        protected virtual void OnMouseLeftClick(MouseEventArgs e);
        protected virtual void OnMouseRightClick(MouseEventArgs e);
        protected virtual void OnMouseDoubleClick(MouseEventArgs e);
    }

    public class MouseMoveEventArgs : EventArgs
    {
        public int lastX, lastY;
        public int newX, newY;
    }

    public class MouseEventArgs : EventArgs
    {
        public int x, y;
    }
}
