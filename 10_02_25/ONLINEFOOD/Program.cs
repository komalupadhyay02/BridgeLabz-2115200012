using System;
using System.Collections.Generic;

// Abstract class FoodItem
abstract class FoodItem
{
    protected string itemName;
    protected double price;
    protected int quantity;

    public string ItemName { get => itemName; set => itemName = value; }
    public double Price { get => price; set => price = value; }
    public int Quantity { get => quantity; set => quantity = value; }

    public FoodItem(string itemName, double price, int quantity)
    {
        this.itemName = itemName;
        this.price = price;
        this.quantity = quantity;
    }

    public abstract double CalculateTotalPrice();

    public virtual void GetItemDetails()
    {
        Console.WriteLine($"Item: {itemName}, Price: {price:C}, Quantity: {quantity}");
    }
}

// Interface IDiscountable
interface IDiscountable
{
    double ApplyDiscount();
    string GetDiscountDetails();
}

// VegItem subclass
class VegItem : FoodItem, IDiscountable
{
    private double discountRate = 0.1; // 10% discount

    public VegItem(string itemName, double price, int quantity)
        : base(itemName, price, quantity) { }

    public override double CalculateTotalPrice()
    {
        return (price * quantity) - ApplyDiscount();
    }

    public double ApplyDiscount()
    {
        return price * quantity * discountRate;
    }

    public string GetDiscountDetails()
    {
        return "VegItem Discount: 10% off total price";
    }
}

// NonVegItem subclass
class NonVegItem : FoodItem, IDiscountable
{
    private double additionalCharge = 1.2; // 20% additional charge

    public NonVegItem(string itemName, double price, int quantity)
        : base(itemName, price, quantity) { }

    public override double CalculateTotalPrice()
    {
        return (price * quantity * additionalCharge) - ApplyDiscount();
    }

    public double ApplyDiscount()
    {
        return price * quantity * 0.05; // 5% discount
    }

    public string GetDiscountDetails()
    {
        return "NonVegItem Discount: 5% off total price, but 20% additional charge applies";
    }
}

// Main program
class Program
{
    static void ProcessFoodItems(List<FoodItem> foodItems)
    {
        foreach (var item in foodItems)
        {
            item.GetItemDetails();
            Console.WriteLine($"Total Price: {item.CalculateTotalPrice():C}");
        }
    }

    static void Main()
    {
        List<FoodItem> foodItems = new List<FoodItem>
        {
            new VegItem("Salad", 5.99, 2),
            new NonVegItem("Chicken Burger", 8.99, 1)
        };

        ProcessFoodItems(foodItems);
    }
}
