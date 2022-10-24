using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace xamarinPosty.Classes
{
    internal class User
    {
        public static ObservableCollection<User> List = new ObservableCollection<User>();
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string NameAndLastname { get; set; }

        public User(string name, string lastname, int age, string gender)
        {
            Name = name;
            Lastname = lastname;
            Age = age;
            Gender = gender;
            NameAndLastname = name + " " + lastname;
        }
    }
}
