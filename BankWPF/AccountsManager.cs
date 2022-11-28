using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF
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
            int id = 1;
            if (_accounts.Any())
            {
                id = _accounts.Max(a => a.Id) + 1;
            }
            return id;
        }
        public SavingAccount CreateSavingsAccount(string firstName, string lastName, long pesel)
        {
            int id = GenerateId();
            SavingAccount account = new(id, 0.0M, firstName, lastName, pesel);
            _accounts.Add(account);
            return account;
        }
        public BillingAccount CreateBillingsAccount(string firstName, string lastName, long pesel)
        {
            int id = GenerateId();
            BillingAccount account = new(id, 0.0M, firstName, lastName, pesel);
            _accounts.Add(account);
            return account;
        }
        public IEnumerable<Account> GetAllAccountFor(long pesel)
        {
            //IList<Account> customers = new List<Account>();
            //foreach(Account account in _accounts)
            //    if(account.Pesel == pesel)
            //        customers.Add(account);
            //return customers;
            return _accounts.Where(a => a.Pesel == pesel);
        }
        public Account GetAccount(string accountNo)
        {
            return _accounts.Single(x => x.AccountNumber == accountNo);
        }
        public IEnumerable<string> ListOfCustomers()
        {
            return _accounts.Select(a => string.Format("Imię: {0} | Nazwisko: {1} | Pesel: {2}", a.FirstName, a.LastName, a.Pesel)).Distinct();
        }
        public void CloseMonth()
        {
            foreach (SavingAccount account in _accounts.Where(x => x is SavingAccount))
                account.AddInterest(0.04M);
            foreach (BillingAccount account in _accounts.Where(x => x is BillingAccount))
                account.TakeCharge(5.0M);
        }
        public void AddMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(value);
        }
        public void TakeMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(-value);
        }
    }
}
