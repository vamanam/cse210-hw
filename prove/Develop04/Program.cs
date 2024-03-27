using System;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");

        int choice;
        do {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice) {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.PerformActivity();
                    break;
                case 2:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.PerformActivity();
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.PerformActivity();
                    break;
                case 0:
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        } while (choice != 0);
    }
}

// Base class for all activities
class Activity {
    protected int duration;
    protected string name;
    protected string description;

    // Constructor
    public Activity(string name, string description) {
        this.name = name;
        this.description = description;
    }

    // Common method to start the activity
    public void StartActivity() {
        Console.WriteLine($"Starting {name}: {description}");
        Console.Write("Enter duration (seconds): ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    // Common method to end the activity
    public void EndActivity() {
        Console.WriteLine($"Good job! You have completed {name} for {duration} seconds.");
        Console.WriteLine("Activity ended.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }
}

// Derived class for Breathing Activity
class BreathingActivity : Activity {
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") {}

    // Method to perform the breathing activity
    public void PerformActivity() {
        StartActivity();
        for (int i = 0; i < duration; i++) {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000); // Pause for 1 second
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }
        EndActivity();
    }
}

// Derived class for Reflection Activity
class ReflectionActivity : Activity {
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") {}

    // Method to perform the reflection activity
    public void PerformActivity() {
        StartActivity();
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        foreach (string question in questions) {
            Console.WriteLine(question);
            Thread.Sleep(3000); // Pause for 3 seconds
            // Display spinner animation during pause
        }
        EndActivity();
    }
}

// Derived class for Listing Activity
class ListingActivity : Activity {
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") {}

    // Method to perform the listing activity
    public void PerformActivity() {
        StartActivity();
        Random random = new Random();
        string listingPrompt = listingPrompts[random.Next(listingPrompts.Length)];
        Console.WriteLine(listingPrompt);
        Console.WriteLine("Think about it...");
        Thread.Sleep(5000); // Pause for 5 seconds
        Console.WriteLine("List your items...");
        // Allow user to list items (omitted for simplicity)
        Console.WriteLine("End of listing.");
        EndActivity();
    }
}
