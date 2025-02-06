using System;
using System.Collections.Generic;

class University
{
    public string Name { get; set; }
    private List<Department> departments;
    private List<Faculty> faculties;

    public University(string name)
    {
        Name = name;
        departments = new List<Department>();
        faculties = new List<Faculty>();
    }

    public void AddDepartment(string deptName)
    {
        departments.Add(new Department(deptName));
        Console.WriteLine($"Department {deptName} added to {Name}.");
    }

    public void AddFaculty(Faculty faculty)
    {
        faculties.Add(faculty);
        Console.WriteLine($"Faculty {faculty.Name} associated with {Name}.");
    }

    public void ShowUniversityDetails()
    {
        Console.WriteLine($"University: {Name}");
        Console.WriteLine("Departments:");
        foreach (var dept in departments)
        {
            dept.ShowEmployees();
        }
        Console.WriteLine("Faculties:");
        foreach (var faculty in faculties)
        {
            Console.WriteLine($"- {faculty.Name}");
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

class Faculty
{
    public string Name { get; set; }
    public Faculty(string name)
    {
        Name = name;
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
        University university = new University("Tech University");
        
        university.AddDepartment("Computer Science");
        university.AddDepartment("Mechanical Engineering");
        
        Faculty profJohn = new Faculty("Prof. John");
        Faculty profJane = new Faculty("Prof. Jane");
        
        university.AddFaculty(profJohn);
        university.AddFaculty(profJane);
        
        university.ShowUniversityDetails();
    }
}
