using System.Diagnostics;

namespace Performance_of_operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class PerformanceTesting
    {
        static void Main(string[] args)
        {
            double[,] performanceDatabase = new double[4,7];
            int intPerformanceCounter = 0;
            int longPerformanceCounter = 0;
            int doublePerformanceCounter = 0;
            int decimalPerformanceCounter = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int intTestSubject = int.MinValue;
            for (int i = 0; i < 500; i++)
            {
                intTestSubject += 10;
            }
            stopwatch.Stop();
            performanceDatabase[0, 0] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                intTestSubject -= 10;
            }
            stopwatch.Stop();
            performanceDatabase[0, 1] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                ++intTestSubject;
            }
            stopwatch.Stop();
            performanceDatabase[0, 2] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                intTestSubject++;
            }
            stopwatch.Stop();
            performanceDatabase[0, 3] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                intTestSubject+=1;
            }
            stopwatch.Stop();
            performanceDatabase[0, 4] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                intTestSubject *= 3;
            }
            stopwatch.Stop();
            performanceDatabase[0, 5] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                intTestSubject /= 3;
            }
            stopwatch.Stop();
            performanceDatabase[0, 6] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();


            long longTestSubject = int.MinValue;
            for (int i = 0; i < 500; i++)
            {
                longTestSubject += 10;
            }
            stopwatch.Stop();
            performanceDatabase[1, 0] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                longTestSubject -= 10;
            }
            stopwatch.Stop();
            performanceDatabase[1, 1] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                ++longTestSubject;
            }
            stopwatch.Stop();
            performanceDatabase[1, 2] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                longTestSubject++;
            }
            stopwatch.Stop();
            performanceDatabase[1, 3] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                longTestSubject+=1;
            }
            stopwatch.Stop();
            performanceDatabase[1, 4] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                longTestSubject *= 3;
            }
            stopwatch.Stop();
            performanceDatabase[1, 5] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                longTestSubject /= 3;
            }
            stopwatch.Stop();
            performanceDatabase[1, 6] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();



            double doubleTestSubject = double.MinValue;
            for (int i = 0; i < 500; i++)
            {
                doubleTestSubject += 10;
            }
            stopwatch.Stop();
            performanceDatabase[2, 0] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                doubleTestSubject -= 10;
            }
            stopwatch.Stop();
            performanceDatabase[2, 1] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                ++doubleTestSubject;
            }
            stopwatch.Stop();
            performanceDatabase[2, 2] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                doubleTestSubject++;
            }
            stopwatch.Stop();
            performanceDatabase[2, 3] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                doubleTestSubject+=1;
            }
            stopwatch.Stop();
            performanceDatabase[2, 4] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                doubleTestSubject *= 3;
            }
            stopwatch.Stop();
            performanceDatabase[2, 5] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                doubleTestSubject /= 3;
            }
            stopwatch.Stop();
            performanceDatabase[2, 6] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();




            decimal decimalTestSubject = decimal.MinValue;
            for (int i = 0; i < 500; i++)
            {
                decimalTestSubject += 10;
            }
            stopwatch.Stop();
            performanceDatabase[3, 0] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                decimalTestSubject -= 10;
            }
            stopwatch.Stop();
            performanceDatabase[3, 1] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                ++decimalTestSubject;
            }
            stopwatch.Stop();
            performanceDatabase[3, 2] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                decimalTestSubject++;
            }
            stopwatch.Stop();
            performanceDatabase[3, 3] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                decimalTestSubject+=1;
            }
            stopwatch.Stop();
            performanceDatabase[3, 4] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                decimalTestSubject *= 0.000005m;
            }
            stopwatch.Stop();
            performanceDatabase[3, 5] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < 500; i++)
            {
                decimalTestSubject /= 2;
            }
            stopwatch.Stop();
            performanceDatabase[3, 6] = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            string[] checksList = {"+", "-", "++(prefix)", "++(postfix)", "+=1", "*", "/"};

            Console.WriteLine("n = 500");
            Console.WriteLine("{0, 30} {1, 18}  {2, 18}  {3, 18}", "int", "long", "double", "decimal");
            for (int i = 0; i < performanceDatabase.GetLength(1); i++)
            {
                Console.Write("{0,-10}", checksList[i]);
                for (int j = 0; j < performanceDatabase.GetLength(0); j++)
                {
                    Console.Write("{0, 20}", performanceDatabase[j,i]);
                }
                Console.WriteLine();
            }

            double[,] secondPerformanceDatabase = new double[1, 3];

            double doubleSecondTest = double.MaxValue;
            stopwatch.Restart();
            for (int i = 0; i < 500; i++)
            {
               Math.Sqrt(doubleSecondTest);
            }
            stopwatch.Stop();
            secondPerformanceDatabase[0, 0] = stopwatch.Elapsed.TotalMilliseconds;

            stopwatch.Restart();
            for (int i = 0; i < 500; i++)
            {
                Math.Log(doubleSecondTest);
            }
            stopwatch.Stop();
            secondPerformanceDatabase[0, 1] = stopwatch.Elapsed.TotalMilliseconds;

            stopwatch.Restart();
            for (int i = 0; i < 500; i++)
            {
                Math.Sin(doubleSecondTest);
            }
            stopwatch.Stop();
            secondPerformanceDatabase[0, 2] = stopwatch.Elapsed.TotalMilliseconds;

            string[] secondCheckList = { "Math.Sqrt()", "Math.Log()", "Math.Sin()"};
            Console.WriteLine();
            Console.WriteLine("n = 500");
            Console.WriteLine("{0, 30}", "double");
            for (int i = 0; i < secondPerformanceDatabase.GetLength(1); i++)
            {
                Console.Write("{0,-10}", secondCheckList[i]);
                for (int j = 0; j < secondPerformanceDatabase.GetLength(0); j++)
                {
                    Console.Write("{0, 20}", secondPerformanceDatabase[j, i]);
                }
                Console.WriteLine();
            }

        }
    }
}
