using System;
using System.Collections.Generic;

// Abstract class Patient
abstract class Patient
{
    protected int patientId;
    protected string name;
    protected int age;
    private string diagnosis;
    private string medicalHistory;

    public int PatientId { get => patientId; set => patientId = value; }
    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }

    protected string Diagnosis { get => diagnosis; set => diagnosis = value; }
    protected string MedicalHistory { get => medicalHistory; set => medicalHistory = value; }

    public Patient(int patientId, string name, int age, string diagnosis, string medicalHistory)
    {
        this.patientId = patientId;
        this.name = name;
        this.age = age;
        this.diagnosis = diagnosis;
        this.medicalHistory = medicalHistory;
    }

    public abstract double CalculateBill();

    public virtual void GetPatientDetails()
    {
        Console.WriteLine($"ID: {patientId}, Name: {name}, Age: {age}");
    }
}

// Interface IMedicalRecord
interface IMedicalRecord
{
    void AddRecord(string record);
    void ViewRecords();
}

// InPatient subclass
class InPatient : Patient, IMedicalRecord
{
    private double dailyRate;
    private int daysAdmitted;
    private List<string> medicalRecords = new List<string>();

    public InPatient(int patientId, string name, int age, string diagnosis, string medicalHistory, double dailyRate, int daysAdmitted)
        : base(patientId, name, age, diagnosis, medicalHistory)
    {
        this.dailyRate = dailyRate;
        this.daysAdmitted = daysAdmitted;
    }

    public override double CalculateBill()
    {
        return dailyRate * daysAdmitted;
    }

    public void AddRecord(string record)
    {
        medicalRecords.Add(record);
    }

    public void ViewRecords()
    {
        Console.WriteLine("Medical Records:");
        foreach (var record in medicalRecords)
        {
            Console.WriteLine(record);
        }
    }
}

// OutPatient subclass
class OutPatient : Patient, IMedicalRecord
{
    private double consultationFee;
    private List<string> medicalRecords = new List<string>();

    public OutPatient(int patientId, string name, int age, string diagnosis, string medicalHistory, double consultationFee)
        : base(patientId, name, age, diagnosis, medicalHistory)
    {
        this.consultationFee = consultationFee;
    }

    public override double CalculateBill()
    {
        return consultationFee;
    }

    public void AddRecord(string record)
    {
        medicalRecords.Add(record);
    }

    public void ViewRecords()
    {
        Console.WriteLine("Medical Records:");
        foreach (var record in medicalRecords)
        {
            Console.WriteLine(record);
        }
    }
}

// Main program
class Program
{
    static void ProcessPatients(List<Patient> patients)
    {
        foreach (var patient in patients)
        {
            patient.GetPatientDetails();
            Console.WriteLine($"Total Bill: {patient.CalculateBill():C}");
        }
    }

    static void Main()
    {
        List<Patient> patients = new List<Patient>
        {
            new InPatient(1, "Alice", 30, "Flu", "No major history", 200, 3),
            new OutPatient(2, "Bob", 25, "Cold", "No major history", 50)
        };

        ProcessPatients(patients);
    }
}
