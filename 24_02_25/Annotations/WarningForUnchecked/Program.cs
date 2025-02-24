using System;
using System.Collections;
class Warning{
    static void Main(){
        // #pragma warning 169,414,640
        ArrayList arr=new ArrayList();
        arr.Add(10);
        arr.Add("hello");
        arr.Add(20);
        foreach(var i in arr){
            Console.WriteLine(i);
        }
        // #pragma warning restore 169,414,640
    }
}