public abstract class Employee
{
    private int _employeeNumber { get; set; }
    private string _employeeName { get; set; }
    public Department _department { get; private set; }
    protected double _salary { get; set; }

    public Employee(int employeeNumber, string employeeName, Department department, double salary)
    {
        _employeeNumber = employeeNumber;
        _employeeName = employeeName;
        _department = department;
        _salary = salary;
    }

    public string GetEmployeeInfo()
    {
        return $"{_employeeNumber}. {_employeeName} - {_department}";
    }

    public abstract double CalcSalary();
}