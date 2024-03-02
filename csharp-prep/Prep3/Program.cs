using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");

        bool playAgain = true;
        Random random = new Random();

        while (playAgain)
        {
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            int guess = 0;

            Console.WriteLine("Welcome to Guess My Number Game!");
            Console.WriteLine("I have picked a magic number between 1 and 100. Try to guess it!");

            // Loop until the user guesses the correct number
            while (guess != magicNumber)
            {
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Display number of guesses made
            Console.WriteLine($"You guessed the magic number in {guessCount} guesses.");

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainInput = Console.ReadLine().ToLower();
            playAgain = (playAgainInput == "yes" || playAgainInput == "y");
        }

        Console.WriteLine("Thank you for playing Guess My Number Game!");
    }
}