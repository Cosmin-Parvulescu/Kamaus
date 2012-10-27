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
            EuclideanColorFiltering filter = new EuclideanColorFiltering();
            // set center colol and radius
            filter.CenterColor = new AForge.Imaging.RGB(Color.FromArgb(62, 204, 133));
            filter.Radius = 60;
            // apply the filter
            filter.ApplyInPlace(image);

            image.RotateFlip(RotateFlipType.RotateNoneFlipX);

            return image;
        }
    }
}
