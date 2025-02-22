using System;
using System.Collections.Generic;

class ReverseListExample
{
    // Method to reverse a List<T>
    public static List<int> ReverseList(List<int> list)
    {
        List<int> reversedList = new List<int>();
        for (int i = list.Count - 1; i >= 0; i--)
        {
            reversedList.Add(list[i]);
        }
        return reversedList;
    }

    // Method to reverse a LinkedList<T>
    public static LinkedList<int> ReverseLinkedList(LinkedList<int> linkedList)
    {
        LinkedList<int> reversedList = new LinkedList<int>();
        foreach (var item in linkedList)
        {
            reversedList.AddFirst(item); // Add each item to the front of the new LinkedList
        }
        return reversedList;
    }

    static void Main(string[] args)
    {
        // Example with List<T>
        List<int> list = new List<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine("Original List: " + string.Join(", ", list));
        List<int> reversedList = ReverseList(list);
        Console.WriteLine("Reversed List: " + string.Join(", ", reversedList));

        // Example with LinkedList<T>
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddLast(1);
        linkedList.AddLast(2);
        linkedList.AddLast(3);
        linkedList.AddLast(4);
        linkedList.AddLast(5);
        Console.Write("Original LinkedList: ");
        foreach (var item in linkedList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        LinkedList<int> reversedLinkedList = ReverseLinkedList(linkedList);
        Console.Write("Reversed LinkedList: ");
        foreach (var item in reversedLinkedList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
