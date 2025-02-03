using System;

// Base class: Student
class Student
{
    // Public member for roll number
    public int RollNumber { get; set; }
    
    // Protected member for name (accessible in derived classes)
    protected string Name { get; set; }
    
    // Private member for CGPA
    private double CGPA { get; set; }
    
    // Constructor to initialize the student details
    public Student(int rollNumber, string name, double cgpa)
    {
        RollNumber = rollNumber;
        Name = name;
        CGPA = cgpa;
    }

    // Public method to access the CGPA
    public double GetCGPA()
    {
        return CGPA;
    }

    // Public method to modify the CGPA
    public void SetCGPA(double cgpa)
    {
        if (cgpa >= 0 && cgpa <= 4.0)
        {
            CGPA = cgpa;
        }
        else
        {
            Console.WriteLine("Invalid CGPA value. CGPA should be between 0 and 4.");
        }
    }
}

// Subclass: PostgraduateStudent
class PostgraduateStudent : Student
{
    // Constructor for PostgraduateStudent
    public PostgraduateStudent(int rollNumber, string name, double cgpa) 
        : base(rollNumber, name, cgpa)
    {
    }

    // Method to display postgraduate student details
    public void DisplayPostgraduateDetails()
    {
        Console.WriteLine($"Roll Number: {RollNumber}");
        Console.WriteLine($"Name: {Name}"); // Accessing protected member
        Console.WriteLine($"CGPA: {GetCGPA()}"); // Accessing CGPA via public method
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a PostgraduateStudent instance
        PostgraduateStudent student = new PostgraduateStudent(101, "Alice Johnson", 3.85);
        
        // Display student details
        student.DisplayPostgraduateDetails();

        // Modify the CGPA using public methods
        student.SetCGPA(3.90);
        
        // Display updated student details
        Console.WriteLine("\nUpdated Student Details:");
        student.DisplayPostgraduateDetails();
    }
}
