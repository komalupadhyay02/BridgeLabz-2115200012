using System;
using System.Collections.Generic;

// Abstract class Vehicle
abstract class Vehicle
{
    protected int vehicleId;
    protected string driverName;
    protected double ratePerKm;

    public int VehicleId { get => vehicleId; set => vehicleId = value; }
    public string DriverName { get => driverName; set => driverName = value; }
    public double RatePerKm { get => ratePerKm; set => ratePerKm = value; }

    public Vehicle(int vehicleId, string driverName, double ratePerKm)
    {
        this.vehicleId = vehicleId;
        this.driverName = driverName;
        this.ratePerKm = ratePerKm;
    }

    public abstract double CalculateFare(double distance);

    public virtual void GetVehicleDetails()
    {
        Console.WriteLine($"Vehicle ID: {vehicleId}, Driver: {driverName}, Rate: {ratePerKm:C}/km");
    }
}

// Interface IGPS
interface IGPS
{
    string GetCurrentLocation();
    void UpdateLocation(string newLocation);
}

// Car subclass
class Car : Vehicle, IGPS
{
    private string location;

    public Car(int vehicleId, string driverName, double ratePerKm)
        : base(vehicleId, driverName, ratePerKm) { }

    public override double CalculateFare(double distance)
    {
        return distance * ratePerKm;
    }

    public string GetCurrentLocation()
    {
        return location;
    }

    public void UpdateLocation(string newLocation)
    {
        location = newLocation;
    }
}

// Bike subclass
class Bike : Vehicle, IGPS
{
    private string location;

    public Bike(int vehicleId, string driverName, double ratePerKm)
        : base(vehicleId, driverName, ratePerKm) { }

    public override double CalculateFare(double distance)
    {
        return distance * ratePerKm * 0.8; // 20% cheaper than car
    }

    public string GetCurrentLocation()
    {
        return location;
    }

    public void UpdateLocation(string newLocation)
    {
        location = newLocation;
    }
}

// Auto subclass
class Auto : Vehicle, IGPS
{
    private string location;

    public Auto(int vehicleId, string driverName, double ratePerKm)
        : base(vehicleId, driverName, ratePerKm) { }

    public override double CalculateFare(double distance)
    {
        return distance * ratePerKm * 0.9; // 10% cheaper than car
    }

    public string GetCurrentLocation()
    {
        return location;
    }

    public void UpdateLocation(string newLocation)
    {
        location = newLocation;
    }
}

// Main program
class Program
{
    static void ProcessRides(List<Vehicle> vehicles, double distance)
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.GetVehicleDetails();
            Console.WriteLine($"Fare for {distance} km: {vehicle.CalculateFare(distance):C}");
        }
    }

    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car(1, "Alice", 10),
            new Bike(2, "Bob", 8),
            new Auto(3, "Charlie", 9)
        };

        ProcessRides(vehicles, 15);
    }
}
