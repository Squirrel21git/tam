using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class CurrentEvent : Event
    {
        public CurrentEvent(int id, string subject, string description) : base(id, subject, description)
        { }
    }
}
