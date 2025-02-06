using System;
using System.Collections.Generic;

class ECommercePlatform
{
    public string Name { get; set; }
    private List<Customer> customers;
    private List<Product> products;

    public ECommercePlatform(string name)
    {
        Name = name;
        customers = new List<Customer>();
        products = new List<Product>();
    }

    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);
        Console.WriteLine($"Customer {customer.Name} registered on {Name}.");
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
        Console.WriteLine($"Product {product.Name} added to {Name}.");
    }
}

class Customer
{
    public string Name { get; set; }
    private List<Order> orders;

    public Customer(string name)
    {
        Name = name;
        orders = new List<Order>();
    }

    public void PlaceOrder(Order order)
    {
        orders.Add(order);
        Console.WriteLine($"Customer {Name} placed an order with ID {order.OrderId}.");
    }
}

class Order
{
    public int OrderId { get; set; }
    private List<Product> products;

    public Order(int orderId)
    {
        OrderId = orderId;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
        Console.WriteLine($"Product {product.Name} added to Order {OrderId}.");
    }
}

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    
    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

class Program
{
    static void Main()
    {
        ECommercePlatform platform = new ECommercePlatform("ShopEasy");
        
        Customer alice = new Customer("Alice");
        Customer bob = new Customer("Bob");
        
        platform.AddCustomer(alice);
        platform.AddCustomer(bob);
        
        Product laptop = new Product("Laptop", 1200.99);
        Product phone = new Product("Smartphone", 699.49);
        
        platform.AddProduct(laptop);
        platform.AddProduct(phone);
        
        Order order1 = new Order(1);
        order1.AddProduct(laptop);
        order1.AddProduct(phone);
        
        alice.PlaceOrder(order1);
    }
}
