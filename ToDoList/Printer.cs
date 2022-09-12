using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Printer
    {
        public void PrintList(List<Event> events)
        {
            foreach (var item in events)
                Console.WriteLine("{0}. {1}\n", item.Id, item.Subject);        
        }

        public void PrintChoosed(Event value)
        {
            Console.WriteLine("Temat: {0}\nOpis:\n {1}\n", value.Subject, value.Description);
        }
    }
}
