using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    internal class BillingAccount : Account
    {
        public BillingAccount(int id, decimal balance, string firstName, string lastName, long pesel) 
            : base(id, balance, firstName, lastName, pesel) { }

        public override string TypeName()
        {
            return "ROZLICZENIOWE";
        }

        public void TakeCharge(decimal value)
        {
            Balance -= value;
        }
    }
}
