using System;

public class Movie
{
    public string Title;
    public string Director;
    public int YearOfRelease;
    public double Rating;
    public Movie Next;
    public Movie Prev;

    public Movie(string title, string director, int yearOfRelease, double rating)
    {
        Title = title;
        Director = director;
        YearOfRelease = yearOfRelease;
        Rating = rating;
        Next = null;
        Prev = null;
    }
}

public class MovieDoublyLinkedList
{
    private Movie head;
    private Movie tail;

    public MovieDoublyLinkedList()
    {
        head = null;
        tail = null;
    }

    // Add a movie record at the beginning
    public void AddAtBeginning(string title, string director, int yearOfRelease, double rating)
    {
        Movie newMovie = new Movie(title, director, yearOfRelease, rating);
        if (head == null)
        {
            head = newMovie;
            tail = newMovie;
        }
        else
        {
            newMovie.Next = head;
            head.Prev = newMovie;
            head = newMovie;
        }
    }

    // Add a movie record at the end
    public void AddAtEnd(string title, string director, int yearOfRelease, double rating)
    {
        Movie newMovie = new Movie(title, director, yearOfRelease, rating);
        if (tail == null)
        {
            head = newMovie;
            tail = newMovie;
        }
        else
        {
            tail.Next = newMovie;
            newMovie.Prev = tail;
            tail = newMovie;
        }
    }

    // Add a movie record at a specific position
    public void AddAtPosition(int position, string title, string director, int yearOfRelease, double rating)
    {
        if (position == 0)
        {
            AddAtBeginning(title, director, yearOfRelease, rating);
            return;
        }

        Movie newMovie = new Movie(title, director, yearOfRelease, rating);
        Movie temp = head;
        int count = 0;

        while (temp != null && count < position - 1)
        {
            temp = temp.Next;
            count++;
        }

        if (temp == null)
        {
            Console.WriteLine("Position out of range!");
            return;
        }

        newMovie.Next = temp.Next;
        newMovie.Prev = temp;
        if (temp.Next != null)
        {
            temp.Next.Prev = newMovie;
        }
        temp.Next = newMovie;

        if (newMovie.Next == null)
        {
            tail = newMovie;
        }
    }

