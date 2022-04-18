using System;
using System.Collections.Generic;
using System.Text;

namespace Basic_Geometric_Shape_Calculator.Interfaces
{
    interface ICalculateAreaStrategy
    {
        double CalculateArea(params double[] values);
    }
}
