
public class AutomationProject : Project
{
    public ProjectType _projectType { get; set; } = ProjectType.Automation;
    public AutomationProject(int number, string projectName, Client client, DateTime startDate, DateTime dueDate, Employee projectDesigner, List<Milestone> milestones) : base(number, projectName, client, startDate, dueDate, projectDesigner, milestones)
    {
    }

    public void AutomationPointList()
    {
        Console.WriteLine("Automation points list");
    }
}