    // Remove a movie record by Movie Title
    public void RemoveByTitle(string title)
    {
        Movie temp = head;
        while (temp != null)
        {
            if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (temp.Prev != null)
                {
                    temp.Prev.Next = temp.Next;
                }
                else
                {
                    head = temp.Next; // Remove the head
                }

                if (temp.Next != null)
                {
                    temp.Next.Prev = temp.Prev;
                }
                else
                {
                    tail = temp.Prev; // Remove the tail
                }

                temp = null;
                Console.WriteLine($"Movie '{title}' has been removed.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Movie not found!");
    }

    // Search for a movie record by Director or Rating
    public void SearchByDirectorOrRating(string director = null, double? rating = null)
    {
        Movie temp = head;
        while (temp != null)
        {
            if ((director != null && temp.Director.Equals(director, StringComparison.OrdinalIgnoreCase)) || 
                (rating.HasValue && temp.Rating == rating))
            {
                Console.WriteLine($"Found movie: Title: {temp.Title}, Director: {temp.Director}, Year: {temp.YearOfRelease}, Rating: {temp.Rating}");
            }
            temp = temp.Next;
        }
    }

    // Display all movie records in forward order
    public void DisplayForward()
    {
        Movie temp = head;
        if (temp == null)
        {
            Console.WriteLine("No records to display.");
            return;
        }

        Console.WriteLine("Movies in Forward Order:");
        while (temp != null)
        {
            Console.WriteLine($"Title: {temp.Title}, Director: {temp.Director}, Year: {temp.YearOfRelease}, Rating: {temp.Rating}");
            temp = temp.Next;
        }
    }

    // Display all movie records in reverse order
    public void DisplayReverse()
    {
        Movie temp = tail;
        if (temp == null)
        {
            Console.WriteLine("No records to display.");
            return;
        }

        Console.WriteLine("Movies in Reverse Order:");
        while (temp != null)
        {
            Console.WriteLine($"Title: {temp.Title}, Director: {temp.Director}, Year: {temp.YearOfRelease}, Rating: {temp.Rating}");
            temp = temp.Prev;
        }
    }

    // Update a movie's Rating based on the Movie Title
    public void UpdateRating(string title, double newRating)
    {
        Movie temp = head;
        while (temp != null)
        {
            if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                temp.Rating = newRating;
                Console.WriteLine($"Updated rating for '{title}' to {newRating}.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Movie not found!");
    }
}

public class Program
{
    public static void Main()
    {
        MovieDoublyLinkedList movieList = new MovieDoublyLinkedList();
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Movie Management System");
            Console.WriteLine("1. Add Movie at Beginning");
            Console.WriteLine("2. Add Movie at End");
            Console.WriteLine("3. Add Movie at Specific Position");
            Console.WriteLine("4. Remove Movie by Title");
            Console.WriteLine("5. Display Movies in Forward Order");
            Console.WriteLine("6. Display Movies in Reverse Order");
            Console.WriteLine("7. Search Movies by Director or Rating");
            Console.WriteLine("8. Update Movie Rating");
            Console.WriteLine("9. Exit");
            Console.Write("Enter your choice: ");
            
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Title: ");
                    string title1 = Console.ReadLine();
                    Console.Write("Enter Director: ");
                    string director1 = Console.ReadLine();
                    Console.Write("Enter Year of Release: ");
                    int year1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter Rating: ");
                    double rating1 = double.Parse(Console.ReadLine());
                    movieList.AddAtBeginning(title1, director1, year1, rating1);
                    break;
                    
                case 2:
                    Console.Write("Enter Title: ");
                    string title2 = Console.ReadLine();
                    Console.Write("Enter Director: ");
                    string director2 = Console.ReadLine();
                    Console.Write("Enter Year of Release: ");
                    int year2 = int.Parse(Console.ReadLine());
                    Console.Write("Enter Rating: ");
                    double rating2 = double.Parse(Console.ReadLine());
                    movieList.AddAtEnd(title2, director2, year2, rating2);
                    break;

                case 3:
                    Console.Write("Enter Position: ");
                    int position = int.Parse(Console.ReadLine());
                    Console.Write("Enter Title: ");
                    string title3 = Console.ReadLine();
                    Console.Write("Enter Director: ");
                    string director3 = Console.ReadLine();
                    Console.Write("Enter Year of Release: ");
                    int year3 = int.Parse(Console.ReadLine());
                    Console.Write("Enter Rating: ");
                    double rating3 = double.Parse(Console.ReadLine());
                    movieList.AddAtPosition(position, title3, director3, year3, rating3);
                    break;

                case 4:
                    Console.Write("Enter Title to Remove: ");
                    string titleToRemove = Console.ReadLine();
                    movieList.RemoveByTitle(titleToRemove);
                    break;

                case 5:
                    movieList.DisplayForward();
                    break;

                case 6:
                    movieList.DisplayReverse();
                    break;

                case 7:
                    Console.Write("Enter Director (or press Enter to skip): ");
                    string searchDirector = Console.ReadLine();
                    Console.Write("Enter Rating (or press Enter to skip): ");
                    string ratingInput = Console.ReadLine();
                    double? searchRating = string.IsNullOrEmpty(ratingInput) ? (double?)null : double.Parse(ratingInput);
                    movieList.SearchByDirectorOrRating(searchDirector, searchRating);
                    break;

                case 8:
                    Console.Write("Enter Title to Update Rating: ");
                    string titleToUpdate = Console.ReadLine();
                    Console.Write("Enter New Rating: ");
                    double newRating = double.Parse(Console.ReadLine());
                    movieList.UpdateRating(titleToUpdate, newRating);
                    break;

                case 9:
                    Console.WriteLine("Exiting system...");
                    return;

                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
