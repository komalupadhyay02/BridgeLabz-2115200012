using System;
using System.IO;
class FileNotFoundExceptionExample
{
    static void Main(string[] args)
    {
        
        try{
            File.OpenRead("data.txt");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found: " + e.Message);
        }
    }
}
