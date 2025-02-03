using System;

class Product
{
    // Class variable to store the total number of products created
    public static int TotalProducts = 0;

    // Instance variables
    public string ProductName { get; set; }
    public decimal Price { get; set; }

    // Constructor to initialize product details
    public Product(string productName, decimal price)
    {
        ProductName = productName;
        Price = price;
        // Increment the totalProducts whenever a new product is created
        TotalProducts++;
    }

    // Instance method to display the details of a product
    public void DisplayProductDetails()
    {
        Console.WriteLine($"Product Name: {ProductName}");
        Console.WriteLine($"Price: ${Price}");
    }

    // Class method to display the total number of products created
    public static void DisplayTotalProducts()
    {
        Console.WriteLine($"Total Products Created: {TotalProducts}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example Usage
        Product product1 = new Product("Laptop", 999.99m);
        product1.DisplayProductDetails();

        Product product2 = new Product("Smartphone", 699.99m);
        product2.DisplayProductDetails();

        // Display total number of products created
        Product.DisplayTotalProducts();
    }
}
