using bank;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int version = 1, number = 3;

            //var printer = new Printer();
            //var smallPrinter = new SmallPrinter();

            //var manager = new AccountsManager();

            //manager.CreateSavingsAccount("Jan", "Kowalski", 84121702131);
            //manager.CreateBillingAccount("Jan", "Kowalski", 84121702131);
            //manager.CreateBillingAccount("Tomasz", "Jakiś", 95070602181);
            //manager.CreateSavingsAccount("Adam", "Nowak", 90080702171);

            //foreach (var account in manager.GetAllAccounts())
            //    printer.Print(account);

            //printer.Print(((IList<Account>)manager.GetAllAccounts())[1]);

            //foreach (var account in manager.GetAccountsByPesel(84121702131))
            //    smallPrinter.Print(account);

            //smallPrinter.Print(manager.GetAccountByAccountNumber("940000000004"));

            //foreach (var account in manager.ListOfCustomers())
            //    Console.WriteLine(account);

            //Console.WriteLine("\nAutor: Dawid Woźniak");
            //Console.WriteLine("Wersja: {0}, numer kompilacji: {1}", version, number);
            //Console.ReadLine();
            var bankManager = new BankManager();

            bankManager.Run();
        }
    }
}