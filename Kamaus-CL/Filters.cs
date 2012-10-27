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
        public static Bitmap ApplyFilters(Bitmap image)
        {
            // create filter
            ColorFiltering filter = new ColorFiltering();
            // set color ranges to keep
            filter.Red = new IntRange(253, 255);
            filter.Green = new IntRange(0, 255);
            filter.Blue = new IntRange(0, 255);
            // apply the filter
            filter.ApplyInPlace(image);

            return image;
        }
    }
}
