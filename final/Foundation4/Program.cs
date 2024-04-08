using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation4 World!");
        // Creating activities
        List<Activity> activities = new List<Activity>();
        activities.Add(new Running(new DateTime(2022, 11, 03), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2022, 11, 03), 30, 9.7));
        activities.Add(new Swimming(new DateTime(2022, 11, 03), 30, 2));

        // Displaying summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

// Base class for activities
public class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    // Virtual methods to be overridden by derived classes
    public virtual double GetDistance()
    {
        return 0; // Default implementation
    }

    public virtual double GetSpeed()
    {
        return 0; // Default implementation
    }

    public virtual double GetPace()
    {
        return 0; // Default implementation
    }

    // GetSummary method to produce a string with all the summary information
    public virtual string GetSummary()
    {
        return $"{_date.ToShortDateString()} - {_lengthInMinutes} min";
    }
}

// Derived class for running
public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / base.GetDistance()) * 60;
    }

    public override double GetPace()
    {
        return base.GetDistance() / _distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {_distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

// Derived class for cycling
public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int lengthInMinutes, double speed) : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetDistance()
    {
        return (_speed / 60) * base.GetDistance();
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Speed: {_speed} kph, Distance: {GetDistance()} km, Pace: {GetPace()} min per km";
    }
}

// Derived class for swimming
public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000; // Convert laps to kilometers
    }

    public override double GetSpeed()
    {
        return (_laps * 50 / 1000) / base.GetDistance() * 60; // Speed in kph
    }

    public override double GetPace()
    {
        return base.GetDistance() / (_laps * 50 / 1000);
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Laps: {_laps}, Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}