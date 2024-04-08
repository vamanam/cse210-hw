using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");
        // Create and manage goals
        List<Goal> goals = new List<Goal>();

        // Add some example goals
        goals.Add(new SimpleGoal("Run a marathon", 1000));
        goals.Add(new EternalGoal("Read scriptures", 100));
        goals.Add(new ChecklistGoal("Attend the temple", 50, 10));

        // Record progress for goals
        foreach (var goal in goals)
        {
            goal.RecordProgress();
        }
    }
}


// Base class for goals
public abstract class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool Completed { get; protected set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
        Completed = false;
    }

    // Method to mark the goal as completed
    public virtual void MarkCompleted()
    {
        Completed = true;
    }

    // Method to record progress for the goal
    public abstract void RecordProgress();
}

// Simple goal class
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value)
    {
    }

    public override void RecordProgress()
    {
        if (!Completed)
        {
            Console.WriteLine($"Completed simple goal: {Name}. Gained {Value} points.");
            // Add logic to award points to user
        }
    }
}

// Eternal goal class
public class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value)
    {
    }

    public override void RecordProgress()
    {
        Console.WriteLine($"Made progress on eternal goal: {Name}. Gained {Value} points.");
        // Add logic to award points to user
    }
}

// Checklist goal class
public class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    private int progressCount;

    public ChecklistGoal(string name, int value, int targetCount) : base(name, value)
    {
        TargetCount = targetCount;
        progressCount = 0;
    }

    public override void RecordProgress()
    {
        progressCount++;
        Console.WriteLine($"Recorded progress on checklist goal: {Name}. Gained {Value} points.");

        if (progressCount == TargetCount)
        {
            MarkCompleted();
            Console.WriteLine($"Completed checklist goal: {Name}. Gained bonus points.");
            // Add logic to award bonus points to user
        }
    }
}