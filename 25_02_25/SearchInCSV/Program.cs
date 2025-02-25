using System;
using System.IO;
class Employee{
    static void Main(){
        string filePath="employee.csv";
        Console.Write("Enter the Name:");
        string employeeName=Console.ReadLine();
         bool recordFound = false;
            using(StreamReader reader=new StreamReader(filePath)){
                if(!reader.EndOfStream)
                reader.ReadLine();
                while(!reader.EndOfStream){
                    var line=reader.ReadLine();
                    var values=line.Split(',');
                    int ID=int.Parse(values[0]);
                    string Name=values[1];
                    string Department=values[2];
                    double salary=Convert.ToDouble(values[3]);
                    if(Name.Equals(employeeName,StringComparison.OrdinalIgnoreCase)){
                        Console.WriteLine($"ID:{ID} Name:{Name} Department:{Department} salary:{salary}");
                        recordFound=true;
                        break;
                    }
                }
            }
        
        if (!recordFound)
            {
                Console.WriteLine("Employee not found.");
            }
    }
}