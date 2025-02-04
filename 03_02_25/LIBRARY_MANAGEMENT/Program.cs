using System;
using System.Collections.Generic;

class Book
{
    static string LibraryName = "City Central Library";

    public string Title { get; private set; }
    public string Author { get; private set; }
    public bool IsAvailable { get; set; }
    public readonly int ISBN;

    // Static method to display library name
    public static void DisplayLibraryName()
    {
        Console.WriteLine($"Library Name: {LibraryName}");
    }

    public Book(string title, string author, int isbn)
    {
        this.Title = title;
        this.Author = author;
        this.ISBN = isbn;
        this.IsAvailable = true;
    }

    public void BorrowBook()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            Console.WriteLine($"Book '{Title}' has been borrowed!");
        }
        else
        {
            Console.WriteLine($"Sorry, '{Title}' is already borrowed.");
        }
    }

    public void ReturnBook()
    {
        if (!IsAvailable)
        {
            IsAvailable = true;
            Console.WriteLine($"Book '{Title}' has been returned.");
        }
        else
        {
            Console.WriteLine($"Book '{Title}' was not borrowed.");
        }
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Available: {IsAvailable}");
    }
}

class LibraryManagement
{
    private static List<Book> books = new List<Book>();

    public static void AddBook()
    {
        Console.Write("Enter the title: ");
        string name = Console.ReadLine();
        Console.Write("Enter the Author Name: ");
        string author = Console.ReadLine();
        Console.Write("Enter the ISBN: ");

        if (int.TryParse(Console.ReadLine(), out int isbn))
        {
            Book newBook = new Book(name, author, isbn);
            books.Add(newBook);
            Console.WriteLine("Book Added Successfully!");
        }
        else
        {
            Console.WriteLine("Invalid ISBN! Please enter a numeric value.\n");
        }
    }

    public static void DisplayAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No Book is Available in Library.");
            return;
        }

        Console.WriteLine("\n<<<<<<------ Available Books ----->>>>>>");
        foreach (var book in books)
        {
            book.Display();
        }
        Console.WriteLine();
    }

    public static void SearchBook()
    {
        Console.Write("Enter the ISBN to search: ");
        if (int.TryParse(Console.ReadLine(), out int searchISBN))
        {
            Book foundBook = books.Find(b => b.ISBN == searchISBN);
            if (foundBook is Book)
            {
                Console.WriteLine("\nBook Found:");
                foundBook.Display();
            }
            else
            {
                Console.WriteLine("Book Not Found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid ISBN.");
        }
        Console.WriteLine();
    }

    public static void BorrowBook()
    {
        Console.Write("Enter the ISBN to borrow: ");
        if (int.TryParse(Console.ReadLine(), out int isbn))
        {
            Book foundBook = books.Find(b => b.ISBN == isbn);
            if (foundBook is Book)
            {
                foundBook.BorrowBook();
            }
            else
            {
                Console.WriteLine("This book is not available.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ISBN.");
        }
        Console.WriteLine();
    }

    public static void ReturnBook()
    {
        Console.Write("Enter the ISBN to return: ");
        if (int.TryParse(Console.ReadLine(), out int isbn))
        {
            Book foundBook = books.Find(b => b.ISBN == isbn);
            if (foundBook is Book)
            {
                foundBook.ReturnBook();
            }
            else
            {
                Console.WriteLine("Book is Not Found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ISBN.");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("==== Library Management System ====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Display All Books");
            Console.WriteLine("3. Search Book by ISBN");
            Console.WriteLine("4. Borrow Book");
            Console.WriteLine("5. Return Book");
            Console.WriteLine("6. Display Library Name");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    DisplayAllBooks();
                    break;
                case "3":
                    SearchBook();
                    break;
                case "4":
                    BorrowBook();
                    break;
                case "5":
                    ReturnBook();
                    break;
                case "6":
                    Book.DisplayLibraryName();
                    break;
                case "7":
                    Console.WriteLine("Thank you! Successfully exited the Library Management System.");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.\n");
                    break;
            }
        }
    }
}
