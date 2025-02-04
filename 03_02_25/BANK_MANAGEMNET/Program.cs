using System;
class BankManagement{
    public static string bankName="SBI";
    public readonly int accountNumber;
    public string accountHolderName{get;private set;}
    public double balance{get;private set;}
    public static int accountCount=10000;
    public BankManagement(string accountHolderName,double InitialBalance){
        this.accountNumber=accountCount++;
        this.accountHolderName=accountHolderName;
        this.balance=InitialBalance;
    }
    public void deposite(double amount){
        if(amount>0){
            balance+=amount;
            Console.WriteLine($"Deposited {amount} into AccountNumber: {accountNumber} new balance is {balance}");
        }
        else 
            Console.WriteLine("invalid deposite amount");
    }
    public void Withdraw(double amount){
        if(amount>0 && amount<=balance){
            balance-=amount;
            Console.WriteLine($"Withdraw amount {amount} from Account {accountNumber} current balance is {balance}");
        }
        else    
            Console.WriteLine("Invalid withdraw amount or insufficient balance");
    }
    public void DisplayAccountDetails(){
        Console.WriteLine($"Bank: {bankName}, Account No: {accountNumber}, Holder: {accountHolderName}, Balance: {balance:C}");
    }
    public static void GetTotalAccount(){
        Console.WriteLine($"TotalAccount:{accountCount-10000}");
    }
class Bank{
    private static List<BankManagement> accounts=new List<BankManagement>();
    public static void createAccount(){
        Console.Write("Enter Account Holder Name:");
        string name=Console.ReadLine();
        Console.Write("Enter INITIAL DEPOSIT:");
        if(double.TryParse(Console.ReadLine(),out double initialDeposit)&& initialDeposit>=0){
            BankManagement newAccount=new BankManagement(name,initialDeposit);
            accounts.Add(newAccount);
            Console.WriteLine($"Account Created Successfully! Account Number: {newAccount.accountNumber}\n");
        }
        else
            Console.WriteLine("Invalid deposit amount. Account creation failed.\n");
        }
        public static void DiaplayAllAccounts(){
            if(accounts.Count==0){
                Console.WriteLine("No bank accounts available.\n");
            return;
            }
            Console.WriteLine("<<<--------BANK ACCOUNTS----------->>>");
            foreach(var acc in accounts){
                acc.DisplayAccountDetails();

            }
            Console.WriteLine();
        }
        public static void searchAccount(){
                 Console.Write("Enter Account Number to Search: ");
        if (int.TryParse(Console.ReadLine(), out int searchAccNum))
        {
            BankManagement foundAccount = accounts.Find(acc => acc.accountNumber == searchAccNum);

            if (foundAccount is BankManagement)
            {
                Console.WriteLine("\nAccount Found:");
                foundAccount.DisplayAccountDetails();
            }
            else
            {
                Console.WriteLine("Account Not Found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Account Number.");
        }
        Console.WriteLine();
    }
        public static void DepositToAccount()
    {
        Console.Write("Enter Account Number: ");
        if (int.TryParse(Console.ReadLine(), out int accNum))
        {
            BankManagement foundAccount = accounts.Find(acc => acc.accountNumber == accNum);
            if (foundAccount is BankManagement)
            {
                Console.Write("Enter Amount to Deposit: ");
                if (double.TryParse(Console.ReadLine(), out double amount))
                {
                    foundAccount.deposite(amount);
                }
                else
                {
                    Console.WriteLine("Invalid amount.");
                }
            }
            else
            {
                Console.WriteLine("Account Not Found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Account Number.");
        }
        Console.WriteLine();
    }

    // Withdraw from an account
    public static void WithdrawFromAccount()
    {
        Console.Write("Enter Account Number: ");
        if (int.TryParse(Console.ReadLine(), out int accNum))
        {
            BankManagement foundAccount = accounts.Find(acc => acc.accountNumber == accNum);
            if (foundAccount is BankManagement)
            {
                Console.Write("Enter Amount to Withdraw: ");
                if (double.TryParse(Console.ReadLine(), out double amount))
                {
                    foundAccount.Withdraw(amount);
                }
                else
                {
                    Console.WriteLine("Invalid amount.");
                }
            }
            else
            {
                Console.WriteLine("Account Not Found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Account Number.");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("==== Bank Account Management System ====");
            Console.WriteLine("1. Create New Account");
            Console.WriteLine("2. Display All Accounts");
            Console.WriteLine("3. Search Account by Account Number");
            Console.WriteLine("4. Deposit Money");
            Console.WriteLine("5. Withdraw Money");
            Console.WriteLine("6. Display Total Accounts");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    createAccount();
                    break;
                case "2":
                    DiaplayAllAccounts();
                    break;
                case "3":
                    searchAccount();
                    break;
                case "4":
                    DepositToAccount();
                    break;
                case "5":
                    WithdrawFromAccount();
                    break;
                case "6":
                    BankManagement.GetTotalAccount();
                    break;
                case "7": 
                    Console.WriteLine("Exiting Bank Account System...");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.\n");
                    break;
            }
        }
    }
        }
        }
