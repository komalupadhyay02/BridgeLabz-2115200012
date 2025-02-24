using System;
using System.Reflection;
class Calculator{
    private int Multiply(int a, int b)=>a*b;

}
class Reflection{
    static void Main(){
        Calculator cal=new Calculator();
        Type type = cal.GetType();
        MethodInfo method=type.GetMethod("Multiply",BindingFlags.NonPublic | BindingFlags.Instance);
        int result=(int)method.Invoke(cal,new object[]{5,10});
        Console.WriteLine("Multiplication Result: " + result);

    }
} 