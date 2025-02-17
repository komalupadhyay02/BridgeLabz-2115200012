using System;
using System.IO;
class UserInput{
    static void Main(){
        Console.WriteLine("Enter the file path to save your input:");
        string filePath = Console.ReadLine();
        Console.WriteLine("Start entering text (type 'exit' to finish):");
        try{
            using(StreamWriter writer=new StreamWriter(filePath)){
                string input;
                while(true){
                    input = Console.ReadLine();
                    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                        break;
                }
                writer.WriteLine(input);
            }
             Console.WriteLine($"Your input has been saved to '{filePath}'.");
        }
        catch(Exception ex){
            Console.WriteLine($"An error occurred!");
        }
    }
}