using System;

public class Item
{
    public string ItemName;
    public int ItemID;
    public int Quantity;
    public decimal Price;
    public Item Next;

    public Item(int itemID, string itemName, int quantity, decimal price)
    {
        ItemID = itemID;
        ItemName = itemName;
        Quantity = quantity;
        Price = price;
        Next = null;
    }
}

public class InventoryManagementSystem
{
    private Item head;

    public InventoryManagementSystem()
    {
        head = null;
    }

    // Add an item at the beginning
    public void AddAtBeginning(int itemID, string itemName, int quantity, decimal price)
    {
        Item newItem = new Item(itemID, itemName, quantity, price);
        newItem.Next = head;
        head = newItem;
    }

    // Add an item at the end
    public void AddAtEnd(int itemID, string itemName, int quantity, decimal price)
    {
        Item newItem = new Item(itemID, itemName, quantity, price);
        if (head == null)
        {
            head = newItem;
        }
        else
        {
            Item temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newItem;
        }
    }

    // Add an item at a specific position
    public void AddAtPosition(int position, int itemID, string itemName, int quantity, decimal price)
    {
        Item newItem = new Item(itemID, itemName, quantity, price);

        if (position == 0)
        {
            AddAtBeginning(itemID, itemName, quantity, price);
            return;
        }

        Item temp = head;
        int count = 0;
        while (temp != null && count < position - 1)
        {
            temp = temp.Next;
            count++;
        }

        if (temp == null)
        {
            Console.WriteLine("Position out of range.");
            return;
        }

        newItem.Next = temp.Next;
        temp.Next = newItem;
    }

    // Remove an item by Item ID
    public void RemoveByItemID(int itemID)
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        if (head.ItemID == itemID)
        {
            head = head.Next;
            Console.WriteLine($"Item with ID {itemID} removed.");
            return;
        }

        Item temp = head;
        while (temp.Next != null && temp.Next.ItemID != itemID)
        {
            temp = temp.Next;
        }

        if (temp.Next == null)
        {
            Console.WriteLine($"Item with ID {itemID} not found.");
            return;
        }

