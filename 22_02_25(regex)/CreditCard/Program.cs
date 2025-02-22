using System;
using System.Text.RegularExpressions;

class CreditCardValidator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a credit card number:");
        string cardNumber = Console.ReadLine();

        if (IsValidVisaCard(cardNumber))
        {
            Console.WriteLine("Valid Visa card number.");
        }
        else if (IsValidMasterCard(cardNumber))
        {
            Console.WriteLine("Valid MasterCard number.");
        }
        else
        {
            Console.WriteLine("Invalid credit card number.");
        }
    }

    static bool IsValidVisaCard(string cardNumber)
    {
        // Visa card: starts with 4 and has 16 digits
        string visaPattern = @"^4\d{15}$";
        return Regex.IsMatch(cardNumber, visaPattern);
    }

    static bool IsValidMasterCard(string cardNumber)
    {
        // MasterCard: starts with 5 and has 16 digits
        string masterCardPattern = @"^5\d{15}$";
        return Regex.IsMatch(cardNumber, masterCardPattern);
    }
}
