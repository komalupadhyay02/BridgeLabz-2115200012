using System;
class Book{
    string Author{get;set;}
    string title{get;set;}
    public Book(string title,string Author){
        this.Author=Author;
        this.title=title;
    }
    public void Display(){
        Console.WriteLine($"Title:{title}\n Author:{Author}");
    }
}
class Library{
    private List<Book>books;
    string name{get;set;}
    public Library(string name){
        name=name;
        books=new List<Book>();
    }
    public void AddBook(Book book){
        books.Add(book);
    }
    public void ShowBook(){
        Console.WriteLine($"Library:{name}");
        foreach(var book in books){
        book.Display();
        }
    }
}
class Library_books{
    static void Main(string[] args){
        Book book1 = new Book("The Catcher in the Rye", "J.D. Salinger");
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee");
        Book book3 = new Book("1984", "George Orwell");
        Library library1=new Library("Central Library");
        Library library2=new Library("Hawkins Library");
        library1.AddBook(book1);
        library1.AddBook(book3);
        library2.AddBook(book1);
        library2.AddBook(book2);
        library1.ShowBook();
        Console.WriteLine();
        library2.ShowBook();
    }
}