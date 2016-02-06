using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                FigureFormulaCalculations.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                FigureFormulaCalculations.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Figure figure = new Figure(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", FigureFormulaCalculations.CalcVolume(figure.Width, figure.Height, figure.Depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", FigureFormulaCalculations.CalcDiagonalXYZ(figure.Width, figure.Height, figure.Depth));
            Console.WriteLine("Diagonal XY = {0:f2}", FigureFormulaCalculations.CalcDiagonalXY(figure.Width, figure.Height));
            Console.WriteLine("Diagonal XZ = {0:f2}", FigureFormulaCalculations.CalcDiagonalXZ(figure.Width, figure.Depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", FigureFormulaCalculations.CalcDiagonalYZ(figure.Height, figure.Depth));
        }
    }
}
