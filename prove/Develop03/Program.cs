using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");

        Reference reference = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AreAllWordsHidden())
        {
            Console.Clear();
            scripture.Display();
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            else
                scripture.HideRandomWords();
        }

        Console.WriteLine("All words in the scripture have been hidden. Press any key to exit.");
        Console.ReadKey();
   
    }
}

// Word class to represent individual words in the scripture
public class Word
{
    public string Text { get; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
}

// Reference class to represent the scripture reference
public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int endVerse = -1)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse != -1 ? endVerse : startVerse;
    }

    public override string ToString()
    {
        if (StartVerse == EndVerse)
            return $"{Book} {Chapter}:{StartVerse}";
        else
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

// Scripture class to represent the scripture including reference and text
public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(reference);
        foreach (Word word in words)
        {
            if (word.IsHidden)
                Console.Write(" ____ ");
            else
                Console.Write($" {word.Text} ");
        }
        Console.WriteLine("\nPress Enter to reveal more words or type 'quit' to exit.");
    }

    public void HideRandomWords()
    {
        Random rnd = new Random();
        int wordsToHide = rnd.Next(1, words.Count(word => !word.IsHidden));

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = rnd.Next(words.Count);
            if (!words[index].IsHidden)
                words[index].IsHidden = true;
            else
                i--; // To ensure we hide the required number of words
        }
    }

    public bool AreAllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}
