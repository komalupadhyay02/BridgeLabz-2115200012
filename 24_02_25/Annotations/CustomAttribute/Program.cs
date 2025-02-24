using System;
using System.Reflection;
[AttributeUsage(AttributeTargets.Method,Inherited=false)]
public class TaskInfo:Attribute{
    public int priority{get;}
    public string AssignedTo{get;}
    public TaskInfo(int priority,string AssignedTo){
        this.priority=priority;
        this.AssignedTo=AssignedTo;
    }
} 
class TaskManager{
    [TaskInfo(1,"komal")]
    public void Task1(){
        Console.WriteLine("Executing task1.....");
    }
    [TaskInfo(3,"rhea")]
    public void Task2(){
        Console.WriteLine("Executing task2.....");
    }
    [TaskInfo(2,"Nancy")]
    public void Task3(){
        Console.WriteLine("Executing task3.....");
    }
}
class Program{
    static void Main(){
        TaskManager task=new TaskManager();
        MethodInfo[] methods=typeof(TaskManager).GetMethods();
        foreach(MethodInfo method in methods){
 var attribute = (TaskInfo)Attribute.GetCustomAttribute(method, typeof(TaskInfo));
            if(attribute!=null){
                Console.WriteLine($"Method: {method.Name}");
                Console.WriteLine($"Priority: {attribute.priority}");
                Console.WriteLine($"Assigned To: {attribute.AssignedTo}");
                Console.WriteLine();

            }
        }
    }
}