using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_20._02._2024
{
    internal class Program
    {
        public abstract class Account
        {
            public string AccountNumber { get; set; }
            public string HolderName { get; set; }
            public decimal Balance { get; set; }
            public Account(string accountNumber, string holderName, decimal balance)
            {
                AccountNumber = accountNumber;
                HolderName = holderName;
                Balance = balance;
            }
            public virtual void Withdraw(decimal amount)
            {
                if (amount > Balance)
                {
                    Console.WriteLine("Недостатньо коштів!");
                }
                else
                {
                    Balance -= amount;
                    Console.WriteLine($"Зняття {amount} успішно. Новий баланс: {Balance}");
                }
            }
            public void Deposit(decimal amount)
            {
                Balance += amount;
                Console.WriteLine($"Депозит на суму {amount} успішно внесено. Новий баланс: {Balance}");
            }
        }
        public class SavingsAccount : Account
        {
            public double InterestRate { get; set; }
            public SavingsAccount(string accountNumber, string holderName, decimal balance, double interestRate)
                : base(accountNumber, holderName, balance)
            {
                InterestRate = interestRate;
            }
            public void CalculateInterest()
            {
                decimal interest = (decimal)(Balance * (decimal)InterestRate);
                Deposit(interest);
                Console.WriteLine($"Відсотки нараховані та нараховані на рахунок. Новий баланс: {Balance}");
            }
        }
        public class CheckingAccount : Account
        {
            public decimal OverdraftLimit { get; set; }
            public CheckingAccount(string accountNumber, string holderName, decimal balance, decimal overdraftLimit)
                : base(accountNumber, holderName, balance)
            {
                OverdraftLimit = overdraftLimit;
            }
            public override void Withdraw(decimal amount)
            {
                if (amount > Balance + OverdraftLimit)
                {
                    Console.WriteLine("Трансакцію відхилено: перевищено ліміт овердрафту.");
                }
                else
                {
                    Balance -= amount;
                    Console.WriteLine($"Зняття {amount} успішно. Новий баланс: {Balance}");
                }
            }
        }
        public class Bank
        {
            private List<Account> accounts;
            public Bank()
            {
                accounts = new List<Account>();
            }
            public void AddAccount(Account account)
            {
                accounts.Add(account);
            }
            public void PrintAccounts()
            {
                foreach (var account in accounts)
                {
                    Console.WriteLine($"Номер рахунку: {account.AccountNumber}, Ім’я власника: {account.HolderName}, Баланс: {account.Balance}");
                }
            }
            public Account FindAccount(string accountNumber)
            {
                return accounts.Find(acc => acc.AccountNumber == accountNumber);
            }
            public void WithdrawFromAccount(string accountNumber, decimal amount)
            {
                Account account = FindAccount(accountNumber);
                if (account != null)
                {
                    account.Withdraw(amount);
                }
                else
                {
                    Console.WriteLine("Обліковий запис не знайдено.");
                }
            }
            public void DepositToAccount(string accountNumber, decimal amount)
            {
                Account account = FindAccount(accountNumber);
                if (account != null)
                {
                    account.Deposit(amount);
                }
                else
                {
                    Console.WriteLine("Обліковий запис не знайдено.");
                }
            }
        }
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            SavingsAccount savingsAccount = new SavingsAccount("BOM001", "Киирило Кравець", 10000, 0.05);
            CheckingAccount checkingAccount = new CheckingAccount("A001", "Максим Максимович", 50000, 2001);
            bank.AddAccount(savingsAccount);
            bank.AddAccount(checkingAccount);
            Console.WriteLine("Усі облікові записи:");
            bank.PrintAccounts();
            Console.WriteLine();
            bank.WithdrawFromAccount("BOM001", 100);
            bank.DepositToAccount("A001", 300);
            savingsAccount.CalculateInterest();
        }
    }
}
