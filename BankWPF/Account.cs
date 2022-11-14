using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF
{
    abstract class Account
    {
        public int Id { get; }
        public string AccountNumber { get; }
        public decimal Balance { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName { get; set; }
        public string Type { get; set; }
        public long Pesel { get; }
        public Account(int id, decimal balance, string firstName, string lastName, long pesel)
        {
            Id = id;
            AccountNumber = GenerateAccoutNumber(id);
            Balance = balance;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Type = TypeName();
            FullName = GetFullName();
        }
        public abstract string TypeName();
        public string GetFullName()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
        public static string GenerateAccoutNumber(int id)
        {
            var accountNumber = string.Format("94{0:D10}", id);
            return accountNumber;
        }
        public void AddInterest(decimal interest)
        {
            Balance += Balance * interest;
        }
        public void TakeCharge(decimal value)
        {
            Balance -= value;
        }
        public void ChangeBalance(decimal value)
        {
            Balance += value;
        }
    }
}
