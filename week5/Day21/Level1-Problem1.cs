using System;

namespace BankApp
{
    public class BankAccount
    {
        private string _accountNumber;
        private decimal _balance;

        public string AccountNumber
        {
            get { return _accountNumber; }
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        public BankAccount(string accountNumber, decimal initialBalance = 0)
        {
            _accountNumber = accountNumber;
            if (initialBalance < 0) _balance = 0;
            else _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }
            _balance += amount;
            Console.WriteLine($"Successfully deposited {amount}. Updated Balance: {_balance}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }
            if (amount > _balance)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }
            _balance -= amount;
            Console.WriteLine($"Successfully withdrew {amount}. Updated Balance: {_balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("ACC1001", 0);
            account.Deposit(5000);
            account.Withdraw(2000);
            Console.WriteLine("----------------------------");
            Console.WriteLine("Current Balance = " + account.Balance);
            Console.ReadLine();
        }
    }
}