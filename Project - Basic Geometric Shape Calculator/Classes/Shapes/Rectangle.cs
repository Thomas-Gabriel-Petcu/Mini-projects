using System;
using System.Collections.Generic;
using System.Text;
using Basic_Geometric_Shape_Calculator.Interfaces;

namespace Basic_Geometric_Shape_Calculator.Classes.Shapes
{
    class Rectangle : IShape
    {
        public double CalculateArea(params double[] values)
        {
            return values[0] * values[1];
        }

        public double CalculatePerimeter(params double[] values)
        {
            return (values[0] * 2) + (values[1] * 2);
        }
    }
}
