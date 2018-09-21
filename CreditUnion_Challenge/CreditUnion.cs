using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditUnion_Challenge
{
    public class CreditUnion
    {
        private List<Account> _accounts = new List<Account>();

        public List<Account> GetList() => _accounts;

        public void AddAccount(Account a) => _accounts.Add(a);
    }
    


    public abstract class Account
    {
        public string Owner { get; set; }

        public decimal Balance { get; set; }

        public virtual void Withdraw(decimal amt)
        {
            Balance -= amt;
        }

        public void Deposit(decimal amt)
        {
            Balance += amt;
        }

        public void Transfer(string name, decimal amt)
        {
            CreditUnion union = new CreditUnion();
            foreach(var a in union.GetList())
            {
                if(a.Owner == name)
                {
                    a.Balance += amt;
                }
            }
        }
    }

    public class CD : Account
    {

    }

    public abstract class MoneyMarket : Account
    {

    }

    public class Consumer : MoneyMarket
    {
        public override void Withdraw(decimal amt)
        {
            if (amt < 750)
            {
                base.Withdraw(amt);
            }
        }
    }

    public class Commercial : MoneyMarket
    {

    }
}
