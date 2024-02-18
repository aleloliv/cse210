public class FullTimeEmployee : Employee
{
    public FullTimeEmployee(int employeeNumber, string employeeName, Department department, double salary) : base(employeeNumber, employeeName, department, salary)
    {
    }

    public override double CalcSalary()
    {
        return _salary;
    }
}