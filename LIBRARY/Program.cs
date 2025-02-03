using System;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }
    public bool IsAvailable { get; set; }

    // Parameterized constructor
    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
        IsAvailable = true;
        Console.WriteLine("Book created.");
    }

    public void BorrowBook()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            Console.WriteLine($"You have borrowed '{Title}'.");
        }
        else
        {
            Console.WriteLine($"Sorry, '{Title}' is already borrowed.");
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Price: ${Price:F2}, Available: {IsAvailable}");
    }

    static void Main()
    {
        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 10.99);
        book1.DisplayInfo();

        book1.BorrowBook();
        book1.DisplayInfo();

        book1.BorrowBook(); // Attempt to borrow again
    }
}