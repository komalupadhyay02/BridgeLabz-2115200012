
using System;
using System.Collections.Generic;

class Patient
{
    // Static variable shared among all patients
    static string HospitalName = "City General Hospital";
    private static int TotalPatients = 0;

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Ailment { get; private set; }
    public readonly int PatientID; // Unique and cannot be modified

    // Constructor using 'this' to initialize variables
    public Patient(string name, int age, string ailment, int patientID)
    {
        this.Name = name;
        this.Age = age;
        this.Ailment = ailment;
        this.PatientID = patientID;
        TotalPatients++; // Increment patient count
    }

    // Static method to display total admitted patients
    public static void GetTotalPatients()
    {
        Console.WriteLine($"Total Patients Admitted: {TotalPatients}");
    }

    // Method to display patient details
    public void DisplayPatient()
    {
        Console.WriteLine($"Patient ID: {PatientID}, Name: {Name}, Age: {Age}, Ailment: {Ailment}");
    }
}

class HospitalManagement
{
    private static List<Patient> patients = new List<Patient>();

    // Method to admit a new patient
    public static void AdmitPatient()
    {
        Console.Write("Enter Patient Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        if (int.TryParse(Console.ReadLine(), out int age))
        {
            Console.Write("Enter Ailment: ");
            string ailment = Console.ReadLine();

            Console.Write("Enter Patient ID: ");
            if (int.TryParse(Console.ReadLine(), out int patientID))
            {
                Patient newPatient = new Patient(name, age, ailment, patientID);
                patients.Add(newPatient);
                Console.WriteLine("Patient admitted successfully!\n");
            }
            else
            {
                Console.WriteLine("Invalid Patient ID! Please enter a numeric value.\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid Age! Please enter a numeric value.\n");
        }
    }

    // Method to display all patients
    public static void DisplayAllPatients()
    {
        if (patients.Count == 0)
        {
            Console.WriteLine("No patients admitted yet.");
            return;
        }

        Console.WriteLine("\n==== Admitted Patients ====");
        foreach (var patient in patients)
        {
            patient.DisplayPatient();
        }
        Console.WriteLine();
    }

    // Method to search a patient by Patient ID
    public static void SearchPatient()
    {
        Console.Write("Enter Patient ID to search: ");
        if (int.TryParse(Console.ReadLine(), out int searchID))
        {
            Patient foundPatient = patients.Find(p => p.PatientID == searchID);
            if (foundPatient is Patient)
            {
                Console.WriteLine("\nPatient Found:");
                foundPatient.DisplayPatient();
            }
            else
            {
                Console.WriteLine("Patient Not Found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Patient ID.");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("==== Hospital Management System ====");
            Console.WriteLine("1. Admit Patient");
            Console.WriteLine("2. Display All Patients");
            Console.WriteLine("3. Search Patient by ID");
            Console.WriteLine("4. Get Total Patients");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AdmitPatient();
                    break;
                case "2":
                    DisplayAllPatients();
                    break;
                case "3":
                    SearchPatient();
                    break;
                case "4":
                    Patient.GetTotalPatients();
                    break;
                case "5":
                    Console.WriteLine("Thank you! Exiting the Hospital Management System.");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.\n");
                    break;
            }
        }
    }
}

