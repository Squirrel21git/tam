using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventManager eventManager = new EventManager();

            eventManager.Run();
        }
    }
}
