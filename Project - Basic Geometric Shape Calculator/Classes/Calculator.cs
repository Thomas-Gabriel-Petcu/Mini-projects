using System;
using System.Collections.Generic;
using System.Text;
using Basic_Geometric_Shape_Calculator.Interfaces;

namespace Basic_Geometric_Shape_Calculator
{
    class Calculator
    {
        IShape shape;

        public Calculator()
        {
            
        }

        public void UpdateShape(IShape shape)
        {
            this.shape = shape;
        }

        public double CalculateArea(params double[] values)
        {
            return this.shape.CalculateArea(values);
        }
        public double CalculatePerimeter(params double[] values)
        {
            return this.shape.CalculatePerimeter(values);
        }
    }
}