        temp.Next = temp.Next.Next;
        Console.WriteLine($"Item with ID {itemID} removed.");
    }

    // Update the quantity of an item by Item ID
    public void UpdateQuantity(int itemID, int newQuantity)
    {
        Item temp = head;
        while (temp != null)
        {
            if (temp.ItemID == itemID)
            {
                temp.Quantity = newQuantity;
                Console.WriteLine($"Item with ID {itemID} updated with new quantity: {newQuantity}.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine($"Item with ID {itemID} not found.");
    }

    // Search for an item by Item ID or Item Name
    public void SearchItem(string searchValue)
    {
        Item temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.ItemID.ToString() == searchValue || temp.ItemName.ToLower() == searchValue.ToLower())
            {
                Console.WriteLine($"Item found: ID: {temp.ItemID}, Name: {temp.ItemName}, Quantity: {temp.Quantity}, Price: {temp.Price:C}");
                found = true;
                break;
            }
            temp = temp.Next;
        }

        if (!found)
        {
            Console.WriteLine("Item not found.");
        }
    }

    // Calculate and display the total value of inventory
    public void CalculateTotalValue()
    {
        decimal totalValue = 0;
        Item temp = head;

        while (temp != null)
        {
            totalValue += temp.Price * temp.Quantity;
            temp = temp.Next;
        }

        Console.WriteLine($"Total value of inventory: {totalValue:C}");
    }

    // Sort the inventory based on Item Name (Ascending)
    public void SortByItemNameAscending()
    {
        if (head == null)
        {
            Console.WriteLine("No items to sort.");
            return;
        }

        bool swapped;
        do
        {
            swapped = false;
            Item temp = head;
            while (temp != null && temp.Next != null)
            {
                if (string.Compare(temp.ItemName, temp.Next.ItemName) > 0)
                {
                    // Swap the items
                    string tempName = temp.ItemName;
                    int tempID = temp.ItemID;
                    int tempQuantity = temp.Quantity;
                    decimal tempPrice = temp.Price;

                    temp.ItemName = temp.Next.ItemName;
                    temp.ItemID = temp.Next.ItemID;
                    temp.Quantity = temp.Next.Quantity;
                    temp.Price = temp.Next.Price;

                    temp.Next.ItemName = tempName;
                    temp.Next.ItemID = tempID;
                    temp.Next.Quantity = tempQuantity;
                    temp.Next.Price = tempPrice;

                    swapped = true;
                }
                temp = temp.Next;
            }
        } while (swapped);

        Console.WriteLine("Inventory sorted by Item Name in ascending order.");
    }

    // Sort the inventory based on Price (Ascending)
    public void SortByPriceAscending()
    {
        if (head == null)
        {
            Console.WriteLine("No items to sort.");
            return;
        }

        bool swapped;
        do
        {
            swapped = false;
            Item temp = head;
            while (temp != null && temp.Next != null)
            {
                if (temp.Price > temp.Next.Price)
                {
                    // Swap the items
                    string tempName = temp.ItemName;
                    int tempID = temp.ItemID;
                    int tempQuantity = temp.Quantity;
                    decimal tempPrice = temp.Price;

                    temp.ItemName = temp.Next.ItemName;
                    temp.ItemID = temp.Next.ItemID;
                    temp.Quantity = temp.Next.Quantity;
                    temp.Price = temp.Next.Price;

                    temp.Next.ItemName = tempName;
                    temp.Next.ItemID = tempID;
                    temp.Next.Quantity = tempQuantity;
                    temp.Next.Price = tempPrice;

                    swapped = true;
                }
                temp = temp.Next;
            }
        } while (swapped);

        Console.WriteLine("Inventory sorted by Price in ascending order.");
    }

    // Display all items in the inventory
    public void DisplayAllItems()
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        Item temp = head;
        while (temp != null)
        {
            Console.WriteLine($"ID: {temp.ItemID}, Name: {temp.ItemName}, Quantity: {temp.Quantity}, Price: {temp.Price:C}");
            temp = temp.Next;
        }
    }
}

public class Program
{
    public static void Main()
    {
        InventoryManagementSystem inventory = new InventoryManagementSystem();

        // Add items to inventory
        inventory.AddAtBeginning(101, "Laptop", 50, 799.99m);
        inventory.AddAtEnd(102, "Mouse", 150, 25.99m);
        inventory.AddAtEnd(103, "Keyboard", 120, 49.99m);
        inventory.AddAtBeginning(104, "Monitor", 30, 199.99m);

        // Display all items
        Console.WriteLine("Inventory:");
        inventory.DisplayAllItems();

        // Search for an item by ID or Name
        Console.WriteLine("\nSearch for 'Laptop':");
        inventory.SearchItem("Laptop");

        // Update quantity of an item
        Console.WriteLine("\nUpdating quantity of item with ID 102...");
        inventory.UpdateQuantity(102, 160);

        // Remove an item by Item ID
        Console.WriteLine("\nRemoving item with ID 103...");
        inventory.RemoveByItemID(103);

        // Display all items after removal
        Console.WriteLine("\nUpdated Inventory:");
        inventory.DisplayAllItems();

        // Calculate total inventory value
        Console.WriteLine("\nTotal Value of Inventory:");
        inventory.CalculateTotalValue();

        // Sort items by Item Name (ascending)
        Console.WriteLine("\nSorting inventory by Item Name (ascending):");
        inventory.SortByItemNameAscending();
        inventory.DisplayAllItems();

        // Sort items by Price (ascending)
        Console.WriteLine("\nSorting inventory by Price (ascending):");
        inventory.SortByPriceAscending();
        inventory.DisplayAllItems();
    }
}
