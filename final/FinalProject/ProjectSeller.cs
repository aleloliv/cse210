using System.Globalization;

public class ProjectSeller : Employee
{
    private int _projectsSold { get; set; }
    private double _valuePerProject { get; set; }

    public ProjectSeller(int employeeNumber, string employeeName, Department department, double salary, double valuePerProject) : base(employeeNumber, employeeName, department, salary)
    {
        department = Department.Commercial;
        _projectsSold = 0;
        _valuePerProject = valuePerProject;
    }

    public override double CalcSalary()
    {
        return _salary + _projectsSold * _valuePerProject;
    }

    public void SellProject()
    {
        _projectsSold ++;
    }

    public void ChangeValuePerProject()
    {
        Console.Write("What is the new value per project? ");
        double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        _valuePerProject = value;
    }
}