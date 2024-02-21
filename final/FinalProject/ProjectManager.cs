using System.Globalization;

public class ProjectManager
{
    private Employee _manager { get; set; }
    private List<Project> _projects { get; set; }
    private List<Employee> _employees { get; set; }

    public ProjectManager(Employee manager)
    {
        _manager = manager;
        _projects = new List<Project>();
        _employees = new List<Employee>();
    }

    public List<Project> GetProjects()
    {
        return _projects;
    }

    public List<Employee> GetEmployees()
    {
        return _employees;
    }

    private void AddProject(Project project)
    {
        _projects.Add(project);
    }

    private void RemoveProject(Project project)
    {
        _projects.Remove(project);
    }

    private void AddEmployee(Employee employee)
    {
        _employees.Add(employee);
    }

    private void RemoveEmployee(Employee employee)
    {
        _employees.Remove(employee);
    }



    public void ProjectMenu()
    {
        bool exit = false;
        do
        {
            Console.WriteLine("Project Menu");
            Console.WriteLine("1. Create Project");
            Console.WriteLine("2. Delete Project");
            Console.WriteLine("3. Change Project Designer");
            Console.WriteLine("4. Change Project Manager");
            Console.WriteLine("5. Show Projects");
            Console.WriteLine("6. Select Project");
            Console.WriteLine("0. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateProject();
                    break;
                case "2":
                    Console.WriteLine("Enter project number to delete:");
                    int projectNumber = int.Parse(Console.ReadLine());
                    var projectToDelete = GetProjects().FirstOrDefault(p => p._number == projectNumber);
                    if (projectToDelete != null)
                    {
                        DeleteProject(projectToDelete);
                    }
                    else
                    {
                        Console.WriteLine("Project not found.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter project number to change designer:");
                    int projectNumberToChangeDesigner = int.Parse(Console.ReadLine());
                    var projectToChangeDesigner = GetProjects().FirstOrDefault(p => p._number == projectNumberToChangeDesigner);
                    if (projectToChangeDesigner != null)
                    {
                        projectToChangeDesigner.ChangeProjectDesigner(projectToChangeDesigner);
                    }
                    else
                    {
                        Console.WriteLine("Project not found.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter project number to change manager:");
                    int projectNumberToChangeManager = int.Parse(Console.ReadLine());
                    var projectToChangeManager = GetProjects().FirstOrDefault(p => p._number == projectNumberToChangeManager);
                    if (projectToChangeManager != null)
                    {
                        ChangeProjectManager(projectToChangeManager);
                    }
                    else
                    {
                        Console.WriteLine("Project not found.");
                    }
                    break;
                case "5":
                    ShowProjects();
                    break;
                case "6":
                    if (GetProjects().Count == 0)
                    {
                        Console.WriteLine("No projects available. Please create a project first.");
                        return;
                    }

                    Console.WriteLine("Select a project to manage tasks:");
                    foreach (var project in GetProjects())
                    {
                        Console.WriteLine($"{project._number}. {project._projectName}");
                    }

                    int projectNumberSelect = int.Parse(Console.ReadLine());
                    var selectedProject = GetProjects().FirstOrDefault(p => p._number == projectNumberSelect);
                    if (selectedProject != null)
                    {
                        TaskMenu(selectedProject);
                    }
                    else
                    {
                        Console.WriteLine("Invalid project number.");
                    }
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from the menu.");
                    break;
            }
        } while (!exit);
    }

    public void CreateProject()
    {
        // Check if there are employees available
        if (GetEmployees().Count == 0)
        {
            Console.WriteLine("No employees available. Please hire employees first.");
            return;
        }
        try
        {
            Console.Write("Enter project number: ");
            int projectNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter project name: ");
            string projectName = Console.ReadLine();

            // Prompt user for client details
            Console.Write("Enter client name: ");
            string clientName = Console.ReadLine();
            Console.Write("Enter client phone: ");
            string clientPhone = Console.ReadLine();
            Console.Write("Enter client email: ");
            string clientEmail = Console.ReadLine();
            // Create a new Client object
            Client client = new Client(clientName, clientPhone, clientEmail);

            // Prompt user for project value
            Console.Write("Enter project value (dollars): ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Prompt user for project start date
            Console.Write("Enter project start date (dd/MM/yyyy HH:mm:ss): ");
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            // Prompt user for project due date
            Console.Write("Enter project due date (dd/MM/yyyy HH:mm:ss): ");
            DateTime dueDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            // Prompt user for project designer details
            Console.WriteLine("Employees:");
            for(int i = 1; i < GetEmployees().Count; i++)
            {
                Console.WriteLine($"{i}. {GetEmployees()[i].GetEmployeeInfo()}");
            }
            Console.Write("Enter project designer number: ");
            int empNum = int.Parse(Console.ReadLine());
            Employee projectDesigner = GetEmployees()[empNum];            

            // Create an empty list of milestones for now
            List<Milestone> milestones = new List<Milestone>();

            // Create the Project object
            Project project;

            Console.WriteLine("What kind of project is this?");
            Console.WriteLine("1. Electrical");
            Console.WriteLine("2. Cabling");
            Console.WriteLine("3. Automation");
            Console.WriteLine("4. Access Control");
            Console.WriteLine("5. Security Camera");
            Console.WriteLine("6. Audiovisual");
            Console.WriteLine("7. Fire Alarm and Detection");
            int projectSelection = int.Parse(Console.ReadLine());

            switch (projectSelection)
            {
                case 1:
                    project = new ElectricalProject(projectNumber, projectName, client, value, startDate, dueDate, projectDesigner, milestones);
                    // Add the project to the list of projects
                    AddProject(project);
                    break;
                case 2:
                    project = new CablingProject(projectNumber, projectName, client, value, startDate, dueDate, projectDesigner, milestones);
                    // Add the project to the list of projects
                    AddProject(project);
                    break;
                case 3:
                    project = new AutomationProject(projectNumber, projectName, client, value, startDate, dueDate, projectDesigner, milestones);
                    // Add the project to the list of projects
                    AddProject(project);
                    break;
                case 4:
                    project = new AccessControlProject(projectNumber, projectName, client, value, startDate, dueDate, projectDesigner, milestones);
                    // Add the project to the list of projects
                    AddProject(project);
                    break;
                case 5:
                    project = new SecurityCameraProject(projectNumber, projectName, client, value, startDate, dueDate, projectDesigner, milestones);
                    // Add the project to the list of projects
                    AddProject(project);
                    break;
                case 6:
                    project = new AudiovisualProject(projectNumber, projectName, client, value, startDate, dueDate, projectDesigner, milestones);
                    // Add the project to the list of projects
                    AddProject(project);
                    break;
                case 7:
                    project = new FireAlarmDetectionProject(projectNumber, projectName, client, value, startDate, dueDate, projectDesigner, milestones);
                    // Add the project to the list of projects
                    AddProject(project);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a number between 1 and 7.");
                    break;
            }

            for (int i = 0; i < GetEmployees().Count; i++)
            {
                if (GetEmployees()[i]._department == Department.Commercial)
                {
                    if (GetEmployees()[i] is ProjectSeller)
                    {
                        ProjectSeller seller = (ProjectSeller)GetEmployees()[i];
                        seller.SellProject();
                    }
                }
            }

            Console.WriteLine("Project created successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }

    public void DeleteProject(Project project)
    {
        try
        {
            do
            {
                Console.Write($"Are you sure you want to delete {project._projectName}? (Y/N)");
                string answer = Console.ReadLine().ToUpper();

                if(answer == "Y")
                {
                    RemoveProject(project);
                    Console.WriteLine($"{project._projectName} deleted.");
                    break;
                }
                else if(answer == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please select Y or N");
                }
            } while(true);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }

    public void ChangeProjectManager(Project project)
    {
        if (project == null)
        {
            Console.WriteLine("Project not found.");
            return;
        }
        Employee manager = new Manager(2, "name", Department.Management, 1000.00);
        ProjectManager projectManager = new ProjectManager(manager);
        projectManager.AddProject(project);
    }

    public void ShowProjects()
    {
        for(int i = 0; i < GetProjects().Count; i++)
        {
            Console.WriteLine($"{i + 1}. {GetProjects()[i].ProjectDetails()}");
        }
    }

    public Project SelectProject()
    {
        try
        {
            ShowProjects();
            int projNum = int.Parse(Console.ReadLine());

            if (projNum < 1 || projNum > GetProjects().Count)
            {
                Console.WriteLine("Invalid project number.");
                return null;
            }

            Project project = GetProjects()[projNum - 1];
            return project;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public void TaskMenu(Project project)
    {
        bool exit = false;
        do
        {
            Console.WriteLine($"Tasks for Project: {project._projectName}");
            Console.WriteLine("1. Create Task");
            Console.WriteLine("2. Delete Task");
            Console.WriteLine("3. Change Task Designer");
            Console.WriteLine("4. Show Project Tasks");
            Console.WriteLine("0. Exit");

            List<Employee> designers = new List<Employee>();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    foreach(Employee e in GetEmployees())
                    {
                        if(e._department is Department.Design)
                        {
                            designers.Add(e);
                        }
                    }
                    Task newTask = CreateTask(designers);
                    project.AddTask(newTask);
                    break;
                case "2":
                    Console.WriteLine("Enter task number to delete:");
                    int taskNumber = int.Parse(Console.ReadLine());
                    var taskToDelete = project._tasks.FirstOrDefault(t => t._taskNumber == taskNumber);
                    if (taskToDelete != null)
                    {
                        project.RemoveTask(taskToDelete);
                    }
                    else
                    {
                        Console.WriteLine("Task not found.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter task number to change designer:");
                    for(int i = 0; i < designers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. " + project._tasks[i].ShowTaskDetails());
                    }
                    int taskIndex = int.Parse(Console.ReadLine());
                    Task task = project._tasks[taskIndex];
                    
                    Console.WriteLine("Pick a designer:");
                    for(int i = 0; i < designers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. " + designers[i].GetEmployeeInfo());
                    }
                    int designerIndex = int.Parse(Console.ReadLine());
                    Employee designer = designers[designerIndex - 1];
                    if (task != null)
                    {
                        task.ChangeTaskDesigner(designer);
                    }
                    else
                    {
                        Console.WriteLine("Task not found.");
                    }
                    break;
                case "4":
                    foreach(Task t in project._tasks)
                    {
                        Console.WriteLine(t.ShowTaskDetails());
                    }
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from the menu.");
                    break;
            }
        } while (!exit);
    }

    public Task CreateTask(List<Employee> designers)
    {
        try
        {
            // Get user input for task number
            Console.Write("Enter project number: ");
            int taskNumber = int.Parse(Console.ReadLine());

            // Get user input for task name
            Console.Write("Enter task name: ");
            string taskName = Console.ReadLine();

            // Get user input for task description
            Console.Write("Enter task description: ");
            string taskDescription = Console.ReadLine();

            // Get employee assigned to task
            Console.WriteLine("Which employee is assigned for this task?");
            for(int i = 1; i < designers.Count; i++)
            {
                Console.WriteLine($"{i}. {designers[i].GetEmployeeInfo()}");
            }
            Employee taskDesigner = designers[int.Parse(Console.ReadLine())];

            // Get user input for task start date
            Console.Write("Enter task start date (dd/MM/yyyy HH:mm:ss): ");
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            // Get user input for task due date
            Console.Write("Enter task due date (dd/MM/yyyy HH:mm:ss): ");
            DateTime dueDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            Task task = new Task(taskNumber, taskName, taskDescription, taskDesigner, startDate, dueDate);

            return task;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public void DeleteTask(Project project)
    {
        if (project._tasks.Count == 0)
        {
            Console.WriteLine("There are no tasks in this project.");
            return;
        }
        Console.WriteLine("Select task to delete:");
        ShowProjectTasks(project);
        int taskNum = int.Parse(Console.ReadLine());
        Task task = project._tasks[taskNum];
        project.RemoveTask(task);
    }

    public void ShowProjectTasks(Project project)
    {
        for(int i = 1; i < project._tasks.Count; i++)
        {
            Console.WriteLine($"{i}. {project._tasks[i].ShowTaskDetails()}");
        }
    }

    public void EmployeeMenu()
    {
        try
        {
            do
            {
                Console.WriteLine("Employee Menu");
                Console.WriteLine("1. Hire new employee");
                Console.WriteLine("2. Fire employee");
                Console.WriteLine("3. Pay employees");
                Console.WriteLine("4. Show employees");
                Console.WriteLine("0. Exit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 0 and 4.");
                    continue;
                }

                switch(choice)
                {
                    case 1:
                        Employee employee = HireNewEmployee();
                        AddEmployee(employee);
                        break;
                    case 2:
                        Console.WriteLine("Select employee:");
                        for(int i = 1; i<GetEmployees().Count; i++)
                        {
                            Console.WriteLine($"{i}. {GetEmployees()[i].GetEmployeeInfo()}");
                        }
                        int empNum = int.Parse(Console.ReadLine());
                        Employee fired = GetEmployees()[empNum];
                        FireEmployee(fired);
                        break;
                    case 3:
                        PayEmployees(GetEmployees());
                        break;
                    case 4:
                        ShowEmployees();
                        break;
                    case 0:
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

    public Employee HireNewEmployee()
    {
        Console.Write("What is the employee's name? ");
        string name = Console.ReadLine();

        Console.WriteLine("Choose the department: ");
        Console.WriteLine("1. Management");
        Console.WriteLine("2. Commercial");
        Console.WriteLine("3. Design");
        int choiceDepartment = int.Parse(Console.ReadLine());

        Department department = Department.Design;

        switch (choiceDepartment)
        {
            case 1:
                department = Department.Management;
                break;
            case 2:
                department = Department.Commercial;
                break;
            case 3:
                department = Department.Design;
                break;
            default:
                Console.WriteLine("Invalid department choice. Defaulting to Design.");
                break;
        }

        Console.Write("What is the salary? ");
        double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Employee employee = null;

        switch (department)
        {
            case Department.Management:
                employee = new Manager(GetEmployees().Count, name, department, salary);
                break;
            case Department.Commercial:
                Console.Write("What is the value per project? ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                employee = new ProjectSeller(GetEmployees().Count, name, department, salary, value);
                break;
            case Department.Design:
                Console.WriteLine("What kind of designer?");
                Console.WriteLine("1. Regular");
                Console.WriteLine("2. Hourly");
                int designerType = int.Parse(Console.ReadLine());
                if (designerType == 1)
                {
                    employee = new FullTimeEmployee(GetEmployees().Count, name, department, salary);
                }
                else if (designerType == 2)
                {
                    Console.Write("What is the value per hour? ");
                    double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    employee = new HourlyEmployee(GetEmployees().Count, name, department, salary, valuePerHour);
                }
                else
                {
                    Console.WriteLine("Invalid designer type. Defaulting to Regular.");
                    employee = new FullTimeEmployee(GetEmployees().Count, name, department, salary);
                }
                break;
            default:
                Console.WriteLine("Invalid department. Employee not hired.");
                break;
        }

        return employee;
    }

    public void FireEmployee(Employee employee)
    {
        RemoveEmployee(employee);
        Console.WriteLine($"Employee {employee.GetEmployeeInfo()} fired!");
    }

    public void PayEmployees(List<Employee> employees)
    {
        Console.WriteLine("Not yet implemented");
    }

    public void ShowEmployees()
    {
        foreach(Employee e in GetEmployees())
        {
            Console.WriteLine(e.GetEmployeeInfo());
        }
    }
}