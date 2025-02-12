using System;

public class TicketNode
{
    public int TicketId { get; set; }
    public string CustomerName { get; set; }
    public string MovieName { get; set; }
    public string SeatNumber { get; set; }
    public DateTime BookingTime { get; set; }
    public TicketNode Next { get; set; }

    public TicketNode(int ticketId, string customerName, string movieName, string seatNumber, DateTime bookingTime)
    {
        TicketId = ticketId;
        CustomerName = customerName;
        MovieName = movieName;
        SeatNumber = seatNumber;
        BookingTime = bookingTime;
        Next = null;
    }
}

public class CircularLinkedList
{
    private TicketNode head = null;

    // Add a new ticket reservation at the end of the list
    public void AddTicket(int ticketId, string customerName, string movieName, string seatNumber, DateTime bookingTime)
    {
        TicketNode newTicket = new TicketNode(ticketId, customerName, movieName, seatNumber, bookingTime);

        if (head == null)
        {
            head = newTicket;
            newTicket.Next = head;  // Point to itself to form a circular list
        }
        else
        {
            TicketNode current = head;
            while (current.Next != head)
            {
                current = current.Next;
            }
            current.Next = newTicket;
            newTicket.Next = head;  // Maintain the circular link
        }
    }

    // Remove a ticket by Ticket ID
    public void RemoveTicket(int ticketId)
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        TicketNode current = head;
        TicketNode previous = null;

        // Handle the case where the head is to be removed
        if (current.TicketId == ticketId)
        {
            if (current.Next == head)  // Only one ticket in the list
            {
                head = null;
            }
            else
            {
                // Traverse to the last node
                while (current.Next != head)
                {
                    current = current.Next;
                }
                // Remove head node
                current.Next = head.Next;
                head = head.Next;
            }
            return;
        }

        // Traverse the list to find the ticket
        do
        {
            previous = current;
            current = current.Next;
            if (current.TicketId == ticketId)
            {
                previous.Next = current.Next;
                return;
            }
        } while (current != head);

        Console.WriteLine("Ticket not found.");
    }

    // Display all current tickets in the list
    public void DisplayTickets()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets available.");
            return;
        }

        TicketNode current = head;
        do
        {
            Console.WriteLine($"Ticket ID: {current.TicketId}, Customer: {current.CustomerName}, Movie: {current.MovieName}, Seat: {current.SeatNumber}, Booking Time: {current.BookingTime}");
            current = current.Next;
        } while (current != head);
    }

    // Search for a ticket by Customer Name or Movie Name
    public void SearchTicket(string searchTerm)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets available.");
            return;
        }

        TicketNode current = head;
        bool found = false;
        do
        {
            if (current.CustomerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || current.MovieName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Ticket ID: {current.TicketId}, Customer: {current.CustomerName}, Movie: {current.MovieName}, Seat: {current.SeatNumber}, Booking Time: {current.BookingTime}");
                found = true;
            }
            current = current.Next;
        } while (current != head);

        if (!found)
        {
            Console.WriteLine("No matching tickets found.");
        }
    }

    // Calculate the total number of booked tickets
    public int TotalTickets()
    {
        if (head == null)
        {
            return 0;
        }

        int count = 0;
        TicketNode current = head;
        do
        {
            count++;
            current = current.Next;
        } while (current != head);

        return count;
    }
}

class Program
{
    static void Main()
    {
        CircularLinkedList ticketList = new CircularLinkedList();

        // Add tickets
        ticketList.AddTicket(1, "John Doe", "Avengers", "A1", DateTime.Now);
        ticketList.AddTicket(2, "Jane Smith", "Batman", "B2", DateTime.Now);
        ticketList.AddTicket(3, "Jim Brown", "Avengers", "C3", DateTime.Now);

        // Display tickets
        Console.WriteLine("All tickets:");
        ticketList.DisplayTickets();

        // Search tickets by Customer Name or Movie Name
        Console.WriteLine("\nSearch results for 'Avengers':");
        ticketList.SearchTicket("Avengers");

        // Remove a ticket
        ticketList.RemoveTicket(2);
        Console.WriteLine("\nTickets after removing ticket ID 2:");
        ticketList.DisplayTickets();

        // Display total number of booked tickets
        Console.WriteLine($"\nTotal tickets booked: {ticketList.TotalTickets()}");
    }
}
