using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HobbyApp
{
    internal class Manager
    {
        List<Event> Events;
        List<User> Users;
        List<Hobby> Hobbys;
        Printer printer;

        public Manager()
        {
            Events = new List<Event>();
            Users = new List<User>();
            Hobbys = new List<Hobby>();
            printer = new Printer();
        }

        private int ChooseHobby()
        {
            do
            {
                Console.Clear();
                printer.PrintHobbys(Hobbys);

                Console.WriteLine("\nWybierz hobby (0 - zakończ): ");
                string tmp = Console.ReadKey().KeyChar.ToString();

                if (Int32.TryParse(tmp, out int id))
                {
                    if (id > -1 && id < Hobbys.Count() + 1)
                        return id;
                }

                Console.WriteLine("Podano złą liczbę");
                Console.ReadKey();

            } while (true);
        }

        private int ChooseUser()
        {
            do
            {
                Console.Clear();
                printer.PrintUsers(Users);

                Console.WriteLine("\nWybierz użytkownika (0 - zakończ): ");
                string tmp = Console.ReadKey().KeyChar.ToString();

                if (Int32.TryParse(tmp, out int id))
                {
                    if (id > -1 && id < Users.Count() + 1)
                        return id;
                }

                Console.WriteLine("Podano złą liczbę");
                Console.ReadKey();

            } while (true);
        }

        private int ChooseEvent()
        {
            do
            {
                Console.Clear();
                printer.PrintShortEvents(Events);

                Console.WriteLine("\nWybierz event (0 - zakończ): ");
                string tmp = Console.ReadKey().KeyChar.ToString();

                if (Int32.TryParse(tmp, out int id))
                {
                    if (id > -1 && id < Events.Count() + 1)
                        return id;
                }

                Console.WriteLine("Podano złą liczbę");
                Console.ReadKey();

            } while (true);
        }

        private void CreateEvent()
        {
            Console.Clear();
            Hobby _hobby;
            List<User> _users = new List<User>();
            DateTime _date;


            int h = ChooseHobby();
            if (h != 0)
                _hobby = Hobbys[h - 1];
            else
                return;

            int user = -1;
            do
            {
                user = ChooseUser();
                if (user != 0)
                    _users.Add(Users[user - 1]);

            } while (user != 0);


            _users = _users.GroupBy(a => a.Id).Select(a => a.First()).ToList();

            _date = GetDateFromUser();

            Events.Add(new Event(_hobby, _users, _date));
        }

        private void CreateUser()
        {
            Console.Clear();

            Console.Write("Podaj imię: ");
            string firstName = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            string lastName = Console.ReadLine();

            Users.Add(new User(GenerateUserId(), firstName, lastName));
        }

        private void CreateHobby()
        {
            Console.Clear();

            Console.Write("Podaj nazwę: ");
            string name = Console.ReadLine();

            Hobbys.Add(new Hobby(GenerateHobbyId(), name));
        }

        private void AddUserToEvent()
        {
            List<User> _users = new List<User>();

            int e = ChooseEvent();
            if (e == 0)
                return;

            int user = -1;
            do
            {
                user = ChooseUser();
                if (user != 0)
                    _users.Add(Users[user - 1]);

            } while (user != 0);

            Events[e - 1].Users.AddRange(_users);
            Events[e - 1].Users = Events[e - 1].Users.GroupBy(a => a.Id).Select(a => a.First()).ToList();
        }

        private DateTime GetDateFromUser()
        {
            // DZIEŃ
            int day = -1;
            do
            {
                Console.Clear();
                Console.Write("Podaj dzień: ");
                string tmp = Console.ReadLine();
                if (Int32.TryParse(tmp, out int output))
                {
                    if (output > 0 && output < 32)
                    {
                        day = output;
                        break;
                    }
                }

                Console.WriteLine("Podano zły dzień");
                Console.ReadKey();
            } while (true);
            
            // MIESIĄC
            int month = -1;
            do
            {
                Console.Clear();
                Console.Write("Podaj miesiąc: ");
                string tmp = Console.ReadLine();

                if (Int32.TryParse(tmp, out int output))
                {
                    if (output > 0 && output < 13)
                    {
                        month = output;
                        break;
                    }
                }

                Console.WriteLine("Podano zły miesiąc");
                Console.ReadKey();
            } while (true);

            // ROK
            int year = -1;
            do
            {
                Console.Clear();
                Console.Write("Podaj rok: ");
                string tmp = Console.ReadLine();
                if (Int32.TryParse(tmp, out int output))
                {
                    if (output > 1970 && output < 2100)
                    {
                        year = output;
                        break;
                    }
                }

                Console.WriteLine("Podano zły rok");
                Console.ReadKey();
            } while (true);

            DateTime date = new DateTime(year, month, day);

            Console.WriteLine("{0}",date.ToShortDateString());
            Console.ReadKey();

            return date;
        }

        private int GenerateUserId()
        {
            return Users.Any() ? Users.Max(a => a.Id) + 1 : 1;
        }

        private int GenerateHobbyId()
        {
            return Hobbys.Any() ? Hobbys.Max(a => a.Id) + 1 : 1;
        }

        public void Run()
        {
            int action = -1;
            do
            {
                do
                {
                    printer.PrintMainMenu();

                    var tmp = Console.ReadKey().KeyChar.ToString();

                    if (Int32.TryParse(tmp, out int tmpNum))
                        action = tmpNum;

                } while (action < 0 || action > 7);

                switch (action)
                {
                    case 1:
                        CreateHobby();
                        break;
                    case 2:
                        CreateUser();
                        break;
                    case 3:
                        CreateEvent();
                        break;
                    case 4:
                        AddUserToEvent();
                        break;
                    case 5:
                        Console.Clear();
                        printer.PrintHobbys(Hobbys);
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        printer.PrintUsers(Users);
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        printer.PrintEvents(Events);
                        Console.ReadKey();
                        break;
                }

            } while (action != 0);
        }
    }
}
