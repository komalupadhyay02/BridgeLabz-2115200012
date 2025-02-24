using System;
using System.Reflection;
[AttributeUsage(AttributeTargets.Class)]
public class AuthorAttribute : Attribute
{
    public string AuthorName { get; }

    public AuthorAttribute(string authorName)
    {
        AuthorName = authorName;
    }
}
[Author("Annie")]
public class SampleClass{
    public void Display()
    {
        Console.WriteLine("This is a sample class.");
    }
}
class Program{
    static void Main(){
        Type sampleClassType=typeof(SampleClass);
         var authorAttribute = (AuthorAttribute)Attribute.GetCustomAttribute(sampleClassType, typeof(AuthorAttribute));
        
        if (authorAttribute != null)
        {
            // Display the value of the Author attribute
            Console.WriteLine($"Author of the class {sampleClassType.Name}: {authorAttribute.AuthorName}");
        }
        else
        {
            Console.WriteLine("No Author attribute found.");
        }
    }
}