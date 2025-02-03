using System;
class Circle{
    double radius{get;set;}
    public Circle():this(5.0)// Calls parameterized constructor with default value
    {
        Console.WriteLine("Default Constructor Called.");
    } 
    public Circle(double radius){
        this.radius=radius;
        Console.WriteLine("parameterized constructor called.");
    }
    public double GetArea(){
        return Math.PI*radius*radius;
    }
    public void Display(){
        Console.WriteLine($"Radius:{radius} , Area: {GetArea()}");
    }
    static void Main(string[]args){
        Circle circle1=new Circle();
        circle1.Display();
        Circle circle2=new Circle(0.8);
        circle2.Display();
    }
}