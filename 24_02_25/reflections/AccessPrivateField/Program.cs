using System;
using System.Reflection;
class Person{
    private int Age=25;

}
class Reflection{
    static void Main(){
        Person person=new Person();
        Type type=person.GetType();
        FieldInfo field=type.GetField("Age",BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine("Old Value: " + field.GetValue(person));
        field.SetValue(person, 40);
        Console.WriteLine("New Value: " + field.GetValue(person));


    }
}