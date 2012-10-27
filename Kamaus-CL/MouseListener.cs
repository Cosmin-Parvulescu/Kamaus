using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamaus_CL
{
    public class MouseListenerMock : Interfaces.IMouseEvents
    {
        public event EventHandler MouseMove;
        public event EventHandler MouseLeftClick;
        public event EventHandler MouseRightClick;
        public event EventHandler MouseDoubleClick;

        public void MoveMouse(int x, int y)
        {
            OnMouseMove(new Interfaces.MouseMoveEventArgs()
            {
                newX = x,
                newY = y
            });
        }
        public void OnMouseMove(Interfaces.MouseMoveEventArgs e)
        {
            if (MouseMove != null)
            {
                MouseMove(this, e);
            }
        }

        public void LeftClickMouse()
        {
            OnMouseLeftClick(new Interfaces.MouseEventArgs());
        }
        public void OnMouseLeftClick(Interfaces.MouseEventArgs e)
        {
            if (MouseLeftClick != null)
            {
                MouseLeftClick(this, e);
            }
        }

        public void RightClickMouse(int _x, int _y)
        {
            OnMouseRightClick(new Interfaces.MouseEventArgs());
        }
        public void OnMouseRightClick(Interfaces.MouseEventArgs e)
        {
            if (MouseRightClick != null)
            {
                MouseRightClick(this, e);
            }
        }

        public void DoubleClickMouse(int _x, int _y)
        {
            OnMouseDoubleClick(new Interfaces.MouseEventArgs());
        }
        public void OnMouseDoubleClick(Interfaces.MouseEventArgs e)
        {
            if (MouseDoubleClick != null)
            {
                MouseDoubleClick(this, e);
            }
        }
    }
}
