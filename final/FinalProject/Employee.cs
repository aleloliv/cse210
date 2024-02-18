public abstract class Employee
{
    public int _employeeNumber { get; set; }
    public string _employeeName { get; set; }
    public Department _department { get; set; }
    public double _salary { get; set; }

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