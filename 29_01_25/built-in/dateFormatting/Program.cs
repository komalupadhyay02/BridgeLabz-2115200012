using System;

class dateFormatting
{
    static void Main()
    {
        // Problem 1: Time Zones and DateTimeOffset
        DateTimeOffset utcNow = DateTimeOffset.UtcNow;
        Console.WriteLine("Current UTC Time: " + utcNow);

        DisplayTimeInZone(utcNow, "Greenwich Mean Time", "GMT Standard Time");
        DisplayTimeInZone(utcNow, "Indian Standard Time", "India Standard Time");
        DisplayTimeInZone(utcNow, "Pacific Standard Time", "Pacific Standard Time");

        // Problem 2: Date Arithmetic
        Console.Write("Enter a date (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime inputDate))
        {
            DateTime newDate = inputDate.AddDays(7).AddMonths(1).AddYears(2);
            newDate = newDate.AddDays(-21); // Subtracting 3 weeks

            Console.WriteLine("Final Date after arithmetic operations: " + newDate.ToString("yyyy-MM-dd"));
        }
        else
        {
            Console.WriteLine("Invalid date format.");
        }

        // Problem 3: Date Formatting
        DateTime currentDate = DateTime.Now;
        Console.WriteLine("Date in format dd/MM/yyyy: " + currentDate.ToString("dd/MM/yyyy"));
        Console.WriteLine("Date in format yyyy-MM-dd: " + currentDate.ToString("yyyy-MM-dd"));
        Console.WriteLine("Date in format EEE, MMM dd, yyyy: " + currentDate.ToString("ddd, MMM dd, yyyy"));
    }

    static void DisplayTimeInZone(DateTimeOffset utcTime, string zoneName, string timeZoneId)
    {
        try
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            DateTimeOffset localTime = TimeZoneInfo.ConvertTime(utcTime, timeZone);
            Console.WriteLine($"{zoneName}: {localTime}");
        }
        catch (TimeZoneNotFoundException)
        {
            Console.WriteLine($"Time zone '{zoneName}' not found on this system.");
        }
        catch (InvalidTimeZoneException)
        {
            Console.WriteLine($"Invalid time zone '{zoneName}'.");
        }
    }
}
