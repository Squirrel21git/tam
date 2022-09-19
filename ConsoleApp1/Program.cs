using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List<int> lInt = new List<int>()
            // {
            //     3,7,9,12,15
            // };

            //foreach (var item in lInt)
            //{
            //    Console.WriteLine(item + " ");
            //}

            Manager manager = new Manager();

            manager.Printer(manager.GetKartkowkiZOcena(5));

            Console.ReadKey();
        }
    }
}
