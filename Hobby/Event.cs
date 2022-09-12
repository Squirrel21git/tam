using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyApp
{
    internal class Event
    {
        public Hobby Hobby;
        public List<User> Users;
        public DateTime Date;

        public Event(Hobby hobby, List<User> users, DateTime date)
        {
            this.Hobby = hobby;
            this.Users = users;
            this.Date = date;
        }
    }
}
