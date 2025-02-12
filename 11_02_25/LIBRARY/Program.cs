using System;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Add Book at Beginning");
            Console.WriteLine("2. Add Book at End");
            Console.WriteLine("3. Remove Book by Book ID");
            Console.WriteLine("4. Search Book by Title or Author");
            Console.WriteLine("5. Update Book Availability Status");
            Console.WriteLine("6. Display Books in Forward Order");
            Console.WriteLine("7. Display Books in Reverse Order");
            Console.WriteLine("8. Count Total Books");
            Console.WriteLine("9. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the Title of the book ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter the Author Name of the book ");
                    string author = Console.ReadLine();
                    Console.WriteLine("Enter the Genre of the book ");
                    string genre = Console.ReadLine();
                    Console.WriteLine("Enter the BookId of the book ");
                    int bookId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Availability Status of the book ");
                    string availabilityStatus = Console.ReadLine();
                    library.AddAtBeginning(title, author, genre, bookId, availabilityStatus);
                    break;
                case 2:
                    Console.Write("Enter Book ID: ");
                    int bookID2 = int.Parse(Console.ReadLine());
                    Console.Write("Enter Book Title: ");
                    string title2 = Console.ReadLine();
                    Console.Write("Enter Book Author: ");
                    string author2 = Console.ReadLine();
                    Console.Write("Enter Book Genre: ");
                    string genre2 = Console.ReadLine();
                    Console.Write("Enter Availability Status: ");
                    string status2 = Console.ReadLine();
                    library.AddAtEnd(title2, author2, genre2, bookID2, status2);
                    break;
                case 3:
                    Console.Write("Enter Book ID to Remove: ");
                    int bookIDToRemove = int.Parse(Console.ReadLine());
                    library.RemoveById(bookIDToRemove);
                    break;
                case 4:
                    Console.Write("Enter Title or Author to Search: ");
                    string searchTerm = Console.ReadLine();
                    library.SearchById(searchTerm);
                    break;
                case 5:
                    Console.Write("Enter Book ID to Update: ");
                    int bookIDToUpdate = int.Parse(Console.ReadLine());
                    Console.Write("Enter New Availability Status: ");
                    string newStatus = Console.ReadLine();
                    library.UpdateAvailabilityStatus(bookIDToUpdate, newStatus);
                    break;

                case 6:
                    library.DisplayForward();
                    break;

                case 7:
                    library.DisplayReverse();
                    break;

                case 8:
                    library.CountTotalBooks();
                    break;

                case 9:
                    Console.WriteLine("Exiting system...");
                    return;

                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int BookId { get; set; }
    public string AvailabilityStatus { get; set; }
    public Book Next;
    public Book Prev;

    public Book(string title, string author, string genre, int bookId, string availabilityStatus)
    {
        Title = title;
        Author = author;
        Genre = genre;
        BookId = bookId;
        AvailabilityStatus = availabilityStatus;
        Next = null;
        Prev = null;
    }
}

public class Library
{
    private Book head;
    private Book tail;
    private int BookCount;

    public Library()
    {
        head = null;
        tail = null;
        BookCount = 0;
    }

    public void AddAtBeginning(string title, string author, string genre, int bookId, string availabilityStatus)
    {
        Book newBook = new Book(title, author, genre, bookId, availabilityStatus);

        if (head == null)
        {
            head = tail = newBook;
        }
        else
        {
            newBook.Next = head;
            head.Prev = newBook;
            head = newBook;
        }
        BookCount++;
    }

    public void AddAtEnd(string title, string author, string genre, int bookId, string availabilityStatus)
    {
        Book newBook = new Book(title, author, genre, bookId, availabilityStatus);

        if (head == null)
        {
            head = tail = newBook;
        }
        else
        {
            tail.Next = newBook;
            newBook.Prev = tail;
            tail = newBook;
        }
        BookCount++;
    }

    public void RemoveById(int bookId)
    {
        if (head == null)
        {
            Console.WriteLine("No books in the library.");
            return;
        }
        Book temp = head;
        while (temp != null)
        {
            if (temp.BookId == bookId)
            {
                if (temp.Prev != null)
                {
                    temp.Prev.Next = temp.Next;
                }
                else
                {
                    head = temp.Next;
                }

                if (temp.Next != null)
                {
                    temp.Next.Prev = temp.Prev;
                }
                else
                {
                    tail = temp.Prev;
                }

                Console.WriteLine($"Book with ID {bookId} removed.");
                BookCount--;
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine($"Book with ID {bookId} not found.");
    }

    public void SearchById(string searchValue)
    {
        Book temp = head;
        bool found = false;
        while (temp != null)
        {
            if (temp.Title.ToLower().Contains(searchValue.ToLower()) || temp.Author.ToLower().Contains(searchValue.ToLower()))
            {
                Console.WriteLine($"Book Found --> Title: {temp.Title}\n Author: {temp.Author}\n BookId: {temp.BookId}\n Genre: {temp.Genre}\n AvailabilityStatus: {temp.AvailabilityStatus}");
                found = true;
                break;
            }
            temp = temp.Next;
        }
        if (!found)
        {
            Console.WriteLine("Book Not Found");
        }
    }

    public void UpdateAvailabilityStatus(int bookId, string newStatus)
    {
        Book temp = head;
        while (temp != null)
        {
            if (temp.BookId == bookId)
            {
                temp.AvailabilityStatus = newStatus;
                Console.WriteLine("Status updated");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine($"Book with ID {bookId} not found.");
    }

    public void DisplayForward()
    {
        if (head == null)
        {
            Console.WriteLine("No book Available.");
            return;
        }

        Book temp = head;
        while (temp != null)
        {
            Console.WriteLine($"Title: {temp.Title}\n Author: {temp.Author}\n BookId: {temp.BookId}\n Genre: {temp.Genre}\n AvailabilityStatus: {temp.AvailabilityStatus}");
            temp = temp.Next;
        }
    }

    public void DisplayReverse()
    {
        if (head == null)
        {
            Console.WriteLine("No book Available.");
            return;
        }

        Book temp = tail;
        while (temp != null)
        {
            Console.WriteLine($"Title: {temp.Title}\n Author: {temp.Author}\n BookId: {temp.BookId}\n Genre: {temp.Genre}\n AvailabilityStatus: {temp.AvailabilityStatus}");
            temp = temp.Prev;
        }
    }

    public void CountTotalBooks()
    {
        Console.WriteLine($"Total number of books in the library: {BookCount}");
    }
}
