using System;
using System.Globalization;

public class HourlyEmployee : Employee
{
    public double _workedHours { get; set; }
    public double _valuePerHour { get; set; }
    public HourlyEmployee(int employeeNumber, string employeeName, Department department, double salary, double valuePerHour) : base(employeeNumber, employeeName, department, salary)
    {
        _workedHours = 0;
        _valuePerHour = valuePerHour;
    }

    public void ChangeValuePerHour()
    {
        Console.Write("What is the new value per hour? ");
        double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        _valuePerHour = valuePerHour;
    }
    public override double CalcSalary()
    {
        double salary = _salary + _workedHours * _valuePerHour;
        return salary;
    }
    
}