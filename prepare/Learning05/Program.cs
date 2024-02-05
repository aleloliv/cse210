using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("red", 2.0);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("blue", 2.0, 3.0);
        shapes.Add(rectangle);

        Circle circle = new Circle("yellow", 3.0);
        shapes.Add(circle);
        
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.Write("Color: " + color + ", ");
            Console.WriteLine("Area: " + area.ToString("F2"), CultureInfo.InvariantCulture);
        }
    }
}