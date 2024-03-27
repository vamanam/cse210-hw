using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");
        // Testing MathAssignment
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());     // Roberto Rodriguez - Fractions
        Console.WriteLine(mathAssignment.GetHomeworkList()); // Section 7.3 Problems 8-19

        // Testing WritingAssignment
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());           // Mary Waters - European History
        Console.WriteLine(writingAssignment.GetWritingInformation()); // The Causes of World War II by Mary Waters
     }
}

// Base class for assignments
public class Assignment
{
    private string _studentName;

    // Public property to access _studentName
    public string StudentName
    {
        get { return _studentName; }
        set { _studentName = value; }
    }
       private string _topic;

    // Constructor for base class
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to get summary of the assignment
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}

// Derived class for Math assignments
public class MathAssignment : Assignment
{
    private string _section;
    private string _problems;

    // Constructor for MathAssignment
    public MathAssignment(string studentName, string topic, string section, string problems)
        : base(studentName, topic)
    {
        _section = section;
        _problems = problems;
    }

    // Method to get math homework list
    public string GetHomeworkList()
    {
        return $"Section {_section} Problems {_problems}";
    }
}

// Derived class for Writing assignments
public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor for WritingAssignment
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to get writing information
    public string GetWritingInformation()
    {
        return $"{_title} by {_studentName}";
    }
}
