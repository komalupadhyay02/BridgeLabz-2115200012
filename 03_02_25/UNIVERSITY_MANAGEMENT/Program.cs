using System;
class UniversityManagement{
    public static string universityName="GLA University";
    private static int totalStudents=0;
    public readonly int RollNumber;
    public string StudentName{get;private set;}
    public string Grade{get;private set;}
     public UniversityManagement(string StudentName,int RollNumber,string Grade){
        this.RollNumber=RollNumber;
        this.StudentName=StudentName;
        this.Grade=Grade;
        totalStudents++;
    }
    public static void TotalStudents(){
        Console.WriteLine($"TotalStudents:{totalStudents}");
    }
    public  void UpdateGrade(string newGrade){
        this.Grade=newGrade;
        Console.WriteLine($"Grade Updated Successfully! for {StudentName}\n(RollNumber: {RollNumber})");
    }
    public void Display(){
        Console.WriteLine($"Name: {StudentName}\n RollNo.: {RollNumber}\nGrade: {Grade}");
    }
    
}
class University{
    private static List<UniversityManagement> students = new List<UniversityManagement>();
    public static void AddStudent(){
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Roll Number: ");
        if (int.TryParse(Console.ReadLine(), out int rollNumber))
        {
            Console.Write("Enter Grade: ");
            string grade = Console.ReadLine();

            UniversityManagement newStudent = new UniversityManagement(name, rollNumber, grade);
            students.Add(newStudent);
            Console.WriteLine("Student added successfully!\n");
        }
        else
        {
            Console.WriteLine("Invalid Roll Number! Please enter a numeric value.\n");
        }
    }
      public static void DisplayAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students enrolled yet.");
            return;
        }

        Console.WriteLine("\n==== Student List ====");
        foreach (var student in students)
        {
            student.Display();
        }
        Console.WriteLine();
    }
    public static void SearchStudent()
    {
        Console.Write("Enter Roll Number to search: ");
        if (int.TryParse(Console.ReadLine(), out int searchRollNo))
        {
            UniversityManagement foundStudent = students.Find(s => s.RollNumber == searchRollNo);
            if (foundStudent is UniversityManagement)
            {
                Console.WriteLine("\nStudent Found:");
                foundStudent.Display();
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Roll Number.");
        }
        Console.WriteLine();
    }
     public static void UpdateStudentGrade()
    {
        Console.Write("Enter Roll Number to update grade: ");
        if (int.TryParse(Console.ReadLine(), out int rollNumber))
        {
           UniversityManagement foundStudent = students.Find(s => s.RollNumber == rollNumber);
            if (foundStudent is UniversityManagement)
            {
                Console.Write("Enter new grade: ");
                string newGrade = Console.ReadLine();
                foundStudent.UpdateGrade(newGrade);
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Roll Number.");
        }
        Console.WriteLine();
    }
     public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("==== University Student Management System ====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student by Roll Number");
            Console.WriteLine("4. Update Student Grade");
            Console.WriteLine("5. Display Total Students");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    DisplayAllStudents();
                    break;
                case "3":
                    SearchStudent();
                    break;
                case "4":
                    UpdateStudentGrade();
                    break;
                case "5":
                    UniversityManagement.TotalStudents();
                    break;
                case "6":
                    Console.WriteLine("Thank you! Exiting the University Management System.");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.\n");
                    break;
            }
        }
    }
}