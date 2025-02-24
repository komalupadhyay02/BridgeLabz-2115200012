using System;
public class Animal{
    public virtual void MakeSound()
    {
        Console.WriteLine("some generic animal sound ");
    }
}
public class Dog:Animal{
    public override void MakeSound()
    {
        Console.WriteLine("Woof! Woof!");
    }
}
class Program{
    static void Main(){
    Dog myDog=new Dog();
    myDog.MakeSound();
    }
}