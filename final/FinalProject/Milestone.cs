public class Milestone
{
    public string _name { get; private set; }
    private DateTime _date { get; set; }
    private string _description { get; set; }
    private bool _isComplete { get; set; }

    public Milestone(string name, DateTime date, string description)
    {
        _name = name;
        _date = date;
        _description = description;
        _isComplete = false;
    }

    public void IsComplete()
    {
        try
        {
            Console.Write($"Is the milestone {_name} complete? (Y/N) ");
            string report = Console.ReadLine().ToUpper(); // Convert input to uppercase for case-insensitive comparison

            if (report == "Y")
            {
                _isComplete = true;
                Console.WriteLine($"Milestone {_name} marked as complete.");
            }
            else if (report == "N")
            {
                _isComplete = false;
                Console.WriteLine($"Milestone {_name} is not complete.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'N' for No.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }

    public TimeSpan CalcRemainingTime()
    {
        DateTime now = DateTime.Now;
        TimeSpan remaining = now.Subtract(_date);
        return remaining;
    }

    public string IsLate()
    {
        DateTime now = DateTime.Now;
        if(now > _date)
        {
            return "The task is late";
        }
        else
        {
            return "The task is not late";
        }
    }

    public void ShowDetails()
    {
        Console.WriteLine($"{_name}, {_description}, {_date}, {_isComplete}");
    }
}
