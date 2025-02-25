using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

class Program
{
    // AES encryption and decryption key and initialization vector (IV)
    private static readonly string Key = "0123456789ABCDEF0123456789ABCDEF"; // 32-byte key for AES-256
    private static readonly string IV = "ABCDEF0123456789"; // 16-byte IV for AES

    // Method to encrypt data using AES
    public static string Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(Key);
            aesAlg.IV = Encoding.UTF8.GetBytes(IV);

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                }

                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    // Method to decrypt data using AES
    public static string Decrypt(string cipherText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(Key);
            aesAlg.IV = Encoding.UTF8.GetBytes(IV);

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }

    // Method to convert JSON to CSV with encrypted sensitive fields
    public static void JsonToCsv(string jsonFilePath, string csvFilePath)
    {
        string jsonContent = File.ReadAllText(jsonFilePath);
        var students = JsonConvert.DeserializeObject<List<Student>>(jsonContent);

        using (var writer = new StreamWriter(csvFilePath))
        {
            writer.WriteLine("StudentID,Name,Age,Salary,Email");

            foreach (var student in students)
            {
                string encryptedSalary = Encrypt(student.Salary.ToString());
                string encryptedEmail = Encrypt(student.Email);

                writer.WriteLine($"{student.StudentID},{student.Name},{student.Age},{encryptedSalary},{encryptedEmail}");
            }
        }

        Console.WriteLine("JSON to CSV conversion with encryption completed!");
    }

    // Method to convert CSV to JSON with decrypted sensitive fields
    public static void CsvToJson(string csvFilePath, string jsonFilePath)
    {
        var students = new List<Student>();

        using (var reader = new StreamReader(csvFilePath))
        {
            string header = reader.ReadLine();  // Read the header line
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                var student = new Student
                {
                    StudentID = values[0],
                    Name = values[1],
                    Age = int.Parse(values[2]),
                    Salary = decimal.Parse(Decrypt(values[3])), // Decrypt Salary
                    Email = Decrypt(values[4])  // Decrypt Email
                };
                students.Add(student);
            }
        }

        string jsonContent = JsonConvert.SerializeObject(students, Formatting.Indented);
        File.WriteAllText(jsonFilePath, jsonContent);

        Console.WriteLine("CSV to JSON conversion with decryption completed!");
    }

    static void Main(string[] args)
    {
        // Paths to the files
        string jsonFilePath = "students.json";
        string csvFilePath = "students_encrypted.csv";
        string jsonOutputPath = "students_output_decrypted.json";

        // Convert JSON to CSV with encrypted sensitive data
        JsonToCsv(jsonFilePath, csvFilePath);

        // Convert CSV back to JSON with decrypted sensitive data
        CsvToJson(csvFilePath, jsonOutputPath);
    }
}

// Student class to map the JSON data
public class Student
{
    public string StudentID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public string Email { get; set; }
}
