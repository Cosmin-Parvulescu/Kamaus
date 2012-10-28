using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AForge.Imaging.Filters;
using AForge;

namespace Kamaus_CL
{
    public static class Filters
    {
        public static Color oColor;
        public static bool cSet = false;

        public static Bitmap ApplyFilters(Bitmap image)
        {
            if (cSet)
            {
                // create filter
                EuclideanColorFiltering filter = new EuclideanColorFiltering();
                // set center colol and radius
                filter.CenterColor = new AForge.Imaging.RGB(oColor);
                filter.Radius = 40;
                // apply the filter
                filter.ApplyInPlace(image);
            }

            image.RotateFlip(RotateFlipType.RotateNoneFlipX);

            return image;
        }
    }
}
