using System;
using System.Collections.Generic;

// Abstract class LibraryItem
abstract class LibraryItem
{
    protected int itemId;
    protected string title;
    protected string author;

    public int ItemId { get => itemId; set => itemId = value; }
    public string Title { get => title; set => title = value; }
    public string Author { get => author; set => author = value; }

    public LibraryItem(int itemId, string title, string author)
    {
        this.itemId = itemId;
        this.title = title;
        this.author = author;
    }

    public abstract int GetLoanDuration();

    public virtual void GetItemDetails()
    {
        Console.WriteLine($"ID: {itemId}, Title: {title}, Author: {author}");
    }
}

// Interface IReservable
interface IReservable
{
    void ReserveItem();
    bool CheckAvailability();
}

// Book subclass
class Book : LibraryItem, IReservable
{
    public Book(int itemId, string title, string author)
        : base(itemId, title, author) { }

    public override int GetLoanDuration()
    {
        return 14; // 14-day loan for books
    }

    public void ReserveItem()
    {
        Console.WriteLine($"Book '{title}' has been reserved.");
    }

    public bool CheckAvailability()
    {
        return true; // Assume always available
    }
}

// Magazine subclass
class Magazine : LibraryItem
{
    public Magazine(int itemId, string title, string author)
        : base(itemId, title, author) { }

    public override int GetLoanDuration()
    {
        return 7; // 7-day loan for magazines
    }
}

// DVD subclass
class DVD : LibraryItem, IReservable
{
    public DVD(int itemId, string title, string author)
        : base(itemId, title, author) { }

    public override int GetLoanDuration()
    {
        return 5; // 5-day loan for DVDs
    }

    public void ReserveItem()
    {
        Console.WriteLine($"DVD '{title}' has been reserved.");
    }

    public bool CheckAvailability()
    {
        return false; // Assume unavailable
    }
}

// Main program
class Program
{
    static void ManageLibraryItems(List<LibraryItem> items)
    {
        foreach (var item in items)
        {
            item.GetItemDetails();
            Console.WriteLine($"Loan Duration: {item.GetLoanDuration()} days");
        }
    }

    static void Main()
    {
        List<LibraryItem> items = new List<LibraryItem>
        {
            new Book(1, "The Great Gatsby", "F. Scott Fitzgerald"),
            new Magazine(2, "National Geographic", "Various"),
            new DVD(3, "Inception", "Christopher Nolan")
        };

        ManageLibraryItems(items);
    }
}
