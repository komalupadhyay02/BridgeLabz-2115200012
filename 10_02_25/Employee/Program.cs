using System;
using System.Collections.Generic;

// Abstract class Employee
abstract class Employee
{
    protected int employeeId;
    protected string name;
    protected double baseSalary;

    public int EmployeeId { get => employeeId; set => employeeId = value; }
    public string Name { get => name; set => name = value; }
    public double BaseSalary { get => baseSalary; set => baseSalary = value; }

    public Employee(int id, string name, double baseSalary)
    {
        this.employeeId = id;
        this.name = name;
        this.baseSalary = baseSalary;
    }

    public abstract double CalculateSalary();

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"ID: {employeeId}, Name: {name}, Salary: {CalculateSalary():C}");
    }
}

// Interface IDepartment
interface IDepartment
{
    void AssignDepartment(string department);
    string GetDepartmentDetails();
}

// FullTimeEmployee subclass
class FullTimeEmployee : Employee, IDepartment
{
    private string department;

    public FullTimeEmployee(int id, string name, double baseSalary)
        : base(id, name, baseSalary) { }

    public override double CalculateSalary()
    {
        return baseSalary; // Fixed salary for full-time employees
    }

    public void AssignDepartment(string department)
    {
        this.department = department;
    }

    public string GetDepartmentDetails()
    {
        return department;
    }
}

// PartTimeEmployee subclass
class PartTimeEmployee : Employee, IDepartment
{
    private int workHours;
    private double hourlyRate;
    private string department;

    public PartTimeEmployee(int id, string name, double hourlyRate, int workHours)
        : base(id, name, 0)
    {
        this.hourlyRate = hourlyRate;
        this.workHours = workHours;
    }

    public override double CalculateSalary()
    {
        return workHours * hourlyRate; // Salary based on work hours
    }

    public void AssignDepartment(string department)
    {
        this.department = department;
    }

    public string GetDepartmentDetails()
    {
        return department;
    }
}

// Main program
class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new FullTimeEmployee(1, "Alice", 5000),
            new PartTimeEmployee(2, "Bob", 20, 100)
        };

        foreach (var employee in employees)
        {
            employee.DisplayDetails();
        }
    }
}