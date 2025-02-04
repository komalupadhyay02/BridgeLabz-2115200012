using System;

class DateTime
{
    static void Main()
    {
        
        DateTimeOffset utcNow = DateTimeOffset.UtcNow;
        Console.WriteLine("Current UTC Time: " + utcNow);

        // Convert to different time zones
        DisplayTimeInZone(utcNow, "Greenwich Mean Time", "GMT Standard Time");
        DisplayTimeInZone(utcNow, "Indian Standard Time", "India Standard Time");
        DisplayTimeInZone(utcNow, "Pacific Standard Time", "Pacific Standard Time");
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
