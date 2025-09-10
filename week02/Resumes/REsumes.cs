using System;

public class Resume
{
    public string _name;

    // This should work for the lists
    public List<Job> _jobs = new List<Job>();
    // This should hopefully display properly
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        
        foreach (Job job in _jobs)
        {
            // This should display the job
            job.Display();
        }
    }
}