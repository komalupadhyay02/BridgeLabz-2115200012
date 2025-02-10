using System;
using System.Collections.Generic;

// Abstract class Product
abstract class Product
{
    protected int productId;
    protected string name;
    protected double price;

    public int ProductId { get => productId; set => productId = value; }
    public string Name { get => name; set => name = value; }
    public double Price { get => price; set => price = value; }

    public Product(int id, string name, double price)
    {
        this.productId = id;
        this.name = name;
        this.price = price;
    }

    public abstract double CalculateDiscount();

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"ID: {productId}, Name: {name}, Price: {price:C}, Discount: {CalculateDiscount():C}");
    }
}

// Interface ITaxable
interface ITaxable
{
    double CalculateTax();
    string GetTaxDetails();
}

// Electronics subclass
class Electronics : Product, ITaxable
{
    public Electronics(int id, string name, double price)
        : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return price * 0.1; // 10% discount on electronics
    }

    public double CalculateTax()
    {
        return price * 0.15; // 15% tax
    }

    public string GetTaxDetails()
    {
        return "15% Electronics Tax";
    }
}

// Clothing subclass
class Clothing : Product
{
    public Clothing(int id, string name, double price)
        : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return price * 0.2; // 20% discount on clothing
    }
}

// Groceries subclass
class Groceries : Product
{
    public Groceries(int id, string name, double price)
        : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return price * 0.05; // 5% discount on groceries
    }
}

// Main program
class Program
{
    static void CalculateFinalPrice(Product product)
    {
        double discount = product.CalculateDiscount();
        double tax = product is ITaxable taxableProduct ? taxableProduct.CalculateTax() : 0;
        double finalPrice = product.Price + tax - discount;

        Console.WriteLine($"Final Price of {product.Name}: {finalPrice:C}");
    }

    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Electronics(1, "Laptop", 1000),
            new Clothing(2, "T-Shirt", 50),
            new Groceries(3, "Apples", 10)
        };

        foreach (var product in products)
        {
            product.DisplayDetails();
            CalculateFinalPrice(product);
        }
    }
}
