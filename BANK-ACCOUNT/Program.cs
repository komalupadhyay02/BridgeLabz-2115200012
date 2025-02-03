using System;

// Base class: BankAccount
class BankAccount
{
    // Public member for account number
    public string AccountNumber { get; set; }

    // Protected member for account holder name
    protected string AccountHolder { get; set; }

    // Private member for balance
    private decimal Balance { get; set; }

    // Constructor to initialize bank account details
    public BankAccount(string accountNumber, string accountHolder, decimal balance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = balance;
    }

    // Public method to get the balance
    public decimal GetBalance()
    {
        return Balance;
    }

    // Public method to set or modify the balance
    public void SetBalance(decimal balance)
    {
        if (balance >= 0)
        {
            Balance = balance;
        }
        else
        {
            Console.WriteLine("Invalid balance. Balance cannot be negative.");
        }
    }

    // Public method to deposit money into the account
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount}. New balance: ${Balance}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be greater than 0.");
        }
    }

    // Public method to withdraw money from the account
    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew ${amount}. New balance: ${Balance}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount.");
        }
    }
}

// Subclass: SavingsAccount
class SavingsAccount : BankAccount
{
    // Constructor for SavingsAccount
    public SavingsAccount(string accountNumber, string accountHolder, decimal balance)
        : base(accountNumber, accountHolder, balance)
    {
    }

    // Method to display savings account details
    public void DisplaySavingsAccountDetails()
    {
        Console.WriteLine($"Account Number: {AccountNumber}"); // Accessing public member
        Console.WriteLine($"Account Holder: {AccountHolder}"); // Accessing protected member
        Console.WriteLine($"Balance: ${GetBalance()}"); // Accessing balance through public method
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a SavingsAccount instance
        SavingsAccount savingsAccount = new SavingsAccount("SA123456", "Alice Johnson", 1000.00m);

        // Display savings account details
        savingsAccount.DisplaySavingsAccountDetails();

        // Perform deposit and withdrawal operations
        savingsAccount.Deposit(500.00m);
        savingsAccount.Withdraw(200.00m);

        // Display updated savings account details
        Console.WriteLine("\nUpdated Savings Account Details:");
        savingsAccount.DisplaySavingsAccountDetails();
    }
}
