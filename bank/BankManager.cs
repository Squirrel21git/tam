using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    internal class BankManager
    {
        private AccountsManager _accountsManager;
        private IPrinter _printer;

        public BankManager()
        {
            _accountsManager = new AccountsManager();
            _printer = new Printer();
        }

        private void PrintMainMenu()
        {
            Console.Clear();

            Console.WriteLine("Wybierz akcję:\n" +
                            "1 - list kont klienta\n" +
                            "2 - dodaj konto rozliczeniowe\n" +
                            "3 - dodaj konto oszczędnościowe\n" +
                            "4 - wpłać pieniądze na konto\n" +
                            "5 - wypłać pieniądze z konta\n" +
                            "6 - lista klientów\n" +
                            "7 - wszystkie konta\n" +
                            "8 - zakończ miesiąc\n" +
                            "0 - zakończ\n");
        }

        private int SelectedAction()
        {
            Console.Write("Akcja: ");
            string action = Console.ReadLine();

            if (string.IsNullOrEmpty(action))
                return -1;

            return int.Parse(action);
        }

        public void Run()
        {

            int action;

            do
            {
                PrintMainMenu();
                action = SelectedAction();

                switch (action)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Wybrano listę kont klienta");
                        ListOfAccounts();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Wybrano otwarcie konta rozliczeniowego");
                        AddBillingAccount();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Wybrano otwarcie konta oszczędnościowego");
                        AddSavingAccount();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Wybrano wpłatę pieniędzy na konto");
                        AddMoney();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Wybrano wypłatę pieniędzy z konta");
                        TakeMoney();
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Wybrano listę klientów");
                        ListOfCustomers();
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Wybrano listę wszystkich kont");
                        ListOfAllAccounts();
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Wybrano zamknięcie miesiąca");
                        CloseMonth();
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }

            } while (action != 0);
        }

        private void ListOfAccounts()
        {
            Console.Clear();
            Console.Write("Podaj pesel klienta: ");
            long pesel = long.Parse(Console.ReadLine());
            Console.WriteLine("\nKonta klienta {0}", pesel);

            foreach (var account in _accountsManager.GetAccountsByPesel(pesel))
                _printer.Print(account); 

            Console.ReadKey();
        }

        private void AddBillingAccount()
        {
            Console.Clear ();

            string firstName;
            string lastName;
            long pesel;

            Console.Write("Podaj imię: ");
            firstName = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            lastName = Console.ReadLine();
            Console.Write("Podaj pesel: ");
            pesel = long.Parse(Console.ReadLine());

            var account = _accountsManager.CreateBillingAccount(firstName, lastName, pesel);
            Console.WriteLine("Utworzono konto rozliczeniowe");
            _printer.Print(account);

            Console.ReadKey();
        }

        private void AddSavingAccount()
        {
            Console.Clear();

            string firstName;
            string lastName;
            long pesel;

            Console.Write("Podaj imię: ");
            firstName = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            lastName = Console.ReadLine();
            Console.Write("Podaj pesel: ");
            pesel = long.Parse(Console.ReadLine());

            var account = _accountsManager.CreateSavingsAccount(firstName, lastName, pesel);
            Console.WriteLine("Utworzono konto oszczędnościowe");
            _printer.Print(account);

            Console.ReadKey();
        }

        private void AddMoney()
        {
            string accountNumber;
            decimal value;

            Console.Write("Numer konta: ");
            accountNumber = Console.ReadLine();
            Console.Write("Kwota: ");
            value  = decimal.Parse(Console.ReadLine());

            _accountsManager.AddMoney(accountNumber, value);

            var account = _accountsManager.GetAccount(accountNumber);
            _printer.Print(account);

            Console.ReadKey();
        }

        private void TakeMoney()
        {
            string accountNumber;
            decimal value;

            Console.Write("Numer konta: ");
            accountNumber = Console.ReadLine();
            Console.Write("Kwota: ");
            value = decimal.Parse(Console.ReadLine());

            _accountsManager.TakeMoney(accountNumber, value);

            var account = _accountsManager.GetAccount(accountNumber);
            _printer.Print(account);

            Console.ReadKey();
        }

        private void ListOfCustomers()
        {
            foreach (var customer in _accountsManager.ListOfCustomers())
                Console.WriteLine(customer);

            Console.ReadKey();
        }

        private void ListOfAllAccounts()
        {
            foreach (var account in _accountsManager.GetAllAccounts())
                _printer.Print(account);

            Console.ReadKey();
        }

        private void CloseMonth()
        {
            _accountsManager.CloseMonth();
            Console.WriteLine("Miesiąc zamknięty");

            Console.ReadKey();
        }
    }
}
