using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "data.csv";  // Path to the CSV file
        HashSet<int> seenIds = new HashSet<int>();  // Set to track unique IDs
        List<string> duplicates = new List<string>();  // List to store duplicate rows

        try
        {
            // Open the file for reading
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                reader.ReadLine();  // Skip the header row (if exists)

                // Read each line in the file
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    // Assuming the ID is the first column
                    int id = int.Parse(values[0]);

                    // Check if the ID has already been seen
                    if (seenIds.Contains(id))
                    {
                        // It's a duplicate, add the whole line to the duplicates list
                        duplicates.Add(line);
                    }
                    else
                    {
                        // Otherwise, add the ID to the seen set
                        seenIds.Add(id);
                    }
                }
            }

            // Print duplicate records
            if (duplicates.Count > 0)
            {
                Console.WriteLine("Duplicate Records Detected:");
                foreach (var duplicate in duplicates)
                {
                    Console.WriteLine(duplicate);
                }
            }
            else
            {
                Console.WriteLine("No duplicate records found.");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error reading the file: {e.Message}");
        }
    }
}
