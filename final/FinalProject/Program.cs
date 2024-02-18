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
        projectManager.ProjectMenu();
    }
}