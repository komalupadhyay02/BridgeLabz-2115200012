using System;
class Book{
    string title{get;set;}
    string Author{get;set;}
    double price{get;set;}
    public Book(){
        title="The Midnight Library";
        Author="Matt Haig";
        price=1200;
    }

    //parameterized constructor
    public Book(string title, string Author, double price){
        this.title=title;
        this.Author=Author;
        this.price=price;
    }
    public void Display(){
        Console.WriteLine($"Title: {title} Author: {Author} price:{price}");
    }
    public static void Main(string[]Args){
        Book book1=new Book();
        book1.Display();
        Book book2=new Book("The Great Gatsby", "F. Scott Fitzgerald", 10.99);
        book2.Display();

    }
}