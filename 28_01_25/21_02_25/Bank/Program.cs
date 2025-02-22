using System;

class InsufficientFund : Exception
{
    public double Amount { get; }

    public InsufficientFund(string message, double amount) : base(message)
    {
        Amount = amount;
    }
}

class Bank
{
    private double balance; // Instance field for balance

    public Bank(double initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(double amount) 
    {
        if (amount > 0)
        {
            balance += amount;
        }
    }

    public void Withdraw(double amount) 
    {
        if (amount > balance)
        {
            throw new InsufficientFund("Insufficient funds for withdrawal", amount - balance);
        }

        balance -= amount;
    }

    public double GetBalance()
    {
        return balance;
    }

    static void Main()
    {
        Bank account = new Bank(100); 
        try
        {
            Console.WriteLine("Depositing $50...");
            account.Deposit(50); 
            Console.WriteLine("New balance: $" + account.GetBalance());

            Console.WriteLine("Withdrawing $200...");
            account.Withdraw(200); 
        }
        catch (InsufficientFund e)
        {
            Console.WriteLine($"Exception: {e.Message}");
            Console.WriteLine($"Shortfall: ${e.Amount}");
        }
    }
}
