using System;
using System.Collections.Generic;

// Abstract class BankAccount
abstract class BankAccount
{
    protected string accountNumber;
    protected string holderName;
    protected double balance;

    public string AccountNumber { get => accountNumber; set => accountNumber = value; }
    public string HolderName { get => holderName; set => holderName = value; }
    public double Balance { get => balance; protected set => balance = value; }

    public BankAccount(string accountNumber, string holderName, double balance)
    {
        this.accountNumber = accountNumber;
        this.holderName = holderName;
        this.balance = balance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount:C} into {accountNumber}. New Balance: {balance:C}");
        }
    }

    public virtual void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrew {amount:C} from {accountNumber}. Remaining Balance: {balance:C}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public abstract double CalculateInterest();
}

// Interface ILoanable
interface ILoanable
{
    bool ApplyForLoan(double amount);
    double CalculateLoanEligibility();
}

// SavingsAccount subclass
class SavingsAccount : BankAccount
{
    private double interestRate = 0.04;

    public SavingsAccount(string accountNumber, string holderName, double balance)
        : base(accountNumber, holderName, balance) { }

    public override double CalculateInterest()
    {
        return balance * interestRate;
    }
}

// CurrentAccount subclass
class CurrentAccount : BankAccount, ILoanable
{
    private double overdraftLimit = 5000;

    public CurrentAccount(string accountNumber, string holderName, double balance)
        : base(accountNumber, holderName, balance) { }

    public override double CalculateInterest()
    {
        return 0; // No interest for current accounts
    }

    public bool ApplyForLoan(double amount)
    {
        return amount <= overdraftLimit;
    }

    public double CalculateLoanEligibility()
    {
        return overdraftLimit * 0.5;
    }
}

// Main program
class Program
{
    static void ProcessAccounts(List<BankAccount> accounts)
    {
        foreach (var account in accounts)
        {
            Console.WriteLine($"Account: {account.AccountNumber}, Holder: {account.HolderName}, Balance: {account.Balance:C}, Interest: {account.CalculateInterest():C}");
        }
    }

    static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>
        {
            new SavingsAccount("SA123", "Alice", 10000),
            new CurrentAccount("CA456", "Bob", 5000)
        };

        ProcessAccounts(accounts);
    }
}
