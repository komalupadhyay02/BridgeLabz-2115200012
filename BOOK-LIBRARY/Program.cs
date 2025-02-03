using System;

// Base class: Book
class Book
{
    // Public member for ISBN
    public string ISBN { get; set; }

    // Protected member for title (accessible in derived classes)
    protected string Title { get; set; }

    // Private member for author
    private string Author { get; set; }

    // Constructor to initialize book details
    public Book(string isbn, string title, string author)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
    }

    // Public method to get the author's name
    public string GetAuthor()
    {
        return Author;
    }

    // Public method to set the author's name
    public void SetAuthor(string author)
    {
        Author = author;
    }
}

// Subclass: EBook
class EBook : Book
{
    // Constructor for EBook
    public EBook(string isbn, string title, string author)
        : base(isbn, title, author)
    {
    }

    // Method to display eBook details
    public void DisplayEBookDetails()
    {
        Console.WriteLine($"ISBN: {ISBN}"); // Accessing public member
        Console.WriteLine($"Title: {Title}"); // Accessing protected member
        Console.WriteLine($"Author: {GetAuthor()}"); // Accessing private member through public method
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an EBook instance
        EBook ebook = new EBook("978-1234567890", "C# Programming", "John Doe");

        // Display eBook details
        ebook.DisplayEBookDetails();

        // Modify the author's name using public method
        ebook.SetAuthor("Jane Smith");

        // Display updated eBook details
        Console.WriteLine("\nUpdated EBook Details:");
        ebook.DisplayEBookDetails();
    }
}