using System;
using System.Collections.Generic;

// Abstract class Vehicle
abstract class Vehicle
{
    protected string vehicleNumber;
    protected string type;
    protected double rentalRate;

    public string VehicleNumber { get => vehicleNumber; set => vehicleNumber = value; }
    public string Type { get => type; set => type = value; }
    public double RentalRate { get => rentalRate; set => rentalRate = value; }

    public Vehicle(string vehicleNumber, string type, double rentalRate)
    {
        this.vehicleNumber = vehicleNumber;
        this.type = type;
        this.rentalRate = rentalRate;
    }

    public abstract double CalculateRentalCost(int days);

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Vehicle Number: {vehicleNumber}, Type: {type}, Rental Rate: {rentalRate:C}");
    }
}

// Interface IInsurable
interface IInsurable
{
    double CalculateInsurance();
    string GetInsuranceDetails();
}

// Car subclass
class Car : Vehicle, IInsurable
{
    public Car(string vehicleNumber, double rentalRate)
        : base(vehicleNumber, "Car", rentalRate) { }

    public override double CalculateRentalCost(int days)
    {
        return rentalRate * days; // Simple daily rental cost
    }

    public double CalculateInsurance()
    {
        return rentalRate * 0.05; // 5% insurance fee
    }

    public string GetInsuranceDetails()
    {
        return "Car Insurance: 5% of rental rate";
    }
}

// Bike subclass
class Bike : Vehicle
{
    public Bike(string vehicleNumber, double rentalRate)
        : base(vehicleNumber, "Bike", rentalRate) { }

    public override double CalculateRentalCost(int days)
    {
        return rentalRate * days * 0.9; // 10% discount on bikes
    }
}

// Truck subclass
class Truck : Vehicle, IInsurable
{
    public Truck(string vehicleNumber, double rentalRate)
        : base(vehicleNumber, "Truck", rentalRate) { }

    public override double CalculateRentalCost(int days)
    {
        return rentalRate * days * 1.2; // 20% surcharge for trucks
    }

    public double CalculateInsurance()
    {
        return rentalRate * 0.1; // 10% insurance fee
    }

    public string GetInsuranceDetails()
    {
        return "Truck Insurance: 10% of rental rate";
    }
}

// Main program
class Program
{
    static void CalculateRentalAndInsurance(Vehicle vehicle, int days)
    {
        double rentalCost = vehicle.CalculateRentalCost(days);
        double insuranceCost = vehicle is IInsurable insurableVehicle ? insurableVehicle.CalculateInsurance() : 0;
        double totalCost = rentalCost + insuranceCost;

        Console.WriteLine($"Total Cost for {vehicle.Type} ({vehicle.VehicleNumber}): {totalCost:C}");
    }

    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car("CAR123", 50),
            new Bike("BIKE456", 20),
            new Truck("TRUCK789", 100)
        };

        foreach (var vehicle in vehicles)
        {
            vehicle.DisplayDetails();
            CalculateRentalAndInsurance(vehicle, 5);
        }
    }
}
