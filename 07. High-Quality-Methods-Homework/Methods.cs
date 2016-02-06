// Utility Methods for SoftUnit High-Quality Code Homework
// <copyright file="Methods.cs" company="SoftUni">
// SoftUni HomeWork
// </copyright>
namespace Methods
{
    using System;
    using System.CodeDom;

    /// <summary>
    /// Methods class which contains all utility methods
    /// </summary>
    internal class Methods
    {
        /// <summary>
        /// Calculates the Area of a Triangle
        /// </summary>
        /// <param name="a">A side of the Triangle</param>
        /// <param name="b">B side of the Triangle</param>
        /// <param name="c">C side of the Triangle</param>
        /// <returns>Returns the area of the triangle.</returns>
        protected static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                Console.Error.WriteLine("Sides should be positive.");

                return -1;
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        /// <summary>
        /// Converts Number in range (0 to 9) to number.
        /// </summary>
        /// <param name="number">The integer number</param>
        /// <returns>Returns the converted number</returns>
        protected static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentOutOfRangeException("The number must be in the range 0 to 9.");
            }
        }

        /// <summary>
        /// Finds the max element in an array of comparable elements
        /// </summary>
        /// <typeparam name="T">The type of the elements</typeparam>
        /// <param name="elements">The elements array</param>
        /// <returns>Returns the max element</returns>
        protected static T FindMax<T>(params T[] elements) where T : IComparable
        {
            if (elements == null)
            {
                throw new ArgumentNullException("elements", "The elements' array cannot be null.");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("The elements' array cannot be empty.");
            }

            T maxElement = default(T);
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i].CompareTo(elements[0]) > 0)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        /// <summary>
        /// Prints an object as a number in specified format.
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="format">The format to be printed in.</param>
        protected static void PrintAsNumber(object number, string format)
        {
            if (!IsObjectNumeric(number))
            {
                throw new ArgumentException("Invalid input argument.Number(object) must be with a numeric value");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new FormatException("Invalid format string");
            }
        }

        /// <summary>
        /// Calculates the 3D distance between two points
        /// </summary>
        /// <param name="x1">First point's X</param>
        /// <param name="y1">First point's Y</param>
        /// <param name="x2">Second point's X</param>
        /// <param name="y2">Second point's Y</param>
        /// <param name="isHorizontal">The address where the check for horizontal points will be stored</param>
        /// <param name="isVertical">The address where the check for vertical points will be stored</param>
        /// <returns>Returns the distance.</returns>
        protected static double CalcDistance(
            double x1,
            double y1,
            double x2,
            double y2,
            out bool isHorizontal,
            out bool isVertical)
        {
            isHorizontal = y1 == y2;
            isVertical = x1 == x2;

            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        /// <summary>
        /// The Main function of the program
        /// </summary>
        private static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }

        /// <summary>
        /// Checks if an objects is a Number
        /// </summary>
        /// <param name="number">The object to be checked</param>
        /// <returns>Returns True if is a number or False if is not.</returns>
        private static bool IsObjectNumeric(object number)
        {
            if (number is byte ||
                number is sbyte ||
                number is short ||
                number is ushort ||
                number is int ||
                number is uint ||
                number is long ||
                number is ulong ||
                number is float ||
                number is double ||
                number is decimal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

/****** Пусни СтайлКоп-а, би трябвало да няма грешки :) ******/
