using System.Globalization;

public class Task
{
    public int _taskNumber { get; set; }
    public string _taskName { get; set; }
    public string _description { get; set; }
    public Employee _designer { get; set; }
    public DateTime _startDate { get; set; }
    public DateTime _dueDate { get; set; }
    public Status _status { get; set; }
    public bool _isComplete { get; set; }

    public Task(int taskNumber, string taskName, string description, Employee designer, DateTime startDate, DateTime dueDate)
    {
        _taskNumber = taskNumber;
        _taskName = taskName;
        _description = description;
        _designer = designer;
        _startDate = startDate;
        _dueDate = dueDate;
        _status = Status.NotStarted;
        _isComplete = false;
    }

    public void ChangeStatus()
    {
        try
        {
            do
            {
                Console.WriteLine("Select the task status: "
                        + "1. In progress"
                        + "2. Stopped"
                        + "3. Not started"
                        + "4. Complete");
                if (!int.TryParse(Console.ReadLine(), out int status)) // Gets the user input as a number, if the user types anything different, this will repeat
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (status)
                {
                    case 1:
                        _status = Status.InProgress;
                        break;
                    case 2:
                        _status = Status.Stopped;
                        break;
                    case 3:
                        _status = Status.NotStarted;
                        break;
                    case 4:
                        IsComplete();
                        break;
                    default:
                        Console.WriteLine("Please select 1, 2 or 3");
                        return;
        }
            } while(true);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }

    public void IsComplete()
    {
        try
        {
            Console.Write($"Is the task {_taskName} complete? (Y/N) ");
            string report = Console.ReadLine().ToUpper(); // Convert input to uppercase for case-insensitive comparison

            if (report == "Y")
            {
                _status = Status.Complete;
                _isComplete = true;
                Console.WriteLine($"Task {_taskName} marked as complete.");
            }
            else if (report == "N")
            {
                _status = Status.InProgress; // Reset status if task is not complete
                _isComplete = false;
                Console.WriteLine($"Task {_taskName} is not complete.");
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

    public void ChangeDueDate()
    {
        Console.Write("What is the new due date? (dd/MM/yyyy HH:mm:ss)");
        DateTime dueDate = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        _dueDate = dueDate;
    }

    public string ShowTaskDetails()
    {
        return $"{_taskNumber}, {_taskName}, {_description}, {_designer}, {_startDate}, {_dueDate}, {_status}, {_isComplete}";
    }

    public void ChangeTaskDesigner(Employee employee)
    {

    }
}
