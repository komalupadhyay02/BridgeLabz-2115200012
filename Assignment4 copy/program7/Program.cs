using System;

class Spring
{
    static void Main(string[] args)
    {
        // User Input
        Console.WriteLine("Enter the Month:");
        int Month = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the Day:");
        int Day = int.Parse(Console.ReadLine());

        // Call the SpringSeason method and display the result
        string result = SpringSeason(Month, Day);
        Console.WriteLine(result);
    }

    // Method to check whether it's Spring Season or not
    static string SpringSeason(int Month, int Day)
    {
        if (Month == 3 && Day >= 20 && Day <= 31)
        {
            return "It's a Spring Season";
        }
        if (Month == 4 && Day >= 1 && Day <= 30)
        {
            return "It's a Spring Season";
        }
        if (Month == 5 && Day >= 1 && Day <= 31)
        {
            return "It's a Spring Season";
        }
        if (Month == 6 && Day >= 1 && Day <= 20)
        {
            return "It's a Spring Season";
        }
        else
        {
            return "It's not a Spring Season";
        }
    }
}
