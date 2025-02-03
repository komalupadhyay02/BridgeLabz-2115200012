using System;

class CarRental
{
    public string CustomerName { get; set; }
    public string CarModel { get; set; }
    public int RentalDays { get; set; }
    public double DailyRate { get; set; } = 50.0; // Default daily rental rate

    // Parameterized constructor
    public CarRental(string customerName, string carModel, int rentalDays)
    {
        CustomerName = customerName;
        CarModel = carModel;
        RentalDays = rentalDays;
        Console.WriteLine("Car rental created.");
    }

    public double CalculateTotalCost()
    {
        return RentalDays * DailyRate;
    }

    public void DisplayRentalInfo()
    {
        Console.WriteLine($"Customer: {CustomerName}, Car Model: {CarModel}, Rental Days: {RentalDays}, Total Cost: ${CalculateTotalCost():F2}");
    }

    static void Main()
    {
        CarRental rental1 = new CarRental("John Doe", "Toyota Camry", 5);
        rental1.DisplayRentalInfo();
    }
}
