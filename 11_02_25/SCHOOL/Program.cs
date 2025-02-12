using System;

public class Student
{
    public int RollNumber;
    public string Name;
    public int Age;
    public string Grade;
    public Student Next;

    public Student(int rollNumber, string name, int age, string grade)
    {
        RollNumber = rollNumber;
        Name = name;
        Age = age;
        Grade = grade;
        Next = null;
    }
}

public class StudentLinkedList
{
    private Student head;

    public StudentLinkedList()
    {
        head = null;
    }

    // Add a student record at the beginning
    public void AddAtBeginning(int rollNumber, string name, int age, string grade)
    {
        Student newStudent = new Student(rollNumber, name, age, grade);
        newStudent.Next = head;
        head = newStudent;
    }

    // Add a student record at the end
    public void AddAtEnd(int rollNumber, string name, int age, string grade)
    {
        Student newStudent = new Student(rollNumber, name, age, grade);
        if (head == null)
        {
            head = newStudent;
            return;
        }

        Student temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newStudent;
    }

    // Add a student record at a specific position
    public void AddAtPosition(int position, int rollNumber, string name, int age, string grade)
    {
        if (position == 0)
        {
            AddAtBeginning(rollNumber, name, age, grade);
            return;
        }

        Student newStudent = new Student(rollNumber, name, age, grade);
        Student temp = head;
        int count = 0;

        while (temp != null && count < position - 1)
        {
            temp = temp.Next;
            count++;
        }

        if (temp == null)
        {
            Console.WriteLine("Position out of range!");
            return;
        }

        newStudent.Next = temp.Next;
        temp.Next = newStudent;
    }

    // Delete a student record by Roll Number
    public void DeleteByRollNumber(int rollNumber)
    {
        if (head == null)
        {
            Console.WriteLine("No records to delete.");
            return;
        }

        // If the head node contains the roll number
        if (head.RollNumber == rollNumber)
        {
            head = head.Next;
            return;
        }

        Student temp = head;
        while (temp.Next != null)
        {
            if (temp.Next.RollNumber == rollNumber)
            {
                temp.Next = temp.Next.Next;
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Student not found!");
    }

    // Search for a student by Roll Number
    public void SearchByRollNumber(int rollNumber)
    {
        Student temp = head;
        while (temp != null)
        {
            if (temp.RollNumber == rollNumber)
            {
                Console.WriteLine($"Found student: Roll Number: {temp.RollNumber}, Name: {temp.Name}, Age: {temp.Age}, Grade: {temp.Grade}");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Student not found!");
    }

    // Display all student records
    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No records to display.");
            return;
        }

        Student temp = head;
        while (temp != null)
        {
            Console.WriteLine($"Roll Number: {temp.RollNumber}, Name: {temp.Name}, Age: {temp.Age}, Grade: {temp.Grade}");
            temp = temp.Next;
        }
    }

    // Update a student's grade by Roll Number
    public void UpdateGrade(int rollNumber, string newGrade)
    {
        Student temp = head;
        while (temp != null)
        {
            if (temp.RollNumber == rollNumber)
            {
                temp.Grade = newGrade;
                Console.WriteLine($"Updated Grade for Roll Number {rollNumber} to {newGrade}.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Student not found!");
    }
}

public class Program
{
    public static void Main()
    {
        StudentLinkedList studentList = new StudentLinkedList();
        int choice = 0;

        while (true)
        {
            // Display Menu
            Console.Clear();
            Console.WriteLine("=== Student Management System ===");
            Console.WriteLine("1. Add Student at Beginning");
            Console.WriteLine("2. Add Student at End");
            Console.WriteLine("3. Add Student at Specific Position");
            Console.WriteLine("4. Delete Student by Roll Number");
            Console.WriteLine("5. Search Student by Roll Number");
            Console.WriteLine("6. Update Student's Grade");
            Console.WriteLine("7. Display All Students");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Add student at the beginning
                    Console.Write("Enter Roll Number: ");
                    int rollNumBegin = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string nameBegin = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int ageBegin = int.Parse(Console.ReadLine());
                    Console.Write("Enter Grade: ");
                    string gradeBegin = Console.ReadLine();
                    studentList.AddAtBeginning(rollNumBegin, nameBegin, ageBegin, gradeBegin);
                    break;

                case 2:
                    // Add student at the end
                    Console.Write("Enter Roll Number: ");
                    int rollNumEnd = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string nameEnd = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int ageEnd = int.Parse(Console.ReadLine());
                    Console.Write("Enter Grade: ");
                    string gradeEnd = Console.ReadLine();
                    studentList.AddAtEnd(rollNumEnd, nameEnd, ageEnd, gradeEnd);
                    break;

                case 3:
                    // Add student at a specific position
                    Console.Write("Enter Position: ");
                    int position = int.Parse(Console.ReadLine());
                    Console.Write("Enter Roll Number: ");
                    int rollNumPos = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string namePos = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int agePos = int.Parse(Console.ReadLine());
                    Console.Write("Enter Grade: ");
                    string gradePos = Console.ReadLine();
                    studentList.AddAtPosition(position, rollNumPos, namePos, agePos, gradePos);
                    break;

                case 4:
                    // Delete student by Roll Number
                    Console.Write("Enter Roll Number to delete: ");
                    int rollNumDel = int.Parse(Console.ReadLine());
                    studentList.DeleteByRollNumber(rollNumDel);
                    break;

                case 5:
                    // Search student by Roll Number
                    Console.Write("Enter Roll Number to search: ");
                    int rollNumSearch = int.Parse(Console.ReadLine());
                    studentList.SearchByRollNumber(rollNumSearch);
                    break;

                case 6:
                    // Update student's grade
                    Console.Write("Enter Roll Number to update grade: ");
                    int rollNumUpdate = int.Parse(Console.ReadLine());
                    Console.Write("Enter new Grade: ");
                    string newGrade = Console.ReadLine();
                    studentList.UpdateGrade(rollNumUpdate, newGrade);
                    break;

                case 7:
                    // Display all students
                    studentList.DisplayAll();
                    break;

                case 8:
                    // Exit
                    Console.WriteLine("Exiting the system...");
                    return;

                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
