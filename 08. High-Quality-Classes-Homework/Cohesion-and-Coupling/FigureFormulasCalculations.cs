using System;

namespace CohesionAndCoupling
{
    static class FigureFormulaCalculations
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalcVolume(double figureWidth, double figureHeight, double figureDepth)
        {
            double volume = figureWidth * figureHeight * figureDepth;
            return volume;
        }

        public static double CalcDiagonalXYZ(double figureWidth, double figureHeight, double figureDepth)
        {
            double distance = CalcDistance3D(0, 0, 0, figureWidth, figureHeight, figureDepth);
            return distance;
        }

        public static double CalcDiagonalXY(double figureWidth, double figureHeight)
        {
            double distance = CalcDistance2D(0, 0, figureWidth, figureHeight);
            return distance;
        }

        public static double CalcDiagonalXZ(double figureWidth, double figureDepth)
        {
            double distance = CalcDistance2D(0, 0, figureWidth, figureDepth);
            return distance;
        }

        public static double CalcDiagonalYZ(double figureHeight, double figureDepth)
        {
            double distance = CalcDistance2D(0, 0, figureHeight, figureDepth);
            return distance;
        }
    }
}
