using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
        Console.WriteLine("This time we're adding a function, I hope you're as excited as I am.");

        // I need to get  in the habit of adding notes
        // user name input here
        Console.Write("Please input your name. ");
        string name = Console.ReadLine();
        // number input and square root calculation
        Console.Write("What is your favorite number? ");
        string number = int.Parse(Console.ReadLine());
        int square = number * number


        Console.WriteLine($"{name}, the square of your number is {square}.");

    }
}