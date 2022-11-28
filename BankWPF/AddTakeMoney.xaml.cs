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
    /// Logika interakcji dla klasy AddTakeMoney.xaml
    /// </summary>
    public partial class AddTakeMoney : Window
    {
        public decimal amountTemp = 0.0m;
        public AddTakeMoney()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            amountTemp = Convert.ToDecimal(amount.Text.Replace('.', ','));
            Close();
        }
    }
}
