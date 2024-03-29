using System;

public class CablingProject : Project
{
    private ProjectType _projetctType { get; set; } = ProjectType.Cabling;
    public CablingProject(int number, string projectName, Client client, double value, DateTime startDate, DateTime dueDate, Employee projectDesigner, List<Milestone> milestones) : base(number, projectName, client, value, startDate, dueDate, projectDesigner, milestones)
    {
    }

    public double CalcSwitches(int numPoints)
    {
        Console.Write("How many connection doors the switch has? ");
        int doors = int.Parse(Console.ReadLine());
        return Math.Abs(numPoints / doors);
    }
}