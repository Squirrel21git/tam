using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


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

        public void ChooseEvent()
        {
            do
            {
                Console.Clear();
                printer.PrintEvents(Events);

                Console.WriteLine("\nWybierz event: ");
                string choice = Console.ReadLine();

                if (Int32.TryParse(choice, out int id))
                {
                    EditEvent(id);
                    break;
                }

                Console.WriteLine("Podano złą liczbę");
                Console.ReadKey();
            } while (true);
        }

        public void EditEvent(int id)
        {
            throw new MissingMethodException();
        }

        public void CreateEvent()
        {
            Console.Clear();
            Hobby _hobby;
            List<User> _users = new List<User>();
            DateTime _date = new DateTime();

            //Events.Add(new Event(_hobby, _users, _date));
        }

        public void CreateUser()
        {
            Console.Clear();

            Console.Write("Podaj imię: ");
            string firstName = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            string lastName = Console.ReadLine();

            Users.Add(new User(GenerateUserId(), firstName, lastName));
        }

        public void CreateHobby()
        {
            Console.Clear();

            Console.Write("Podaj nazwę: ");
            string name = Console.ReadLine();

            Hobbys.Add(new Hobby(GenerateHobbyId(), name));
        }

        public DateTime GetDateFromUser()
        {
            Console.Write("Podaj dzień: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Podaj miesiąc: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Podaj rok: ");
            int year = int.Parse(Console.ReadLine());

            return new DateTime(year, month, day);
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

                } while (action < 0 || action > 4);

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
                        ChooseEvent();
                        break;
                }

            } while (action != 0);
        }    
    }
}
