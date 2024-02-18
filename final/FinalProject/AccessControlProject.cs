using System;

public class AccessControlProject : Project
{
    public ProjectType _projectType { get; set; } = ProjectType.AccessControl;
    public AccessControlProject(int number, string projectName, Client client, DateTime startDate, DateTime dueDate, Employee projectDesigner, List<Milestone> milestones) : base(number, projectName, client, startDate, dueDate, projectDesigner, milestones)
    {
    }

    public int CalcNumController(int numPoints)
    {
        return Math.Abs(numPoints / 8);
    }
}