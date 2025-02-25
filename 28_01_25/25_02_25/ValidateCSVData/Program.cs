using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "employee.csv"; // Path to your CSV file

        try
        {
            // Regex for email validation
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            // Regex for phone number validation (10 digits only)
            string phonePattern = @"^\d{10}$";

            // Read the CSV file and validate data
            using (var reader = new StreamReader(inputFilePath))
            {
                // Read the header row
                string header = reader.ReadLine();
                Console.WriteLine("Validating CSV Data...");

                // Read each line and validate email and phone number
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    // Assuming the following column structure:
                    // ID, Name, Email, PhoneNumber
                    string email = values[2]; // Email is the third column
                    string phoneNumber = values[3]; // Phone number is the fourth column

                    bool isEmailValid = Regex.IsMatch(email, emailPattern);
                    bool isPhoneNumberValid = Regex.IsMatch(phoneNumber, phonePattern);

                    // If either email or phone number is invalid, print an error message
                    if (!isEmailValid || !isPhoneNumberValid)
                    {
                        Console.WriteLine($"Invalid Row: {line}");
                        if (!isEmailValid)
                            Console.WriteLine($"  Error: Invalid email format - {email}");
                        if (!isPhoneNumberValid)
                            Console.WriteLine($"  Error: Invalid phone number format - {phoneNumber}");
                    }
                }
            }

            Console.WriteLine("CSV Data Validation Complete!");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error reading the file: " + ex.Message);
        }
    }
}
