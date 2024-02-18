
using System.Globalization;

public class SecurityCameraProject : Project
{
    public ProjectType _projectType { get; set; }

    public SecurityCameraProject(int number, string projectName, Client client, DateTime startDate, DateTime dueDate, Employee projectDesigner, List<Milestone> milestones) : base(number, projectName, client, startDate, dueDate, projectDesigner, milestones)
    {
    }

    public int CalcNumCamera(double area)
    {
        Console.Write("What is the range of the camera? ");
        double range = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        return (int)Math.Abs(area / range);
    }
}