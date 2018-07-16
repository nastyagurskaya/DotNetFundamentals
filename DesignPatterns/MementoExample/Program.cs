using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc = new BankAccount(100);
            acc.AddMoney(15);
            TransactionHistory history = new TransactionHistory();

            history.History.Push(acc.SaveState());

            acc.WithdrawMoney(10);

            acc.RestoreState(history.History.Pop());

            acc.WithdrawMoney(20); 

            Console.Read();
        }
    }
    class BankAccount
    {
        private int sum = 10;
        public BankAccount(int sum)
        {
            this.sum = sum;
        }
        public void AddMoney(int amount)
        {
            sum += amount;
            Console.WriteLine("Added {0}. Sum: {1}", amount, sum);
        }
        public void WithdrawMoney(int amount)
        {
            if (sum >= amount)
            {
                sum-= amount;
                Console.WriteLine("{0} was withdrawn. Left: {1}", amount, sum);
            }
            else
                Console.WriteLine("You have not enough money to continue this transaction.");
        }
        public AccountMemento SaveState()
        {
            Console.WriteLine("Saved account state.");
            return new AccountMemento(sum);
        }
        public void RestoreState(AccountMemento memento)
        {
            this.sum = memento.Sum;
            Console.WriteLine("Transaction was canselled. Sum: {0}", sum);
        }
    }
    // Memento
    class AccountMemento
    {
        public int Sum { get; private set; }

        public AccountMemento(int sum)
        {
            this.Sum = sum;
        }
    }
    class TransactionHistory
    {
        public Stack<AccountMemento> History { get; private set; }
        public TransactionHistory()
        {
            History = new Stack<AccountMemento>();
        }
    }
}
