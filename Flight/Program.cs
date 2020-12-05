using System;
using System.Collections;
using System.Collections.Generic;

namespace Flight
{
    class Program
    {
        static DateTime startTime = DateTime.Now;

        static Vector3 vec = new Vector3(1, 1, 1);

        static double angle = vec.GetAngle();
        static double radianAngle = (Math.PI / 180) * angle;

        static double startVelocity = 10;

        static double g = 9.81;
        static double windage = 0.95;

        static int Hz = 60;
        static double deltaTime = 1000 / Hz;

        static double maxHeight = (startVelocity * startVelocity * Math.Sin(angle) * Math.Sin(angle)) / (2 * g);
        static double maxDistance = (startVelocity * startVelocity * Math.Sin(2 * angle)) / g;

        static void Main()
        {

            double x = 0;
            double y = 0;
            while (y >= 0)
            {
                if(PassedTime())
                {
                    Console.WriteLine($"x:{x} y:{y}");
                    CalculateCoordinates(ref x, ref y, ((DateTime.Now - startTime).TotalSeconds));
                }
            }

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearLastConsoleLine();

            Console.WriteLine($"x:{x} y:{0}");

            Console.WriteLine($"Max length: {x}");
            Console.WriteLine($"Max height: {maxHeight}");
            Console.WriteLine($"Time spent: {(DateTime.Now - startTime).TotalSeconds}");
        }

        static bool PassedTime()
        {
            return ((DateTime.Now - startTime).TotalMilliseconds % deltaTime < 1 || (DateTime.Now - startTime).TotalMilliseconds % deltaTime > 16);
        }

        static void CalculateCoordinates(ref double x, ref double y, double t)
        {
            x = t * maxDistance * windage;
            y = (x * Math.Tan(angle) - (g * x * x) / (2 * startVelocity * startVelocity * Math.Cos(angle) * Math.Cos(angle))) * windage;

        }

        public static void ClearLastConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
