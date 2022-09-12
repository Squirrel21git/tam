using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    internal class AccountsManager
    {
        private IList<Account> _accounts;

        public AccountsManager()
        {
            _accounts = new List<Account>();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }

        private int GenerateId()
        {
            return _accounts.Any() ? _accounts.Max(a => a.Id) + 1 : 1;
        }

        public SavingsAccount CreateSavingsAccount(string firstName, string lastName, long pesel)
        {
            var account = new SavingsAccount(GenerateId(), 0.0M, firstName, lastName, pesel);
            _accounts.Add(account);

            return account;
        }

        public BillingAccount CreateBillingAccount(string firstName, string lastName, long pesel)
        {
            var account = new BillingAccount(GenerateId(), 0.0M, firstName, lastName, pesel);
            _accounts.Add(account);

            return account;
        }

        public IEnumerable<Account> GetAccountsByPesel(long pesel)
        {
            //return from a in _accounts where a.Pesel == pesel select a;
            return _accounts.Where(a => a.Pesel == pesel);
        }

        public Account GetAccount(string accountNumber)
        {
            //return from a in _accounts where a.Pesel == pesel select a;
            return _accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
        }

        public IEnumerable<string> ListOfCustomers()
        {
            return _accounts.Select(a => String.Format("Imię: {0} | Nazwisko: {1} | PESEL: {2}", a.FirstName, a.LastName, a.Pesel)).Distinct();
        }

        public void CloseMonth()
        {
            foreach (var account in _accounts)
                if (account is SavingsAccount)
                    ((SavingsAccount)account).AddInterest(0.04M);
                else
                    ((BillingAccount)account).TakeCharge(5);
        }

        public void AddMoney(string accountNumber, decimal value)
        {
            GetAccount(accountNumber).ChangeBalance(value);
        }

        public void TakeMoney(string accountNumber, decimal value)
        {
            GetAccount(accountNumber).ChangeBalance(-value);
        }
    }
}
