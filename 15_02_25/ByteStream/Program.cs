using System;
using System.IO;
using System.Text;

class ByteToCharacterStream
{
    static void Main()
    {
        Console.WriteLine("Enter the file path:");
        string filePath = Console.ReadLine();

        Console.WriteLine("Enter the encoding (e.g., UTF-8, ASCII):");
        string encodingName = Console.ReadLine();

        try
        {
            Encoding encoding = Encoding.GetEncoding(encodingName);
            ReadFileAsCharacters(filePath, encoding);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void ReadFileAsCharacters(string filePath, Encoding encoding)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (StreamReader reader = new StreamReader(fs, encoding))
        {
            string content = reader.ReadToEnd();
            Console.WriteLine("File content as characters:");
            Console.WriteLine(content);
        }
    }
}
