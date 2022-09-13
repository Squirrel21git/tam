using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HobbyApp
{
    internal class Printer
    {
        public void PrintMainMenu()
        {
            Console.Clear();

            Console.WriteLine("Wybierz akcję:\n" +
                              "1 - Dodaj hobby\n" +
                              "2 - Dodaj użytkownika\n" +
                              "3 - Dodaj event\n" +
                              "4 - Dodaj użytkownika do eventu\n" +
                              "5 - Wyświetl listę hobby\n" +
                              "6 - Wyświetl listę użytkowników\n" +
                              "7 - Wyświetl eventy\n" +
                              "0 - Zakończ");
        }

        public void PrintUserEvents(User user)
        {
            foreach (var e in user.Events)
                Console.WriteLine("Data: {0}\tNazwa: {1}", e.Date, e.Hobby.Name);
        }

        public void PrintEventUsers(Event _event)
        {
            foreach (var u in _event.Users)
                Console.WriteLine("\tImie i nazwisko: {0} {1}", u.FirstName, u.LastName);
        }

        public void PrintEvents(List<Event> _events)
        {
            int i = 0;
            foreach (var e in _events)
            {
                i++;
                Console.WriteLine("{0}. Data: {1}\tNazwa: {2}", i, e.Date.ToShortDateString(), e.Hobby.Name);
                PrintEventUsers(e);
            }
        }

        public void PrintShortEvents(List<Event> _events)
        {
            int i = 0;
            foreach (var e in _events)
            {
                i++;
                Console.WriteLine("{0}. Data: {1}\tNazwa: {2}", i, e.Date.ToShortDateString(), e.Hobby.Name);
            }
        }

        public void PrintUsers(List<User> users)
        {
            int i = 0;
            foreach (var u in users)
            {
                i++;
                Console.WriteLine("{0}. Imie i nazwisko: {1} {2}", i, u.FirstName, u.LastName);
            }
        }

        public void PrintHobbys(List<Hobby> hobbys)
        {
            int i = 0;
            foreach (var h in hobbys)
            {
                i++;
                Console.WriteLine("{0}. {1}", i, h.Name );
            }
        }
    }
}
