using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powtorzenieEgzaminWPF
{
    public class Person
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Email { get; set; }

        public Person(string name, int number, string email)
        {
            Name = name;
            Number = number;
            Email = email;
        }


    }
}
