using System;
using System.IO;
class Write{
    static void Main(){
        string filePath="student.csv";
        try{
        using(StreamWriter writer=new StreamWriter(filePath)){
            writer.WriteLine("ID,Name,Age,Marks");
            writer.WriteLine("102,annie,21,86");
             writer.WriteLine("103,joyce,24,78");
              writer.WriteLine("104,justin,18,75");
               writer.WriteLine("105,ginni,23,91");
                writer.WriteLine("106,Max,21,76");
                Console.WriteLine("Written Successfully!");
        }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
        }
    }
