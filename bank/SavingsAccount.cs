using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    internal class SavingsAccount : Account
    {
        public SavingsAccount(int id, decimal balance, string firstName, string lastName, long pesel) 
            : base(id, balance, firstName, lastName, pesel) { }

        public override string TypeName()
        {
            return "OSZCZĘDNOŚCIOWE";
        }

        public void AddInterest(decimal interest)
        {
            Balance += Balance * interest;
        }
    }
}
