using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    internal class Printer : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine("Dane konta: ");
            Console.WriteLine("ID konta: {0}", account.Id);
            Console.WriteLine("Numer konta: {0}", account.AccountNumber);
            Console.WriteLine("Typ konta: {0}", account.TypeName());
            Console.WriteLine("Środki na koncie: {0}", account.Balance);
            Console.WriteLine("Imie i nazwisko właściciela: {0}", account.ConcatName());
            Console.WriteLine("Pesel: {0}", account.Pesel);
            Console.WriteLine();
        }
        
    }
}
