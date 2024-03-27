using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");
         // Testing constructors
        Fraction fraction1 = new Fraction();      // 1/1
        Fraction fraction2 = new Fraction(5);     // 5/1
        Fraction fraction3 = new Fraction(3, 4);  // 3/4
        Fraction fraction4 = new Fraction(1, 3);  // 1/3

        // Testing getters and setters
        fraction1.Numerator = 2;
        fraction1.Denominator = 3;

        // Testing methods
        Console.WriteLine(fraction1.GetFractionString());  // Should print "2/3"
        Console.WriteLine(fraction1.GetDecimalValue());   // Should print approximately 0.6667

        // Displaying fractions created using different constructors
        Console.WriteLine(fraction1.GetFractionString());  // Should print "2/3"
        Console.WriteLine(fraction2.GetFractionString());  // Should print "5/1"
        Console.WriteLine(fraction3.GetFractionString());  // Should print "3/4"
        Console.WriteLine(fraction4.GetFractionString());  // Should print "1/3"
        Console.WriteLine(fraction1.GetDecimalValue());   // Should print approximately 0.6667
        Console.WriteLine(fraction2.GetDecimalValue());   // Should print 5.0
        Console.WriteLine(fraction3.GetDecimalValue());   // Should print 0.75
        Console.WriteLine(fraction4.GetDecimalValue());   // Should print approximately 0.3333
    }
}	
public class Fraction
{
    private int numerator;
    private int denominator;

    // Constructor with no parameters, initializes fraction to 1/1
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor with one parameter for the top number (numerator), initializes denominator to 1
    public Fraction(int top)
    {
        numerator = top;
        denominator = 1;
    }

    // Constructor with two parameters for both top and bottom numbers (numerator and denominator)
    public Fraction(int top, int bottom)
    {
        numerator = top;
        denominator = bottom;
    }

    // Getter and setter for numerator
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    // Getter and setter for denominator
    public int Denominator
    {
        get { return denominator; }
        set { denominator = value; }
    }

    // Method to return the fraction in the form "3/4"
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}

