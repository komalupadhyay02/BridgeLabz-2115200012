using System;
using System.Collections.Generic;

class UserNode
{
    public int UserID { get; set; }       // Unique User ID
    public string Name { get; set; }      // User's Name
    public int Age { get; set; }          // User's Age
    public List<int> FriendIDs { get; set; } // List of Friend IDs
    public UserNode Next { get; set; }    // Pointer to the next user in the list

    public UserNode(int userID, string name, int age)
    {
        UserID = userID;
        Name = name;
        Age = age;
        FriendIDs = new List<int>();
        Next = null;
    }
}

class SocialMediaSystem
{
    private UserNode head;

    public SocialMediaSystem()
    {
        head = null;
    }

    // Add a user to the system
    public void AddUser(int userID, string name, int age)
    {
        UserNode newUser = new UserNode(userID, name, age);

        if (head == null)
        {
            head = newUser;
        }
        else
        {
            UserNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newUser;
        }
    }

    // Find a user by UserID or Name
    public UserNode FindUser(int? userID = null, string name = null)
    {
        UserNode current = head;
        while (current != null)
        {
            if ((userID.HasValue && current.UserID == userID.Value) || (name != null && current.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                return current;
            }
            current = current.Next;
        }
        return null; // User not found
    }

    // Add a friend connection between two users
    public void AddFriend(int userID1, int userID2)
    {
        UserNode user1 = FindUser(userID: userID1);
        UserNode user2 = FindUser(userID: userID2);

        if (user1 != null && user2 != null && !user1.FriendIDs.Contains(userID2))
        {
            user1.FriendIDs.Add(userID2);
            user2.FriendIDs.Add(userID1);  // Since the connection is mutual
            Console.WriteLine($"User {user1.Name} and User {user2.Name} are now friends.");
        }
        else
        {
            Console.WriteLine("Either one or both users not found, or they are already friends.");
        }
    }

    // Remove a friend connection
    public void RemoveFriend(int userID1, int userID2)
    {
        UserNode user1 = FindUser(userID: userID1);
        UserNode user2 = FindUser(userID: userID2);

        if (user1 != null && user2 != null && user1.FriendIDs.Contains(userID2))
        {
            user1.FriendIDs.Remove(userID2);
            user2.FriendIDs.Remove(userID1);
            Console.WriteLine($"User {user1.Name} and User {user2.Name} are no longer friends.");
        }
        else
        {
            Console.WriteLine("Either one or both users not found, or they are not friends.");
        }
    }

    // Find mutual friends between two users
    public void FindMutualFriends(int userID1, int userID2)
    {
        UserNode user1 = FindUser(userID: userID1);
        UserNode user2 = FindUser(userID: userID2);

        if (user1 != null && user2 != null)
        {
            List<int> mutualFriends = new List<int>();
            foreach (int friendID in user1.FriendIDs)
            {
                if (user2.FriendIDs.Contains(friendID))
                {
                    mutualFriends.Add(friendID);
                }
            }

            if (mutualFriends.Count > 0)
            {
                Console.WriteLine("Mutual friends between {0} and {1}: {2}", user1.Name, user2.Name, string.Join(", ", mutualFriends));
            }
            else
            {
                Console.WriteLine("No mutual friends found between {0} and {1}.", user1.Name, user2.Name);
            }
        }
        else
        {
            Console.WriteLine("One or both users not found.");
        }
    }

    // Display all friends of a specific user
    public void DisplayFriends(int userID)
    {
        UserNode user = FindUser(userID: userID);
        if (user != null)
        {
            if (user.FriendIDs.Count > 0)
            {
                Console.WriteLine($"Friends of {user.Name}: {string.Join(", ", user.FriendIDs)}");
            }
            else
            {
                Console.WriteLine($"{user.Name} has no friends.");
            }
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    // Count the number of friends for each user
    public void CountFriends()
    {
        UserNode current = head;
        while (current != null)
        {
            Console.WriteLine($"{current.Name} has {current.FriendIDs.Count} friends.");
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        // Create a new social media system
        SocialMediaSystem system = new SocialMediaSystem();

        // Add some users
        system.AddUser(1, "Alice", 25);
        system.AddUser(2, "Bob", 30);
        system.AddUser(3, "Charlie", 22);
        system.AddUser(4, "David", 28);

        // Add friends
        system.AddFriend(1, 2);  // Alice and Bob are friends
        system.AddFriend(1, 3);  // Alice and Charlie are friends
        system.AddFriend(2, 4);  // Bob and David are friends

        // Remove a friend connection
        system.RemoveFriend(1, 3);  // Alice and Charlie are no longer friends

        // Find mutual friends
        system.FindMutualFriends(1, 2);  // Find mutual friends between Alice and Bob

        // Display all friends of a user
        system.DisplayFriends(1);  // Display Alice's friends

        // Count the number of friends for each user
        system.CountFriends();
    }
}
