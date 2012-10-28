
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AForge.Imaging.Filters;
using AForge.Imaging;

namespace Kamaus_CL
{
    public static class BlobDetector
    {
        static AForge.Point lastPos;
        public static bool detected = false;

        public static AForge.Point GetRedBlobCenter(Bitmap image)
        {
            BlobCounter bCounter = new BlobCounter();
            bCounter.ProcessImage(image);

            Blob[] blobs = bCounter.GetObjectsInformation();
            Rectangle[] rects = bCounter.GetObjectsRectangles();

            Pen pen = new Pen(Color.Red, 2);
            Brush brush = new SolidBrush(Color.Red);
            Graphics g = Graphics.FromImage(image);

            if (rects.Length > 0) { g.FillRectangle(brush, rects[0]); }

            if (blobs.Length > 0)
            {

                detected = true;
                lastPos = blobs[0].CenterOfGravity;

                AForge.Point rPos = new AForge.Point();
                rPos.Y = ((lastPos.Y / 5) / 100) * 768;
                rPos.X = ((lastPos.X / 5) / 100) * 1366;

                return rPos;
            }
            else
            {
                detected = false;
                if (lastPos != null)
                {
                    return lastPos;
                }
                else
                {
                    return new AForge.Point(50.0f, 50.0f);
                }
            }
        }
    }
}
