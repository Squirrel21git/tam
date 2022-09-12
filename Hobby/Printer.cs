using System;
using System.Collections.Generic;
using System.Linq;
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
                              "4 - Edytuj event\n" +
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
                Console.WriteLine("Imie i nazwisko: {0} {1}", u.FirstName, u.LastName);
        }

        public void PrintEvents(List<Event> _events)
        {
            foreach (var e in _events)
                Console.WriteLine("Data: {0}\tNazwa: {1}", e.Date, e.Hobby.Name);
        }

        public void PrintUsers(List<User> users)
        {
            foreach (var u in users)
                Console.WriteLine("Imie i nazwisko: {0} {1}", u.FirstName, u.LastName);
        }
    }
}
