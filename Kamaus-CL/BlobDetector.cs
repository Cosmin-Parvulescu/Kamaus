
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

        public static AForge.Point GetRedBlobCenter(Bitmap image)
        {
            BlobCounter bCounter = new BlobCounter();
            bCounter.ProcessImage(image);

            Blob[] blobs = bCounter.GetObjectsInformation();
            if (blobs.Length > 0)
            {
                lastPos = new AForge.Point(blobs[0].Rectangle.Left, blobs[0].Rectangle.Top);
                return lastPos;
            }
            else
            {
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
