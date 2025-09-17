// Journal Program

using System;
using System.Collections.Generic;
using System.IO;

// User entry-point
// class = journal entry 
class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"Date: {Date.ToShortDateString()}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
// Couldn't get date to input and display properly
    public string ToFileFormat()
    {
        return $"{Date.ToString("yyyy-MM-dd")}|{Prompt}|{Response}";
    }

    public static JournalEntry FromFileFormat(string line)
    {
        var parts = line.Split('|');
        if (parts.Length != 3) throw new Exception("Invalid entry format.");
        return new JournalEntry
        {
            Date = DateTime.Parse(parts[0]),
            Prompt = parts[1],
            Response = parts[2]
        };
    }
}

class Journal
{

    // journal prompts
    // need code to display 1 at random
    private List<JournalEntry> entries = new List<JournalEntry>();
    private List<string> prompts = new List<string>
    {
        "Did anything unforgettable happen?",
        "Overall was your day bad or good?",
        "What are you grateful for right now?",
        "Did someone make a difference for you today?",
        "Do you have any regrets from today?"
    };

    private Random random = new Random();

    // Need user input response to save

    public void AddEntry()
    {
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        var entry = new JournalEntry
        {
            Prompt = prompt,
            Response = response,
            Date = DateTime.Now
        };

        entries.Add(entry);
        Console.WriteLine("Entry added!\n");
    }

    

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.\n");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    //Need entry to save to file 

    public void SaveToFile()
    {
        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine(entry.ToFileFormat());
                }
            }
            Console.WriteLine("Journal entry saved \n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }
    // Need entry to load from file
    // Cant get entry to load from file
    // Need new/re-vamped code here

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine();

        try
        {
            var newEntries = new List<JournalEntry>();
            foreach (var line in File.ReadAllLines(filename))
            {
                newEntries.Add(JournalEntry.FromFileFormat(line));
            }

            entries = newEntries;
            Console.WriteLine("Journal loaded successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("     Journal entry options    ");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option (1-5): ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    Console.WriteLine("Leaving");
                    break;
                default:
                    Console.WriteLine("That didn't work.\n");
                    break;
            }
        }
    }
}

