using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _4b2_ToDoList.classes
{
    public class EventItem
    {
        public static ObservableCollection<EventItem> List = new ObservableCollection<EventItem>();
        public static ObservableCollection<EventItem> ListDone = new ObservableCollection<EventItem>();
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Info { get; set; }
        public EventItem(int id, string subject, string info)
        {
            Id = id;
            Subject = subject;
            Info = info;
        }
    }
}
