using System;

public class AccessControlProject : Project
{
    private ProjectType _projectType { get; set; } = ProjectType.AccessControl;
    public AccessControlProject(int number, string projectName, Client client, double value, DateTime startDate, DateTime dueDate, Employee projectDesigner, List<Milestone> milestones) : base(number, projectName, client, value, startDate, dueDate, projectDesigner, milestones)
    {
    }

    public int CalcNumController(int numPoints)
    {
        return Math.Abs(numPoints / 8);
    }
}