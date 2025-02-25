using System;
using System.IO;
class Marks{
    static void Main(){
        string filePath="student.csv";
        try{
            
            using(StreamReader reader=new StreamReader(filePath)){
                if(!reader.EndOfStream)
                reader.ReadLine();
                Console.WriteLine("Student having more than 80 marks");
                while(!reader.EndOfStream){
                    var line=reader.ReadLine();
                    var values=line.Split(',');
                    int ID=int.Parse(values[0]);
                    string Name=values[1];
                    int Age=int.Parse(values[2]);
                    int Marks=int.Parse(values[3]);
                
         
            if(Marks>80){
                Console.WriteLine($"\nID:{ID} Name:{Name} Age:{Age} Marks:{Marks}");
                
            }
                }
            }
            
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
    }
}