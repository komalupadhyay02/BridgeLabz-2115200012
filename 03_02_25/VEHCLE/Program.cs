using System;
using System.Collections.Generic;

class Vehicle
{
    // Static variable shared among all vehicles
    private static double RegistrationFee = 5000.00; // Default registration fee
    private static int VehicleCount = 0; // Auto-increment ID counter

    public string OwnerName { get; private set; }
    public string VehicleType { get; private set; } // Car, Bike, Truck, etc.
    public readonly int RegistrationNumber; // Unique ID that cannot be changed

    // Constructor using 'this' to initialize variables
    public Vehicle(string ownerName, string vehicleType)
    {
        this.OwnerName = ownerName;
        this.VehicleType = vehicleType;
        this.RegistrationNumber = ++VehicleCount; // Assigns a unique ID
    }

    // Static method to update registration fee
    public static void UpdateRegistrationFee(double newFee)
    {
        RegistrationFee = newFee;
        Console.WriteLine($"Registration fee updated to ${RegistrationFee:F2}.\n");
    }

    // Method to display vehicle details
    public void DisplayVehicle()
    {
        Console.WriteLine($"Registration Number: {RegistrationNumber}, Owner: {OwnerName}, Type: {VehicleType}, Fee: ${RegistrationFee:F2}");
    }
}

class VehicleRegistrationSystem
{
    private static List<Vehicle> registeredVehicles = new List<Vehicle>();

    // Method to register a new vehicle
    public static void RegisterVehicle()
    {
        Console.Write("Enter Owner Name: ");
        string ownerName = Console.ReadLine();

        Console.Write("Enter Vehicle Type (Car/Bike/Truck/etc.): ");
        string vehicleType = Console.ReadLine();

        Vehicle newVehicle = new Vehicle(ownerName, vehicleType);
        registeredVehicles.Add(newVehicle);
        Console.WriteLine("Vehicle Registered Successfully!\n");
    }

    // Method to display all registered vehicles
    public static void DisplayAllVehicles()
    {
        if (registeredVehicles.Count == 0)
        {
            Console.WriteLine("No vehicles are registered yet.\n");
            return;
        }

        Console.WriteLine("\n==== Registered Vehicles ====");
        foreach (var vehicle in registeredVehicles)
        {
            vehicle.DisplayVehicle();
        }
        Console.WriteLine();
    }

    // Method to search for a vehicle by Registration Number
    public static void SearchVehicle()
    {
        Console.Write("Enter Registration Number to search: ");
        if (int.TryParse(Console.ReadLine(), out int searchID))
        {
            Vehicle foundVehicle = registeredVehicles.Find(v => v.RegistrationNumber == searchID);
            if (foundVehicle is Vehicle)
            {
                Console.WriteLine("\nVehicle Found:");
                foundVehicle.DisplayVehicle();
            }
            else
            {
                Console.WriteLine("Vehicle Not Found.\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Registration Number.\n");
        }
    }

    // Method to update the registration fee
    public static void SetRegistrationFee()
    {
        Console.Write("Enter new registration fee: ");
        if (double.TryParse(Console.ReadLine(), out double newFee))
        {
            Vehicle.UpdateRegistrationFee(newFee);
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a numeric fee value.\n");
        }
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("==== Vehicle Registration System ====");
            Console.WriteLine("1. Register a Vehicle");
            Console.WriteLine("2. Display All Registered Vehicles");
            Console.WriteLine("3. Search Vehicle by Registration Number");
            Console.WriteLine("4. Update Registration Fee");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    RegisterVehicle();
                    break;
                case "2":
                    DisplayAllVehicles();
                    break;
                case "3":
                    SearchVehicle();
                    break;
                case "4":
                    SetRegistrationFee();
                    break;
                case "5":
                    Console.WriteLine("Thank you! Exiting the Vehicle Registration System.");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.\n");
                    break;
            }
        }
    }
}
