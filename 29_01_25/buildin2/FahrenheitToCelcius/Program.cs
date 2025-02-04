using System;

class TemperatureConverter
{
    static void Main()
    {
        Console.WriteLine("Temperature Converter:");
        Console.Write("Enter temperature: ");
        double temperature = double.Parse(Console.ReadLine());

        Console.Write("Convert to (C)elsius or (F)ahrenheit? ");
        char choice = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        if (choice == 'C')
        {
            Console.WriteLine($"Converted Temperature: {FahrenheitToCelsius(temperature):F2}°C");
        }
        else if (choice == 'F')
        {
            Console.WriteLine($"Converted Temperature: {CelsiusToFahrenheit(temperature):F2}°F");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }
}