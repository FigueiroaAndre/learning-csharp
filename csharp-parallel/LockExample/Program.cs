using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace LockExample
{
    public class BankSystem
    {
        private List<BankAccount> _accounts = new List<BankAccount>();

        public void Register(string name, decimal initialBalance = 0)
        {
            var account = new BankAccount(name,_accounts.ToArray().Length,initialBalance);
            _accounts.Add(account);
        }

        public void ListAll()
        {
            foreach (var account in _accounts)
            {
                Info(account.Id);
            }
        }

        public void Info(int id)
        {
            var account = _accounts.Where(a => a.Id == id).Single();
            System.Console.WriteLine($"Account ID: {account.Id}\t\t - Name: {account.Name}\t\t - Balance: {account.Balance}");
        }

        public void Deposit(int id, decimal amount)
        {
            var account = _accounts.Where(a => a.Id == id).Single();
            lock(account)
            {
                account.Deposit(amount);
            }
        }

        public void Withdraw(int id, decimal amount)
        {
            var account = _accounts.Where(a => a.Id == id).Single();
            lock(account)
            {
                account.Withdraw(amount);
            }
        }

        public void Transfer(int sourceAccountId, int targetAccountId, decimal amount)
        {
            var sourceAccount = _accounts.Where(a => a.Id == sourceAccountId).Single();
            var targetAccount = _accounts.Where(a => a.Id == targetAccountId).Single();
            lock(sourceAccount)
            {
                lock(targetAccount)
                {
                    sourceAccount.Transfer(targetAccount,amount);
                }
            }
        }
    }

    public class BankAccount
    {
        public int Id { get; private set; }
        public decimal Balance { get; private set; }
        public string Name {get; private set; }

        public BankAccount(string name, int id, decimal initialBalance = 0)
        {
            this.Name = name;
            this.Balance = initialBalance;
            this.Id = id;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        public void Transfer(BankAccount targetAccount, decimal amount)
        {
            Balance -= amount;
            targetAccount.Deposit(amount);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var system = new BankSystem();
            system.Register("Andre",0M);
            system.Register("John",0M);
            system.Register("Carl",0M);
            
            var task1 = new Task(() => {
                for(int i = 0; i < 1000; i++)
                {
                    system.Deposit(1,100);
                }
            });
            var task2 = new Task(() => {
                for(int i = 0; i < 1000; i++)
                {
                    system.Withdraw(1,50);
                }
            });
            task1.Start();
            task2.Start();
            Task.WaitAll(task1,task2);
            system.Info(1); //should display 100*1000 0 50*1000 = 50000

        }
    }
}
