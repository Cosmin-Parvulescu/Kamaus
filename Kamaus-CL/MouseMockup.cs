using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamaus_CL
{
    public class MouseMockup : Interfaces.IMouseEvents
    {
        #region Interface Implementation
        public event EventHandler MouseMove;
        public event EventHandler MouseLeftClick;
        public event EventHandler MouseRightClick;
        public event EventHandler MouseDoubleClick;

        public void OnMouseMove(Interfaces.MouseMoveEventArgs e)
        {
            if (MouseMove != null)
            {
                MouseMove(this, e);
            }
        }
        public void OnMouseLeftClick(Interfaces.MouseEventArgs e)
        {
            if (MouseLeftClick != null)
            {
                MouseLeftClick(this, e);
            }
        }
        public void OnMouseRightClick(Interfaces.MouseEventArgs e)
        {
            if (MouseRightClick != null)
            {
                MouseRightClick(this, e);
            }
        }
        public void OnMouseDoubleClick(Interfaces.MouseEventArgs e)
        {
            if (MouseDoubleClick != null)
            {
                MouseDoubleClick(this, e);
            }
        }
        #endregion

        Random rand = new Random();

        public MouseMockup() { }
        public void DoubleClick()
        {
            OnMouseDoubleClick(new Interfaces.MouseEventArgs()
            {
                x = rand.Next(500),
                y = rand.Next(500)
            });
        }
        public void LeftClick()
        {
            OnMouseLeftClick(new Interfaces.MouseEventArgs()
            {
                x = rand.Next(500),
                y = rand.Next(500)
            });
        }
        public void RightClick()
        {
            OnMouseRightClick(new Interfaces.MouseEventArgs()
            {
                x = rand.Next(500),
                y = rand.Next(500)
            });
        }
        public void MouseMove()
        {
            OnMouseMove(new Interfaces.MouseMoveEventArgs()
            {
                lastX = rand.Next(500),
                lastY = rand.Next(500),
                newX = rand.Next(500),
                newY = rand.Next(500)
            });
        }
    }
}
