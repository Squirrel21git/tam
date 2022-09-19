using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Manager
    {
        public List<Kartkowka> kartkowki = new List<Kartkowka> ();

        public Manager()
        {
            kartkowki.Add(new Kartkowka(1, 5));
            kartkowki.Add(new Kartkowka(2, 4));
            kartkowki.Add(new Kartkowka(3, 5));
            kartkowki.Add(new Kartkowka(4, 5));
            kartkowki.Add(new Kartkowka(5, 1));
        }

        public List<Kartkowka> GetKartkowkiZOcena(int ocena)
        {
            return kartkowki.Where(a => a.Ocena == ocena).ToList();
        }

        public void Printer(List<Kartkowka> _kartkowki)
        {
            foreach (var item in _kartkowki)
                Console.WriteLine("Id: {0}, Ocena: {1}", item.Id, item.Ocena);
        }
    }
}
