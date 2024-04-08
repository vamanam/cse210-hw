using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation3 World!");
        
        // Create Address objects
        Address address1 = new Address("123 Main St", "Cityville", "Stateville", "12345");
        Address address2 = new Address("456 Elm St", "Townsville", "Stateton", "67890");

        // Create events of each type
        Lecture lectureEvent = new Lecture("Lecture Title", "Lecture Description", new DateTime(2024, 2, 28), new TimeSpan(13, 0, 0), address1, "John Doe", 50);
        Reception receptionEvent = new Reception("Reception Title", "Reception Description", new DateTime(2024, 3, 15), new TimeSpan(18, 30, 0), address2, "example@example.com");
        OutdoorGathering outdoorEvent = new OutdoorGathering("Outdoor Gathering Title", "Outdoor Gathering Description", new DateTime(2024, 4, 20), new TimeSpan(16, 0, 0), address1, "Sunny");

        // Call methods to generate marketing messages
        Console.WriteLine("Marketing Messages:\n");
        Console.WriteLine("Lecture Event:");
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine(lectureEvent.GetShortDescription());

        Console.WriteLine("\nReception Event:");
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine(receptionEvent.GetShortDescription());

        Console.WriteLine("\nOutdoor Gathering Event:");
        Console.WriteLine(outdoorEvent.GetStandardDetails());
        Console.WriteLine(outdoorEvent.GetFullDetails());
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}

// Base class for Event
class Event
{
    // Private member variables
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    // Constructor
    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    // Method to generate standard details message
    public virtual string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}\n";
    }

    // Method to generate full details message
    public virtual string GetFullDetails()
    {
        return GetStandardDetails(); // Base class doesn't have additional details
    }

    // Method to generate short description message
    public virtual string GetShortDescription()
    {
        return $"Type: Event\nTitle: {title}\nDate: {date.ToShortDateString()}\n";
    }
}

// Derived class for Lecture event
class Lecture : Event
{
    // Private member variables specific to Lecture
    private string speaker;
    private int capacity;

    // Constructor
    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    // Override method to generate full details message for Lecture
    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $"Type: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}\n";
    }
}

// Derived class for Reception event
class Reception : Event
{
    // Private member variables specific to Reception
    private string rsvpEmail;

    // Constructor
    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    // Override method to generate full details message for Reception
    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $"Type: Reception\nRSVP Email: {rsvpEmail}\n";
    }
}

// Derived class for OutdoorGathering event
class OutdoorGathering : Event
{
    // Private member variables specific to OutdoorGathering
    private string weatherForecast;

    // Constructor
    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    // Override method to generate full details message for OutdoorGathering
    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $"Type: Outdoor Gathering\nWeather Forecast: {weatherForecast}\n";
    }
}

// Address class
class Address
{
    // Private member variables
    private string street;
    private string city;
    private string state;
    private string zipCode;

    // Constructor
    public Address(string street, string city, string state, string zipCode)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
    }

    // Override ToString method to display address
    public override string ToString()
    {
        return $"{street}, {city}, {state} {zipCode}";
    }
}

