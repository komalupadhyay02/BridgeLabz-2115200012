using System;
using System.Collections.Generic;

class Company
{
    public string Name { get; set; }
    private List<Department> departments;

    public Company(string name)
    {
        Name = name;
        departments = new List<Department>();
    }

    public void AddDepartment(string deptName)
    {
        departments.Add(new Department(deptName));
        Console.WriteLine($"Department {deptName} added to {Name}.");
    }

    public void ShowDepartments()
    {
        Console.WriteLine($"Departments in {Name}:");
        foreach (var dept in departments)
        {
            dept.ShowEmployees();
        }
    }
}

class Department
{
    public string Name { get; set; }
    private List<Employee> employees;

    public Department(string name)
    {
        Name = name;
        employees = new List<Employee>();
    }

    public void AddEmployee(string empName)
    {
        employees.Add(new Employee(empName));
        Console.WriteLine($"Employee {empName} added to {Name} department.");
    }

    public void ShowEmployees()
    {
        Console.WriteLine($"Employees in {Name} department:");
        foreach (var emp in employees)
        {
            Console.WriteLine($"- {emp.Name}");
        }
    }
}

class Employee
{
    public string Name { get; set; }
    public Employee(string name)
    {
        Name = name;
    }
}

class Program
{
    static void Main()
    {
        Company company = new Company("TechCorp");
        
        Department itDept = new Department("IT");
        itDept.AddEmployee("Alice");
        itDept.AddEmployee("Bob");
        
        Department hrDept = new Department("HR");
        hrDept.AddEmployee("Charlie");
        hrDept.AddEmployee("David");
        
        company.ShowDepartments();
    }
}
