using System;

class Vehicle
{
    // Class variable (shared for all vehicles)
    public static decimal RegistrationFee = 150.00m;

    // Instance variables
    public string OwnerName { get; set; }
    public string VehicleType { get; set; }

    // Constructor to initialize vehicle details
    public Vehicle(string ownerName, string vehicleType)
    {
        OwnerName = ownerName;
        VehicleType = vehicleType;
    }

    // Instance method to display vehicle details
    public void DisplayVehicleDetails()
    {
        Console.WriteLine($"Owner Name: {OwnerName}");
        Console.WriteLine($"Vehicle Type: {VehicleType}");
        Console.WriteLine($"Registration Fee: ${RegistrationFee}");
    }

    // Class method to update the registration fee for all vehicles
    public static void UpdateRegistrationFee(decimal newFee)
    {
        RegistrationFee = newFee;
        Console.WriteLine($"Registration Fee updated to: ${RegistrationFee}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example Usage
        Vehicle vehicle1 = new Vehicle("John Doe", "Car");
        vehicle1.DisplayVehicleDetails();

        Vehicle vehicle2 = new Vehicle("Jane Smith", "Motorcycle");
        vehicle2.DisplayVehicleDetails();

        // Update the registration fee for all vehicles
        Vehicle.UpdateRegistrationFee(200.00m);

        // Display updated vehicle details
        vehicle1.DisplayVehicleDetails();
        vehicle2.DisplayVehicleDetails();
    }
}
