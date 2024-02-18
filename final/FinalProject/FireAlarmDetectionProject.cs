
public class FireAlarmDetectionProject : Project
{
    public ProjectType _projectType { get; set; } = ProjectType.FireAlarmDetection;
    public FireAlarmDetectionProject(int number, string projectName, Client client, DateTime startDate, DateTime dueDate, Employee projectDesigner, List<Milestone> milestones) : base(number, projectName, client, startDate, dueDate, projectDesigner, milestones)
    {
    }

    public int CalcLoops(int numDetectors)
    {
        Console.Write("How many detectors does the central accepts at maximum? ");
        int maxValue = int.Parse(Console.ReadLine());
        return numDetectors / maxValue;
    }
}