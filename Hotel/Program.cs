using System;
class HotelBooking{
    string guestName{get;set;}
    string roomType{get;set;}
    int nights{get;set;}
    //default constructor
    public HotelBooking():this("Joyce","AC",2){
        Console.WriteLine("Default constructor");
    }
    //parameterized constructor
    public HotelBooking(string guestName,string roomType,int nights){
        this.guestName=guestName;
        this.roomType=roomType;
        this.nights=nights;
    }
    //copy constructor
    public HotelBooking(HotelBooking copy){
        guestName=copy.guestName;
        roomType=copy.roomType;
        nights=copy.nights;
        Console.WriteLine("Copy Constructor called.");
    }
    public void Display(){
        Console.WriteLine($"guestName:{guestName}\nroomType:{roomType}\nnights: {nights}");
    }
    static void Main(string[]args){
        HotelBooking booking1=new HotelBooking();
        booking1.Display();
        HotelBooking booking2=new HotelBooking("Annie","AC room",4);
        booking2.Display();
        HotelBooking booking3=new HotelBooking(booking2);
        booking3.Display();
    }
}
