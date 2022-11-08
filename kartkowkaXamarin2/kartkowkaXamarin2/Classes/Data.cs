using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace kartkowkaXamarin2.Classes
{
    internal class Data
    {
        public static ObservableCollection<Data> List = new ObservableCollection<Data>();
        public int Age { get; set; }

        public Data(int age)
        {
            Age = age;
        }

    }
}
