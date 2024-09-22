using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawers
{
    public static class Transformer
    {
        public static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public static PointF Transform(float x, float y, float angle, float distance)
        {
            double radians = DegreesToRadians(angle);

            double new_x = distance * Math.Cos(radians) + x;
            double new_y = distance * Math.Sin(radians) + y;

            return new((float)new_x, (float)new_y);
        }
    }
}
