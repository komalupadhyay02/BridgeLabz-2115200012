using System;

class Course
{
    // Class variable (common for all courses)
    public static string InstituteName = "ABC Institute";

    // Instance variables
    public string CourseName { get; set; }
    public int Duration { get; set; }  // Duration in hours
    public decimal Fee { get; set; }

    // Constructor to initialize course details
    public Course(string courseName, int duration, decimal fee)
    {
        CourseName = courseName;
        Duration = duration;
        Fee = fee;
    }

    // Instance method to display course details
    public void DisplayCourseDetails()
    {
        Console.WriteLine($"Course Name: {CourseName}");
        Console.WriteLine($"Duration: {Duration} hours");
        Console.WriteLine($"Fee: ${Fee}");
        Console.WriteLine($"Institute: {InstituteName}");
    }

    // Class method to update the institute name for all courses
    public static void UpdateInstituteName(string newInstituteName)
    {
        InstituteName = newInstituteName;
        Console.WriteLine($"Institute Name updated to: {InstituteName}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example Usage
        Course course1 = new Course("C# Programming", 30, 200.00m);
        course1.DisplayCourseDetails();

        Course course2 = new Course("Web Development", 40, 300.00m);
        course2.DisplayCourseDetails();

        // Update the institute name for all courses
        Course.UpdateInstituteName("XYZ Academy");

        // Display updated course details
        course1.DisplayCourseDetails();
        course2.DisplayCourseDetails();
    }
}