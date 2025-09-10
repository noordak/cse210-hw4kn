using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");
        Console.WriteLine("Let's display some job experience.");
        // My name for display
        Resume myResume = new Resume();
        myResume._name = "Kevin Noorda";
        // My Job 
                Job job = new Job();
        job._jobTitle = "Brass Finisher";
        job._company = "Church of Jesus Christ of Latter Day Saints";
        job._startYear = 2023;
        job._endYear = 2025;


        myResume._jobs.Add(job1);
    

        myResume.Display();



    }
}