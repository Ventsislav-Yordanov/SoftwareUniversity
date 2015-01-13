using System;

namespace CohesionAndCoupling
{
    static class Utils
    {
        public static double Width { get; set; }
        public static double Height { get; set; }
        public static double Depth { get; set; }

        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double x2, double y2, double z1, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));

            return distance;
        }

        public static double CalcVolume()
        {
            double volume = Utils.Width * Utils.Height * Utils.Depth;

            return volume;
        }

        public static double CalcDiagonalXYZ()
        {
            double distance = CalcDistance3D(0, 0, 0, Utils.Width, Utils.Height, Utils.Depth);

            return distance;
        }

        public static double CalcDiagonalXY()
        {
            double distance = CalcDistance2D(0, 0, Utils.Width, Utils.Height);

            return distance;
        }

        public static double CalcDiagonalXZ()
        {
            double distance = CalcDistance2D(0, 0, Utils.Width, Utils.Depth);

            return distance;
        }

        public static double CalcDiagonalYZ()
        {
            double distance = CalcDistance2D(0, 0, Utils.Height, Utils.Depth);

            return distance;
        }
    }
}