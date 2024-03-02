using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
        
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        // Declare variables to store letter grade and sign
        string letter;
        string sign = "";

        // Determine the letter grade
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign for stretch challenge
        int lastDigit = gradePercentage % 10;
        if (letter != "F") // Exceptional cases A+, F+, F-
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Exceptional cases A+ and F+ or F-
        if (letter == "A" && lastDigit <= 2)
        {
            letter = "A-";
            sign = "";
        }
        else if (letter == "F" && lastDigit <= 2)
        {
            letter = "F";
            sign = "";
        }

        // Print the grade and sign
        Console.WriteLine("Your grade is: " + letter + sign);

        // Determine if the user passed the course
        if (letter != "F" && gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("You didn't pass the course. Better luck next time!");
        }
    }
}

 