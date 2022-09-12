using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    internal class SmallPrinter : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine("Numer konta: {0}", account.AccountNumber);
            Console.WriteLine("Imie i nazwisko właściciela: {0}", account.ConcatName());
            Console.WriteLine();
        }

        public void PrintNamePesel(Account account)
        {
            Console.WriteLine("Imie i nazwisko właściciela: {0}", account.ConcatName());
            Console.WriteLine("Pesel: {0}", account.Pesel);
            Console.WriteLine();
        }
    }
}
