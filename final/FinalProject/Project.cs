using System;
using System.Collections.Generic;
using System.Globalization;

public abstract class Project
{
    public int _number { get; protected set; }
    public string _projectName { get; protected set; }
    protected List<ProjectType> _projectTypes { get; set; }
    protected Client _client { get; set; }
    protected DateTime _startDate { get; set; }
    protected DateTime _dueDate { get; set; }
    public Employee _projectDesigner { get; protected set; }
    protected List<Milestone> _milestones { get; set; }
    protected Status _status { get; set; }
    public List<Task> _tasks { get; protected set; }
    protected bool _isComplete { get; set; }

    public Project(int number, string projectName, Client client, DateTime startDate, DateTime dueDate, Employee projectDesigner, List<Milestone> milestones)
    {
        _number = number;
        _projectName = projectName;
        _projectTypes = new List<ProjectType>();
        _client = client;
        _startDate = startDate;
        _dueDate = dueDate;
        _projectDesigner = projectDesigner;
        _milestones = milestones;
        _status = Status.NotStarted;
        _tasks = new List<Task>();
        _isComplete = false;
    }

    public void ChangeStatus()
    {
        try
        {
            do
            {
                Console.WriteLine("Select the project status: "
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
            Console.Write($"Is the project {_projectName} complete? (Y/N) ");
            string report = Console.ReadLine().ToUpper(); // Convert input to uppercase for case-insensitive comparison

            if (report == "Y")
            {
                _status = Status.Complete;
                _isComplete = true;
                Console.WriteLine($"Project {_projectName} marked as complete.");
            }
            else if (report == "N")
            {
                _status = Status.InProgress; // Reset status if task is not complete
                _isComplete = false;
                Console.WriteLine($"Project {_projectName} is not complete.");
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

    public void AddTask(List<Employee> employees)
    {
        try
        {
            do
            {
                Console.Write("What is the task name? ");
                string taskName = Console.ReadLine();
                
                Console.Write("What is the task description? ");
                string taskDescription = Console.ReadLine();
                
                Console.WriteLine("Available Employees:");
                for (int i = 0; i < employees.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {employees[i].GetEmployeeInfo()}");
                }
                
                if (!int.TryParse(Console.ReadLine(), out int employeeIndex) || employeeIndex < 1 || employeeIndex > employees.Count)
                {
                    Console.WriteLine("Invalid input. Please enter a valid employee index.");
                    continue;
                }
                
                Console.Write("What is the start date? (dd/MM/yyyy HH:mm:ss) ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
                {
                    Console.WriteLine("Invalid date format. Please enter the date in the specified format.");
                    continue;
                }
                
                Console.Write("What is the due date? (dd/MM/yyyy HH:mm:ss) ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate))
                {
                    Console.WriteLine("Invalid date format. Please enter the date in the specified format.");
                    continue;
                }

                Task task = new Task(_tasks.Count, taskName, taskDescription, employees[employeeIndex - 1], startDate, dueDate);
                _tasks.Add(task);
                Console.WriteLine("Task added successfully!");
                break;
                    
            } while(true);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }

    public void RemoveTask(Task task)
    {
        _tasks.Remove(task);
    }

    public void AddMilestone()
    {
        try
        {
            Console.Write("Enter milestone name: ");
            string name = Console.ReadLine();

            Console.Write("Enter milestone date (dd/MM/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                Console.WriteLine("Invalid date format. Please enter the date in the specified format.");
                return;
            }

            Console.Write("Enter milestone description: ");
            string description = Console.ReadLine();

            Milestone milestone = new Milestone(name, date, description);
            _milestones.Add(milestone);

            Console.WriteLine("Milestone added successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }

    public void RemoveMilestone()
    {
        try
        {
            Console.WriteLine("Enter the name of the milestone to remove:");
            string milestoneName = Console.ReadLine();

            Milestone milestoneToRemove = _milestones.FirstOrDefault(m => m._name.Equals(milestoneName, StringComparison.OrdinalIgnoreCase));

            if (milestoneToRemove != null)
            {
                _milestones.Remove(milestoneToRemove);
                Console.WriteLine($"Milestone '{milestoneName}' removed successfully!");
            }
            else
            {
                Console.WriteLine($"Milestone '{milestoneName}' not found!");
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
        Console.Write("What is the new due date? (dd/MM/yyyy HH/mm/ss) ");
        DateTime dueDate = DateTime.Parse(Console.ReadLine());
        _dueDate = dueDate;
    }

    public string ProjectDetails()
    {
        return $"{_number}, {_projectName}, {_client}, {_startDate}, {_dueDate}, {_projectDesigner}, {_milestones}, {_status}, {_tasks}, {_isComplete}";
    }

    public void ChangeProjectDesigner(Project project)
    {
        Employee projectDesigner = new FullTimeEmployee(1, "name", Department.Design, 1000.00);
        project._projectDesigner = projectDesigner;
    }
}