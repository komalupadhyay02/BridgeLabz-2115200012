using System;
using System.Reflection;
class Student{
    public string Name{get;set;}
    public int Age{get;set;}
    public Student(string Name,int Age){
        this.Age=Age;
        this.Name=Name;
    }
     public void DisplayInfo()
    {
        Console.WriteLine($"Student Name: {Name}, Age: {Age}");
    }
}
class Reflection{
    static void Main(){
        Type Studenttype=typeof(Student);
        object studentObject=Activator.CreateInstance(Studenttype,"Komal",20);
        MethodInfo method=Studenttype.GetMethod("DisplayInfo");
        method.Invoke(studentObject,null);
    }
}