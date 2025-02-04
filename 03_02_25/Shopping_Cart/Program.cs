using System;
using System.Collections.Generic;

class Product
{
    // Static variable shared among all products
    private static double Discount = 5.0; // Default discount in percentage
    private static int ProductCount = 0; // Auto-increment Product ID

    public string ProductName { get; private set; }
    public double Price { get; private set; }
    public int Quantity { get; set; }
    public readonly int ProductID; // Unique and cannot be changed

    // Constructor using 'this' to initialize variables
    public Product(string productName, double price, int quantity)
    {
        this.ProductName = productName;
        this.Price = price;
        this.Quantity = quantity;
        this.ProductID = ++ProductCount; // Assigns a unique ID
    }

    // Static method to update discount
    public static void UpdateDiscount(double newDiscount)
    {
        Discount = newDiscount;
        Console.WriteLine($"Discount updated to {Discount:F2}%.\n");
    }

    // Method to display product details
    public void DisplayProduct()
    {
        double discountedPrice = Price - (Price * Discount / 100);
        Console.WriteLine($"Product ID: {ProductID}, Name: {ProductName}, Price: ${Price:F2}, Discounted Price: ${discountedPrice:F2}, Quantity: {Quantity}");
    }
}

class ShoppingCart
{
    private static List<Product> cart = new List<Product>();

    // Method to add a product to the cart
    public static void AddProduct()
    {
        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Product Price: ");
        if (double.TryParse(Console.ReadLine(), out double price))
        {
            Console.Write("Enter Product Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity))
            {
                Product newProduct = new Product(name, price, quantity);
                cart.Add(newProduct);
                Console.WriteLine("Product Added to Cart!\n");
            }
            else
            {
                Console.WriteLine("Invalid quantity! Please enter a numeric value.\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid price! Please enter a numeric value.\n");
        }
    }

    // Method to display all products in the cart
    public static void DisplayCart()
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Your shopping cart is empty.\n");
            return;
        }

        Console.WriteLine("\n==== Shopping Cart ====");
        foreach (var product in cart)
        {
            product.DisplayProduct();
        }
        Console.WriteLine();
    }

    // Method to search for a product by Product ID
    public static void SearchProduct()
    {
        Console.Write("Enter Product ID to search: ");
        if (int.TryParse(Console.ReadLine(), out int searchID))
        {
            Product foundProduct = cart.Find(p => p.ProductID == searchID);
            if (foundProduct is Product)
            {
                Console.WriteLine("\nProduct Found:");
                foundProduct.DisplayProduct();
            }
            else
            {
                Console.WriteLine("Product Not Found.\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Product ID.\n");
        }
    }

    // Method to update the discount percentage
    public static void SetDiscount()
    {
        Console.Write("Enter new discount percentage: ");
        if (double.TryParse(Console.ReadLine(), out double newDiscount))
        {
            Product.UpdateDiscount(newDiscount);
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a numeric discount value.\n");
        }
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("==== Shopping Cart System ====");
            Console.WriteLine("1. Add Product to Cart");
            Console.WriteLine("2. Display All Products in Cart");
            Console.WriteLine("3. Search Product by ID");
            Console.WriteLine("4. Update Discount Percentage");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    DisplayCart();
                    break;
                case "3":
                    SearchProduct();
                    break;
                case "4":
                    SetDiscount();
                    break;
                case "5":
                    Console.WriteLine("Thank you! Exiting the Shopping Cart System.");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.\n");
                    break;
            }
        }
    }
}
