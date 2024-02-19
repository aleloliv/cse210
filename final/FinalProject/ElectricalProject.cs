
public class ElectricalProject : Project
{
    private ProjectType _projetType { get; set; } = ProjectType.Electrical;
    public ElectricalProject(int number, string projectName, Client client, DateTime startDate, DateTime dueDate, Employee projectDesigner, List<Milestone> milestones) : base(number, projectName, client, startDate, dueDate, projectDesigner, milestones)
    {
    }

    public double CalcCurrent(double voltage, double power)
    {
        return power / voltage;
    }
}