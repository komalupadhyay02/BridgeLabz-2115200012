using System;
using System.Collections.Generic;

class Hospital
{
    public string Name { get; set; }
    private List<Doctor> doctors;
    private List<Patient> patients;

    public Hospital(string name)
    {
        Name = name;
        doctors = new List<Doctor>();
        patients = new List<Patient>();
    }

    public void AddDoctor(Doctor doctor)
    {
        doctors.Add(doctor);
        Console.WriteLine($"Doctor {doctor.Name} joined {Name}.");
    }

    public void AddPatient(Patient patient)
    {
        patients.Add(patient);
        Console.WriteLine($"Patient {patient.Name} registered at {Name}.");
    }

    public void ShowHospitalDetails()
    {
        Console.WriteLine($"Hospital: {Name}");
        Console.WriteLine("Doctors:");
        foreach (var doctor in doctors)
        {
            Console.WriteLine($"- {doctor.Name}");
        }
        Console.WriteLine("Patients:");
        foreach (var patient in patients)
        {
            Console.WriteLine($"- {patient.Name}");
        }
    }
}

class Doctor
{
    public string Name { get; set; }
    private List<Patient> patients;

    public Doctor(string name)
    {
        Name = name;
        patients = new List<Patient>();
    }

    public void Consult(Patient patient)
    {
        if (!patients.Contains(patient))
        {
            patients.Add(patient);
            patient.AddDoctor(this);
        }
        Console.WriteLine($"Doctor {Name} is consulting patient {patient.Name}.");
    }
}

class Patient
{
    public string Name { get; set; }
    private List<Doctor> doctors;

    public Patient(string name)
    {
        Name = name;
        doctors = new List<Doctor>();
    }

    public void AddDoctor(Doctor doctor)
    {
        if (!doctors.Contains(doctor))
        {
            doctors.Add(doctor);
        }
    }
}

class Program
{
    static void Main()
    {
        Hospital hospital = new Hospital("City Hospital");
        
        Doctor drSmith = new Doctor("Dr. Smith");
        Doctor drJohnson = new Doctor("Dr. Johnson");
        
        Patient john = new Patient("John Doe");
        Patient jane = new Patient("Jane Roe");
        
        hospital.AddDoctor(drSmith);
        hospital.AddDoctor(drJohnson);
        
        hospital.AddPatient(john);
        hospital.AddPatient(jane);
        
        drSmith.Consult(john);
        drSmith.Consult(jane);
        drJohnson.Consult(john);
        
        hospital.ShowHospitalDetails();
    }
}using System;
using System.Collections.Generic;

class Hospital
{
    public string Name { get; set; }
    private List<Doctor> doctors;
    private List<Patient> patients;

    public Hospital(string name)
    {
        Name = name;
        doctors = new List<Doctor>();
        patients = new List<Patient>();
    }

    public void AddDoctor(Doctor doctor)
    {
        doctors.Add(doctor);
        Console.WriteLine($"Doctor {doctor.Name} joined {Name}.");
    }

    public void AddPatient(Patient patient)
    {
        patients.Add(patient);
        Console.WriteLine($"Patient {patient.Name} registered at {Name}.");
    }

    public void ShowHospitalDetails()
    {
        Console.WriteLine($"Hospital: {Name}");
        Console.WriteLine("Doctors:");
        foreach (var doctor in doctors)
        {
            Console.WriteLine($"- {doctor.Name}");
        }
        Console.WriteLine("Patients:");
        foreach (var patient in patients)
        {
            Console.WriteLine($"- {patient.Name}");
        }
    }
}

class Doctor
{
    public string Name { get; set; }
    private List<Patient> patients;

    public Doctor(string name)
    {
        Name = name;
        patients = new List<Patient>();
    }

    public void Consult(Patient patient)
    {
        if (!patients.Contains(patient))
        {
            patients.Add(patient);
            patient.AddDoctor(this);
        }
        Console.WriteLine($"Doctor {Name} is consulting patient {patient.Name}.");
    }
}

class Patient
{
    public string Name { get; set; }
    private List<Doctor> doctors;

    public Patient(string name)
    {
        Name = name;
        doctors = new List<Doctor>();
    }

    public void AddDoctor(Doctor doctor)
    {
        if (!doctors.Contains(doctor))
        {
            doctors.Add(doctor);
        }
    }
}

class Program
{
    static void Main()
    {
        Hospital hospital = new Hospital("City Hospital");
        
        Doctor drSmith = new Doctor("Dr. Smith");
        Doctor drJohnson = new Doctor("Dr. Johnson");
        
        Patient john = new Patient("John Doe");
        Patient jane = new Patient("Jane Roe");
        
        hospital.AddDoctor(drSmith);
        hospital.AddDoctor(drJohnson);
        
        hospital.AddPatient(john);
        hospital.AddPatient(jane);
        
        drSmith.Consult(john);
        drSmith.Consult(jane);
        drJohnson.Consult(john);
        
        hospital.ShowHospitalDetails();
    }
}