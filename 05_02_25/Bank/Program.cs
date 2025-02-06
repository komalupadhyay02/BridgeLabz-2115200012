using System;
using System.Collections.Generic;

class Bank
{
    public string Name { get; set; }
    private List<Customer> customers;

    public Bank(string name)
    {
        Name = name;
        customers = new List<Customer>();
    }

    public void OpenAccount(Customer customer, string accountNumber, double initialBalance)
    {
        BankAccount newAccount = new BankAccount(accountNumber, initialBalance, this);
        customer.AddAccount(newAccount);
        if (!customers.Contains(customer))
        {
            customers.Add(customer);
        }
        Console.WriteLine($"Account {accountNumber} opened for {customer.Name} at {Name}.");
    }
}

class Customer
{
    public string Name { get; set; }
    private List<BankAccount> accounts;

    public Customer(string name)
    {
        Name = name;
        accounts = new List<BankAccount>();
    }

    public void AddAccount(BankAccount account)
    {
        accounts.Add(account);
    }

    public void ViewBalance()
    {
        Console.WriteLine($"Balances for {Name}:");
        foreach (var account in accounts)
        {
            Console.WriteLine($"Account {account.AccountNumber} at {account.Bank.Name}: ${account.Balance}");
        }
    }
}

class BankAccount
{
    public string AccountNumber { get; set; }
    public double Balance { get; private set; }
    public Bank Bank { get; set; }

    public BankAccount(string accountNumber, double initialBalance, Bank bank)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        Bank = bank;
    }
}

class Program
{
    static void Main()
    {
        Bank bank = new Bank("ABC Bank");
        Customer customer = new Customer("John Doe");
        
        bank.OpenAccount(customer, "123456", 500.0);
        bank.OpenAccount(customer, "789012", 1000.0);
        
        customer.ViewBalance();
    }
}