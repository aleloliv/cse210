public class Resume
{
    public string _name; // { get; set; }
    public List<Job> _jobs = new List<Job>(); // { get; set; }

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}