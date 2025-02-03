using System;
class Person{
    string Name{get;set;}
    int Age{get;set;}
    public Person(string Name, int Age){
        this.Name=Name;
        this.Age=Age;
    }
    public Person(Person other){
        Name=other.Name;
        Age=other.Age;
        Console.WriteLine("Copy constructor called.");
    }
    public void Display(){
        Console.WriteLine($"Name:{Name} , Age:{Age}");
    }
    static void Main(string[] args){
        Person person1=new Person("Joyce",25);
        person1.Display();
        Person person2=new Person(person1);
        person2.Display();
    }
    
}