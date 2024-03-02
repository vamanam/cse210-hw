using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");
         // Prompt the user for their first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompt the user for their last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Concatenate the strings and display the formatted output
        string fullName = $"{lastName}, {firstName} {lastName}.";
        Console.WriteLine($"Your name is {fullName}");

        // Wait for user input to exit
        Console.ReadLine();
    }

}