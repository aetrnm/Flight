using System;
using System.Collections.Generic;
using System.Text;

namespace Flight
{
    public struct Vector3
    {
        //Init variables
        float x;
        float y;
        float z;

        //Constructor
        public Vector3(float X, float Y, float Z)
        {
            (x, y, z) = (X, Y, Z);
        }

        //Output in CW
        public override string ToString() => $"({x}, {y}, {z})";

        //Angle of vector3
        public double GetAngle()
        {
            double radians = Math.Atan2(y, x);
            double angle = radians * (180 / Math.PI);
            return angle;
        }
    }
}
