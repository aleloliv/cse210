public class Manager : Employee
{
    public Manager(int employeeNumber, string employeeName, Department department, double salary) : base(employeeNumber, employeeName, department, salary)
    {
        _salary = salary + salary * 0.1;
    }

    public override double CalcSalary()
    {
        return _salary + _salary * 0.1;
    }
}