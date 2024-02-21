using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to the Project Manager App!");
        Console.Write("Please enter the manager name: ");
        string name = Console.ReadLine();
        Console.Write("Please enter the manager salary: ");
        double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Employee manager = new Manager(1, name, Department.Management, salary);
        ProjectManager projectManager = new ProjectManager(manager);
        try
        {
            do
            {
                Console.WriteLine("Project Manager Menu:");
                Console.WriteLine("1. Projects Menu");
                Console.WriteLine("2. Tasks Menu");
                Console.WriteLine("3. Employees Menu");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        projectManager.ProjectMenu();
                        break;
                    case 2:
                        Console.WriteLine("Select project:");
                        Project project = projectManager.SelectProject();
                        if(project != null) {
                            projectManager.TaskMenu(project);
                        } else {
                            Console.WriteLine("Project not found.");
                        }
                        break;
                    case 3:
                        projectManager.EmployeeMenu();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Please select 1, 2, or 3");
                        break;
                }
            } while(true);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }
}