using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankWPF
{
    /// <summary>
    /// Logika interakcji dla klasy AddToList.xaml
    /// </summary>
    public partial class AddToList : Window
    {
        public AddToList()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PersonData.list.Add(new PersonData(nameToAdd.Text, Convert.ToInt32(ageToAdd.Text), emailToAdd.Text));
            this.Close();
        }
    }
}
