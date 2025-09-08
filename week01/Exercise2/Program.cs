using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A: Excellent";
        }
        else if (percent >= 80)
        {
            letter = "B: Good";
        }
        else if (percent >= 70)
        {
            letter = "C: Average";
        }
        else if (percent >= 60)
        {
            letter = "D: Poor";
        }
        else
        {
            letter = "F: Sorry friend, you failed";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Try again and never give up");
        }
    }
}