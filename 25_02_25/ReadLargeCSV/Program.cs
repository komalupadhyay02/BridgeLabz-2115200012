using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "large_file.csv";  // Path to the large CSV file
        int chunkSize = 100;  // Number of lines to read in each chunk
        int recordsProcessed = 0;  // Keep track of the number of records processed

        try
        {
            // Create a StreamReader to read the file line by line
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                int chunkCount = 0;  // Count how many chunks have been processed

                // Skip the header row if present
                string header = reader.ReadLine();
                chunkCount++;

                while ((line = reader.ReadLine()) != null)
                {
                    // Process 100 lines at a time
                    if (chunkCount % chunkSize == 1)
                    {
                        Console.WriteLine($"Processing chunk {chunkCount / chunkSize + 1}...");
                    }

                    // Process the current line (you can add custom processing logic here)
                    // Example: Parsing the line to extract fields, etc.
                    // For this case, we just display the line.
                    Console.WriteLine(line);

                    recordsProcessed++;

                    // After processing 100 lines, output the processed record count
                    if (recordsProcessed % chunkSize == 0)
                    {
                        Console.WriteLine($"Processed {recordsProcessed} records.");
                    }

                    chunkCount++;
                }

                // Handle the case where the last chunk has fewer than 100 lines
                if (recordsProcessed % chunkSize != 0)
                {
                    Console.WriteLine($"Processed {recordsProcessed} records in total.");
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error reading the file: {e.Message}");
        }
    }
}
