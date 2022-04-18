using System;
using System.Collections.Generic;
using System.Text;
using Basic_Geometric_Shape_Calculator.Interfaces;

namespace Basic_Geometric_Shape_Calculator.Classes.Shapes
{
    class Circle : IShape
    {
        const double pi = 3.14159265359;
        public double CalculateArea(params double[] values)
        {
            return pi * (values[0] * values[0]);
        }

        public double CalculatePerimeter(params double[] values)
        {
            return pi * (values[0] * 2);
        }
    }
}
