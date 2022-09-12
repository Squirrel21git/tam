using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyApp
{
    internal class User
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Event> Events { get; set; }

        public User(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Events = new List<Event>();
        }
    }
}
