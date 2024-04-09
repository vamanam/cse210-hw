using System;
using System.Collections.Generic;

// Base class for all types of goals
abstract class Goal
{
    private string _title;
    protected int _value; // Change access modifier to protected

    // Constructor
    public Goal(string title, int value)
    {
        _title = title;
        _value = value;
    }

    // Abstract method to display goal details
    public abstract void DisplayGoalDetails();

    // Method to record an event and gain points
    public void RecordEvent()
    {
        Console.WriteLine($"Event recorded for goal: {_title}. You gained {_value} points!");
    }

    // Getter for title
    public string Title => _title;
}

// Class for simple goals
class SimpleGoal : Goal
{
    // Constructor
    public SimpleGoal(string title, int value) : base(title, value)
    {
    }

    // Override method to display goal details
    public override void DisplayGoalDetails()
    {
        Console.WriteLine($"[ ] Simple Goal: {Title}");
    }
}

// Class for eternal goals
class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string title, int value) : base(title, value)
    {
    }

    // Override method to display goal details
    public override void DisplayGoalDetails()
    {
        Console.WriteLine($"[ ] Eternal Goal: {Title}");
    }
}

// Class for checklist goals
class ChecklistGoal : Goal
{
    private int _requiredCount;
    private int _completedCount;

    // Constructor
    public ChecklistGoal(string title, int value, int requiredCount) : base(title, value)
    {
        _requiredCount = requiredCount;
        _completedCount = 0;
    }

    // Method to record progress for checklist goals
    public void RecordProgress()
    {
        _completedCount++;
        if (_completedCount == _requiredCount)
        {
            Console.WriteLine($"Congratulations! You completed the checklist goal: {Title}. You gained {_value * _requiredCount} points as a bonus!");
        }
        else
        {
            Console.WriteLine($"Progress recorded for checklist goal: {Title}. You gained {_value} points.");
        }
    }

    // Override method to display goal details
    public override void DisplayGoalDetails()
    {
        Console.WriteLine($"[ ] Checklist Goal: {Title}. Completed {_completedCount}/{_requiredCount} times.");
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();

        // Adding sample goals
        goals.Add(new SimpleGoal("Run a marathon", 1000));
        goals.Add(new EternalGoal("Read scriptures", 100));
        goals.Add(new ChecklistGoal("Attend the temple", 50, 10));

        // Displaying goals
        Console.WriteLine("Goals:");
        foreach (var goal in goals)
        {
            goal.DisplayGoalDetails();
        }

        // Recording events
        Console.WriteLine("\nRecording events:");
        foreach (var goal in goals)
        {
            goal.RecordEvent();
        }
    }
}
