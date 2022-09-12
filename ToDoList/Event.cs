using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    abstract class Event
    {
        public int Id { get; }
        public string Subject { get; set; }
        public string Description { get; set; }

        public Event(int id, string subject, string description)
        {
            Id = id;
            Subject = subject;
            Description = description;
        }

        public string ToOneString()
        {
            return Subject + "\n" + Description;
        }
    }
}
