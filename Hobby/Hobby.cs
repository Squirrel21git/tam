using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyApp
{
    internal class Hobby
    {
        public int Id { get; }
        public string Name { get; set; }

        public Hobby(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
