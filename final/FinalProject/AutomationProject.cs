
public class AutomationProject : Project
{
    private ProjectType _projectType { get; set; } = ProjectType.Automation;
    public AutomationProject(int number, string projectName, Client client, double value, DateTime startDate, DateTime dueDate, Employee projectDesigner, List<Milestone> milestones) : base(number, projectName, client, value, startDate, dueDate, projectDesigner, milestones)
    {
    }

    public void AutomationPointList()
    {
        Console.WriteLine("Automation points list");
    }
}