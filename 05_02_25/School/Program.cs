using System;
using System.Collections.Generic;

class School
{
    public string Name { get; set; }
    private List<Student> students;

    public School(string name)
    {
        Name = name;
        students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
        Console.WriteLine($"Student {student.Name} added to {Name}.");
    }

    public void ShowStudents()
    {
        Console.WriteLine($"Students in {Name}:");
        foreach (var student in students)
        {
            student.ShowCourses();
        }
    }
}

class Student
{
    public string Name { get; set; }
    private List<Course> courses;

    public Student(string name)
    {
        Name = name;
        courses = new List<Course>();
    }

    public void EnrollInCourse(Course course)
    {
        courses.Add(course);
        course.AddStudent(this);
        Console.WriteLine($"Student {Name} enrolled in {course.Name}.");
    }

    public void ShowCourses()
    {
        Console.WriteLine($"Courses enrolled by {Name}:");
        foreach (var course in courses)
        {
            Console.WriteLine($"- {course.Name}");
        }
    }
}

class Course
{
    public string Name { get; set; }
    private List<Student> students;

    public Course(string name)
    {
        Name = name;
        students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        if (!students.Contains(student))
        {
            students.Add(student);
        }
    }

    public void ShowStudents()
    {
        Console.WriteLine($"Students enrolled in {Name}:");
        foreach (var student in students)
        {
            Console.WriteLine($"- {student.Name}");
        }
    }
}

class Program
{
    static void Main()
    {
        School school = new School("Greenwood High");
        
        Student alice = new Student("Alice");
        Student bob = new Student("Bob");
        
        Course math = new Course("Mathematics");
        Course science = new Course("Science");
        
        alice.EnrollInCourse(math);
        alice.EnrollInCourse(science);
        
        bob.EnrollInCourse(math);
        
        school.AddStudent(alice);
        school.AddStudent(bob);
        
        school.ShowStudents();
        math.ShowStudents();
        science.ShowStudents();
    }
}
