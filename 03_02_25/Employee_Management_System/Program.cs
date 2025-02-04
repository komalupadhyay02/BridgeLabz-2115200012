using System;
using System.Collections.Generic;

class Employee
{
    // Static variable shared across all employees
    public static string CompanyName = "Tech Innovators Inc.";

    // Readonly variable to ensure Id cannot be modified
    public readonly int Id;

    // Instance variables
    public string Name { get; private set; }
    public string Designation { get; private set; }

    // Static counter for total employees and unique Id generation
    private static int employeeCounter = 1001;

    // Constructor using 'this' keyword
    public Employee(string name, string designation)
    {
        this.Id = employeeCounter++; // Unique Employee ID
        this.Name = name;
        this.Designation = designation;
    }

    // Display employee details
    public void DisplayEmployeeDetails()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Designation: {Designation}, Company: {CompanyName}");
    }
}

class EmployeeManagementSystem
{
    // List to store employees
    private static List<Employee> employees = new List<Employee>();

    // Static method to add an employee
    public static void AddEmployee()
    {
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();
        
        Console.Write("Enter Designation: ");
        string designation = Console.ReadLine();

        Employee newEmployee = new Employee(name, designation);
        employees.Add(newEmployee);

        Console.WriteLine("Employee Added Successfully!\n");
    }

    // Static method to display all employees
    public static void DisplayAllEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.\n");
            return;
        }

        Console.WriteLine("\n--- Employee List ---");
        foreach (var emp in employees)
        {
            emp.DisplayEmployeeDetails();
        }
        Console.WriteLine();
    }

    // Static method to search for an employee by ID
    public static void SearchEmployee()
    {
        Console.Write("Enter Employee ID to Search: ");
        if (int.TryParse(Console.ReadLine(), out int searchId))
        {
            Employee foundEmployee = employees.Find(emp => emp.Id == searchId);

            if (foundEmployee is Employee)
            {
                Console.WriteLine("\nEmployee Found:");
                foundEmployee.DisplayEmployeeDetails();
            }
            else
            {
                Console.WriteLine("Employee Not Found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Input. Please enter a valid ID.");
        }
        Console.WriteLine();
    }

    // Static method to display total employees
    public static void DisplayTotalEmployees()
    {
        Console.WriteLine($"Total Employees: {employees.Count}\n");
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("==== Employee Management System ====");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Display All Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Display Total Employees");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    DisplayAllEmployees();
                    break;
                case "3":
                    SearchEmployee();
                    break;
                case "4":
                    DisplayTotalEmployees();
                    break;
                case "5":
                    Console.WriteLine("Exiting Employee Management System...");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.\n");
                    break;
            }
        }
    }
}
