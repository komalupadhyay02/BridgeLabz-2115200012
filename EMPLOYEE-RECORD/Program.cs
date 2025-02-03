using System;

// Base class: Employee
class Employee
{
    // Public member for employee ID
    public int EmployeeID { get; set; }

    // Protected member for department
    protected string Department { get; set; }

    // Private member for salary
    private decimal Salary { get; set; }

    // Constructor to initialize employee details
    public Employee(int employeeID, string department, decimal salary)
    {
        EmployeeID = employeeID;
        Department = department;
        Salary = salary;
    }

    // Public method to get the salary
    public decimal GetSalary()
    {
        return Salary;
    }

    // Public method to set or modify the salary
    public void SetSalary(decimal salary)
    {
        if (salary >= 0)
        {
            Salary = salary;
        }
        else
        {
            Console.WriteLine("Invalid salary. Salary cannot be negative.");
        }
    }
}

// Subclass: Manager
class Manager : Employee
{
    // Constructor for Manager
    public Manager(int employeeID, string department, decimal salary)
        : base(employeeID, department, salary)
    {
    }

    // Method to display manager details
    public void DisplayManagerDetails()
    {
        Console.WriteLine($"Employee ID: {EmployeeID}"); // Accessing public member
        Console.WriteLine($"Department: {Department}"); // Accessing protected member
        Console.WriteLine($"Salary: ${GetSalary()}"); // Accessing salary through public method
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a Manager instance
        Manager manager = new Manager(101, "Sales", 5000.00m);

        // Display manager details
        manager.DisplayManagerDetails();

        // Modify the salary using the public method
        manager.SetSalary(6000.00m);

        // Display updated manager details
        Console.WriteLine("\nUpdated Manager Details:");
        manager.DisplayManagerDetails();
    }
}


