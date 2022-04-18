using System;
using System.Collections.Generic;
using Basic_Geometric_Shape_Calculator.Interfaces;
using Basic_Geometric_Shape_Calculator.Classes.Shapes;


namespace Basic_Geometric_Shape_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            do
            {
                Console.WriteLine("Input 1 to calculate circle values \nInput 2 to calculate rectangle values");
               
                switch (Console.ReadLine())
                {
                    case "1":
                        calculator.UpdateShape(new Circle());
                        Console.WriteLine("Input radius");
                        if (!double.TryParse(Console.ReadLine(), out double radius)) break;
                        //area
                        double circleArea = calculator.CalculateArea(radius);
                        //perimeter
                        double circlePerimeter = calculator.CalculatePerimeter(radius);
                        //print
                        Console.WriteLine($"Circle area is {circleArea}");
                        Console.WriteLine($"Circle perimeter is {circlePerimeter}");
                        break;
                    case "2":
                        calculator.UpdateShape(new Rectangle());
                        Console.WriteLine("Input width");
                        if (!double.TryParse(Console.ReadLine(), out double width)) break;
                        Console.WriteLine("Input length");
                        if (!double.TryParse(Console.ReadLine(), out double length)) break;
                        //area
                        double rectangleArea = calculator.CalculateArea(width, length);
                        //perimeter
                        double rectanglePerimeter = calculator.CalculatePerimeter(width, length);
                        //print
                        Console.WriteLine($"Rectangle area is {rectangleArea}");
                        Console.WriteLine($"Rectangle perimeter is {rectanglePerimeter}");
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press any key to continue or write \"EXIT\" to exit");
            } while (Console.ReadLine() != "EXIT");
        }
    }
}
