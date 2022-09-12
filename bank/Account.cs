using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    abstract class Account
    {
        public int Id { get; }
        public string AccountNumber { get; }
        public decimal Balance { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public long Pesel { get; }

        public Account(int id, decimal balance, string firstName, string lastName, long pesel)
        {
            Id = id;
            AccountNumber = generateAccountNumber(id);
            Balance = balance;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
        }


        public string ConcatName()
        {
            return FirstName + " " + LastName;
        }

        private string generateAccountNumber(int id)
        {
            return string.Format("94{0:D10}", id);
        }

        public void ChangeBalance(decimal value)
        {
            Balance += value;
        }

        abstract public string TypeName();

    }
}
