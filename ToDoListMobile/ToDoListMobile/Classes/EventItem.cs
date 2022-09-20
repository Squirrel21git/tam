using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDoListMobile.Classes
{
    internal class EventItem
    {

        public static ObservableCollection<EventItem> List = new ObservableCollection<EventItem>();
        public string Subject { get; set; }
        public string Info { get; set; }

        public EventItem(string subject, string info)
        {
            Subject = subject;
            Info = info;
        }
    }
}
