// Youtube Assignment
// Write a program in C# to keep track of YouTube videos and comments left on them and store the information about a video and the comments.
// Your program should have a class for a Video that has the responsibility to track the title, author, and length (in seconds) of the video. Each video also has responsibility to store a list of comments, and should have a method to return the number of comments. A comment should be defined by the Comment class which has the responsibility for tracking both the name of the person who made the comment and the text of the comment.
// Once you have the classes in place, write a program that creates 3 videos, sets the appropriate values, and for each one add a list of 3 comments (with the commenter's name and text). Put each of these videos in a list.



using System;
using System.Collections.Generic;

// Class to represent a comment
class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Class to represent a video
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    // Add a comment to the video
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Return the number of comments
    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    // Return the list of comments (for display)
    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Program
{
    static void Main()
    {
        // Create videos
        Video video1 = new Video("C# Basics Tutorial", "Alice", 600);
        Video video2 = new Video("Advanced LINQ Queries", "Bob", 900);
        Video video3 = new Video("ASP.NET Core Introduction", "Charlie", 1200);

        // Add comments to video 1
        video1.AddComment(new Comment("John", "Great tutorial, thanks!"));
        video1.AddComment(new Comment("Emma", "Very helpful explanation."));
        video1.AddComment(new Comment("Mike", "Can you do one on delegates?"));

        // Add comments to video 2
        video2.AddComment(new Comment("Sara", "LINQ is so powerful!"));
        video2.AddComment(new Comment("Tom", "Thanks for the advanced tips."));
        video2.AddComment(new Comment("Nina", "Can you explain query syntax next time?"));

        // Add comments to video 3
        video3.AddComment(new Comment("Alex", "Perfect intro for beginners."));
        video3.AddComment(new Comment("Sophia", "Looking forward to more ASP.NET videos."));
        video3.AddComment(new Comment("David", "Can you cover Razor Pages?"));

        // List to hold videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine(); // Blank line for readability
        }
    }
}