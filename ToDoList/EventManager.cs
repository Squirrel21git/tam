using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class EventManager
    {
        private List<Event> events;
        private Printer printer;

        public EventManager()
        {
            events = new List<Event>();
            printer = new Printer();
        }
        public void Choose(CurrentEvent _event)
        {
            int num = 0;

            while (true)
            {
                Console.Clear();
                printer.PrintChoosed(_event);
                Console.WriteLine("1. Edytuj\n" +
                                  "2. Ukończ\n" +
                                  "3. Usuń\n");

                var tmp = Console.ReadKey().KeyChar.ToString();

                if(Int32.TryParse(tmp, out int tmpNum))
                    if(tmpNum > -1 && tmpNum < 4)
                    {
                        num = tmpNum;
                        break;
                    }
            }

            switch (num)
            {
                case 1:
                    Edit(_event);
                    break;
                case 2:
                    CurrentToCompleted(_event);
                    break;
                case 3:
                    Delete(_event);
                    break;
            }
        }

        public void Edit(CurrentEvent _event)
        {
            Console.Clear();
            printer.PrintChoosed(_event);

            Console.Write("Podaj nowy temat-: ");
            string subject = Console.ReadLine().Trim();

            Console.WriteLine("Podaj nowy opis: ");
            string desc = Console.ReadLine().Trim();

            if (subject != null || subject != "")
                _event.Subject = subject;
            if (desc != null || desc != "")
                _event.Description = desc;
        }

        public void Create()
        {
            Console.Clear();
            Console.Write("Podaj temat: ");
            string subject = Console.ReadLine();
            Console.WriteLine("Podaj opis: ");
            string desc = Console.ReadLine();

            var _event = new CurrentEvent(GenerateId(), subject, desc);

            events.Add(_event);

            Console.Clear();
            Console.WriteLine("Utworzono: {0}", _event.Subject);
            Console.ReadKey();
        }

        public void Delete(CurrentEvent _event)
        {
            events.Remove(_event);

            Console.Clear();
            Console.WriteLine("Usunięto: {0}", _event.Subject);
            Console.ReadKey();
        }

        public void CurrentToCompleted(CurrentEvent _event)
        {
            var tmp = new CompletedEvent(_event.Id, _event.Subject, _event.Description);
            
            events.Remove(_event);
            events.Add(tmp);

            Console.Clear();
            Console.WriteLine("Ukończono: {0}", tmp.Subject);
            Console.ReadKey();
        }

        public void RevertToCurrent(CompletedEvent _event)
        {
            var tmp = new CurrentEvent(_event.Id, _event.Subject, _event.Description);

            events.Remove(_event);
            events.Add(tmp);

            Console.Clear();
            Console.WriteLine("Przywrócono: {0}", tmp.Subject);
            Console.ReadKey();
        }

        public void PrintCurrentList()
        {
            Event _event;

            while (true)
            {
                Console.Clear();
                printer.PrintList(GetCurrentList(events));

                Console.WriteLine("Wpisz numer wydarzenia które chcesz wybrać lub 0 aby wyjść: ");

                var tmp = Console.ReadKey().KeyChar.ToString();

                if (tmp == "0")
                    return;

                _event = GetEventFromUser(tmp);

                if (_event != null && _event is CurrentEvent)
                    break;

                Console.WriteLine("Podano błędny numer wydarzenia");
                Console.ReadKey();
            }


            Choose((CurrentEvent)_event);   
        }

        public void PrintCompletedList()
        {
            Event _event;

            while (true)
            {
                Console.Clear();
                printer.PrintList(GetCompletedList(events));

                Console.WriteLine("Wpisz numer wydarzenia które chcesz zmienić na aktywne lub 0 aby wyjść: ");

                var tmp = Console.ReadKey().KeyChar.ToString();

                if (tmp == "0")
                    return;

                _event = GetEventFromUser(tmp);

                if (_event != null && _event is CompletedEvent)
                    break;

                Console.WriteLine("Podano błędny numer wydarzenia");
                Console.ReadKey();
            }

            RevertToCurrent((CompletedEvent)_event);
        }

        private Event GetEventFromUser(string tmp)
        {
            Event _event;

            

            if (Int32.TryParse(tmp, out int tmpNum))
                if (tmpNum > -1)
                {
                    if (tmpNum != 0)
                    {
                        _event = events.Where(a => a.Id == tmpNum).ToList()[0];
                        return _event;
                    }
                }
            return null;
        }

        private int GenerateId()
        {
            return events.Any() ? events.Max(a => a.Id) + 1 : 1;
        }

        public void PrintMainMenu()
        {
            Console.Clear();
            printer.PrintList(GetCurrentList(events));
            Console.WriteLine("Wybierz akcję:\n" +
                        "1 - wybierz z aktwynych wydarzeń\n" +
                        "2 - lista ukończonych wydarzeń\n" +
                        "3 - dodaj\n" +
                        "0 - zakończ\n");
        }

        private List<Event> GetCurrentList(List<Event> _events)
        {
            var tmp = new List<Event>();

            foreach (Event _event in _events)
                if (_event is CurrentEvent)
                    tmp.Add((CurrentEvent)_event);

            return tmp;
        }

        private List<Event> GetCompletedList(List<Event> _events)
        {
            var tmp = new List<Event>();

            foreach (Event _event in _events)
                if (_event is CompletedEvent)
                    tmp.Add((CompletedEvent)_event);

            return tmp;
        }

        public void Run()
        {
            int action = -1;
            do
            {
                do
                {
                    PrintMainMenu();

                    var tmp = Console.ReadKey().KeyChar.ToString();

                    if (Int32.TryParse(tmp, out int tmpNum))
                        action = tmpNum;
                } while (action < -1 || action > 4);

                switch (action)
                {
                    case 1:
                        PrintCurrentList();
                        break;
                    case 2:
                        PrintCompletedList();
                        break;
                    case 3:
                        Create();
                        break;
                }
            } while (action != 0);

        }
    }
}
