using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");
        // Creating sample goals
        Goal simpleGoal = new SimpleGoal("Run a marathon", 1000);
        Goal eternalGoal = new EternalGoal("Read scriptures", 100);
        Goal checklistGoal = new ChecklistGoal("Attend temple", 50, 10, 500);

        // Displaying goals
        simpleGoal.DisplayGoal();
        eternalGoal.DisplayGoal();
        checklistGoal.DisplayGoal();

        // Marking goals as complete
        simpleGoal.MarkComplete();
        eternalGoal.MarkComplete();
        checklistGoal.MarkComplete();

    }
}

// Base class for goals
public class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }

    // Constructor
    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    // Method to mark the goal as complete
    public virtual void MarkComplete()
    {
        Console.WriteLine($"Goal '{Name}' marked as complete. You gained {Points} points.");
    }

    // Method to display the goal
    public virtual void DisplayGoal()
    {
        Console.WriteLine($"Goal: {Name} - Points: {Points}");
    }
}

// Class for simple goals
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    // Override MarkComplete method
    public override void MarkComplete()
    {
        base.MarkComplete();
        Console.WriteLine("Congratulations!");
    }
}

// Class for eternal goals
public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }
}

// Class for checklist goals
public class ChecklistGoal : Goal
{
    private int timesCompleted;
    private int completionThreshold;
    private int bonusPoints;

    // Constructor
    public ChecklistGoal(string name, int points, int threshold, int bonus) : base(name, points)
    {
        timesCompleted = 0;
        completionThreshold = threshold;
        bonusPoints = bonus;
    }

    // Override MarkComplete method
    public override void MarkComplete()
    {
        base.MarkComplete();
        timesCompleted++;
        if (timesCompleted >= completionThreshold)
        {
            Console.WriteLine($"Bonus: You gained an additional {bonusPoints} points!");
        }
    }

    // Override DisplayGoal method
    public override void DisplayGoal()
    {
        Console.WriteLine($"Goal: {Name} - Points: {Points} - Completed {timesCompleted}/{completionThreshold} times");
    }
}
