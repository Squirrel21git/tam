using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF2
{
    internal class PersonData
    {
        public static ObservableCollection<PersonData> list = new ObservableCollection<PersonData>();

        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public PersonData(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }
    }
}
