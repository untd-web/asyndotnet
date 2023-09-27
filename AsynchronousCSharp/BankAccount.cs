using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousCSharp
{
    class BankAccount
    {
        private Object acctLock = new object();
        double Balance { get; set; }
        string Name { get; set; }

        public BankAccount(double balance)
        {
            Balance = balance;
        }
        public double Withdraw(double amt)
        {
            if (Balance - amt < 0)
            {
                Console.WriteLine($"Sorry {Balance} in account");
                return Balance;
            }
            lock (acctLock)
            {
                if (Balance >= amt)
                {
                    Console.WriteLine($"Removed {amt} and remaining amount in the account is {Balance-amt}");
                    Balance -= amt;
                }
                return Balance;
            }
        }
        public void IssueWithdraw()
        {
            Withdraw(1);
        }
    }
}
