using System;
using System.Drawing;
using System.Globalization;
using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        // creating a list to holding a shape
        List<Shape> shapes = new List<Shape>();

        //adding different shapes to the list
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        //iterating through the list by display color and areas for each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.Color}, Area: {shape.GetArea()}");        }
        
    }
}

// Base class for shapes
public class Shape
{
    public string Color { get; set; }

    // Constructor
    public Shape(string color)
    {
        Color = color;
    }

    // Virtual method for calculating area
    public virtual double GetArea()
    {
        return 0; // Default implementation for unknown shapes
    }
}

// Derived class for squares
public class Square : Shape
{
    private double _side;

    // Constructor
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override GetArea method
    public override double GetArea()
    {
        return _side * _side;
    }
}

// Derived class for rectangles
public class Rectangle : Shape
{
    private double _length;
    private double _width;

    // Constructor
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Override GetArea method
    public override double GetArea()
    {
        return _length * _width;
    }
}

// Derived class for circles
public class Circle : Shape
{
    private double _radius;

    // Constructor
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override GetArea method
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}
