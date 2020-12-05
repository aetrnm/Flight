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
        static double maxDistance = (startVelocity * startVelocity * Math.Sin(2 * angle)) / g;
        static double windage = 0.95;

        static void Main()
        {
            int Hz = 60;
            double deltaTime = 1 / Hz;


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
        }

        static bool PassedTime()
        {
            return ((DateTime.Now - startTime).TotalMilliseconds % 8 == 0);
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
