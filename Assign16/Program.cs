using System;

public class BankAccount
{
    private static int nextAccountNumber = 1;

    // Properties
    public int AccountNumber { get; }
    public string AccountHolderName { get; set; }
    private decimal Balance { get; set; }

   
    public BankAccount(string accountHolderName)
    {
        AccountNumber = nextAccountNumber++;
        AccountHolderName = accountHolderName;
        Balance = 0;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
            Balance += amount;
        else
            Console.WriteLine("Invalid deposit amount. Amount should be greater than zero.");
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0)
        {
            if (Balance >= amount)
                Balance -= amount;
            else
                Console.WriteLine("Insufficient funds.");
        }
        else
            Console.WriteLine("Invalid withdrawal amount. Amount should be greater than zero.");
    }

  
    public void DisplayBalance()
    {
        Console.WriteLine($"Account Number: {AccountNumber}, Account Holder: {AccountHolderName}, Balance: {Balance}");
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Enter Account Holder Name: ");
        string accountHolderName = Console.ReadLine();
        BankAccount account = new BankAccount(accountHolderName);

        char choice;
        do
        {
          
            account.DisplayBalance();
            Console.Write("Enter the amount to be deposited: ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            account.Deposit(depositAmount);
            account.DisplayBalance();
            Console.Write("Enter the amount to be withdrawn: ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
            account.Withdraw(withdrawAmount);
            account.DisplayBalance();
            Console.Write("Do you want to continue? (Y/N): ");
            choice = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
        } while (choice == 'Y');
        Console.ReadKey();
    }
}

