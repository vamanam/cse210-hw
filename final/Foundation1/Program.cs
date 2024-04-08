using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation1 World!");

         // Create videos
        Video video1 = new Video("Introduction to C#", "Programming Guru", 600);
        video1.AddComment("John Doe", "Great tutorial!");
        video1.AddComment("Jane Smith", "Very helpful, thanks!");

        Video video2 = new Video("Machine Learning Basics", "AI Enthusiast", 720);
        video2.AddComment("Alice Johnson", "Awesome explanation!");
        video2.AddComment("Bob Williams", "Could use more examples.");

        Video video3 = new Video("Cooking Pasta", "Chef Master", 480);
        video3.AddComment("Sarah Brown", "Looks delicious!");
        video3.AddComment("Mike Davis", "I'll try making this tonight.");

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display details and comments for each video
        foreach (var video in videos)
        {
            video.DisplayDetailsAndComments();
        }
    }
}

// Comment class
class Comment
{
    // Private member variables
    private string commenterName;
    private string commentText;

    // Constructor
    public Comment(string commenterName, string commentText)
    {
        this.commenterName = commenterName;
        this.commentText = commentText;
    }

    // Method to return comment details as a string
    public override string ToString()
    {
        return $"{commenterName}: {commentText}";
    }
}

// Video class
class Video
{
    // Private member variables
    private string title;
    private string author;
    private int lengthInSeconds;
    private List<Comment> comments;

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        this.title = title;
        this.author = author;
        this.lengthInSeconds = lengthInSeconds;
        this.comments = new List<Comment>();
    }

    // Method to add comment to video
    public void AddComment(string commenterName, string commentText)
    {
        comments.Add(new Comment(commenterName, commentText));
    }

    // Method to return number of comments
    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    // Method to display video details and comments
    public void DisplayDetailsAndComments()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Length: {lengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

        if (comments.Count > 0)
        {
            Console.WriteLine("Comments:");
            foreach (var comment in comments)
            {
                Console.WriteLine(comment);
            }
        }
        else
        {
            Console.WriteLine("No comments available.");
        }

        Console.WriteLine();
    }
}
