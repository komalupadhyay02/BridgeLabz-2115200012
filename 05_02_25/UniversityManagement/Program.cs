using System;
using System.Collections.Generic;

class University
{
    public string Name { get; set; }
    private List<Student> students;
    private List<Professor> professors;
    private List<Course> courses;

    public University(string name)
    {
        Name = name;
        students = new List<Student>();
        professors = new List<Professor>();
        courses = new List<Course>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
        Console.WriteLine($"Student {student.Name} enrolled in {Name}.");
    }

    public void AddProfessor(Professor professor)
    {
        professors.Add(professor);
        Console.WriteLine($"Professor {professor.Name} joined {Name}.");
    }

    public void AddCourse(Course course)
    {
        courses.Add(course);
        Console.WriteLine($"Course {course.Title} added to {Name}.");
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

    public void EnrollCourse(Course course)
    {
        courses.Add(course);
        course.AddStudent(this);
        Console.WriteLine($"Student {Name} enrolled in {course.Title}.");
    }
}

class Professor
{
    public string Name { get; set; }

    public Professor(string name)
    {
        Name = name;
    }

    public void AssignCourse(Course course)
    {
        course.AssignProfessor(this);
        Console.WriteLine($"Professor {Name} assigned to {course.Title}.");
    }
}

class Course
{
    public string Title { get; set; }
    private List<Student> students;
    private Professor professor;

    public Course(string title)
    {
        Title = title;
        students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void AssignProfessor(Professor professor)
    {
        this.professor = professor;
    }
}

class Program
{
    static void Main()
    {
        University uni = new University("Tech University");
        
        Student john = new Student("John");
        Student alice = new Student("Alice");
        
        Professor drSmith = new Professor("Dr. Smith");
        
        Course cs101 = new Course("Computer Science 101");
        Course math101 = new Course("Mathematics 101");
        
        uni.AddStudent(john);
        uni.AddStudent(alice);
        uni.AddProfessor(drSmith);
        uni.AddCourse(cs101);
        uni.AddCourse(math101);
        
        john.EnrollCourse(cs101);
        alice.EnrollCourse(math101);
        
        drSmith.AssignCourse(cs101);
    }
}
