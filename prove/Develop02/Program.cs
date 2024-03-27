using System;
using System.Collections.Generic;
using System.IO;

// Entry class to represent each journal entry
public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date}\n{Prompt}\n{Response}\n";
    }
}

// Journal class to manage entries
public class Journal
{
    private List<Entry> entries = new List<Entry>();

    // Method to add a new entry to the journal
    public void AddEntry(string prompt, string response, string date)
    {
        Entry newEntry = new Entry(prompt, response, date);
        entries.Add(newEntry);
    }

    // Method to display all entries in the journal
    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    // Method to save the journal to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine(entry);
            }
        }
    }

    // Method to load the journal from a file
    public void LoadFromFile(string filename)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string prompts = line;
                string response = reader.ReadLine();
                string date = reader.ReadLine();
                entries.Add(new Entry(prompts, response, date));
            }
        }
    }
}

// Program class to manage user interaction
public class Program
{
    static void Main(string[] args)
    {
         List<string> prompts = new List<string>(); // Declare and initialize the prompts list
        
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter your response to the prompt:");
                    string response = Console.ReadLine();
                    // Pass prompts list to GetRandomPrompt method
                    string randomPrompt = GetRandomPrompt(prompts);
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    journal.AddEntry(randomPrompt, response, date);
                    break;
                case "2":
                    Console.WriteLine("Journal Entries:");
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Method to get a random prompt from a list of prompts
    static string GetRandomPrompt(List<string> prompts)
    {
        Random rnd = new Random();
        int index = rnd.Next(prompts.Count);
        return prompts[index];
    }

}
