using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace powtorzenieEgzaminWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> persons = new ObservableCollection<Person>();

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource= persons;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ShowDialog();
            persons.Add(new Person(window1.nameBox.Text, int.Parse(window1.numberBox.Text), window1.emailBox.Text));
        }

        /*private void CommandBinding_CanAlwaysExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_ExecutedOtworz(object sender, ExecutedRoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "TXT plik tekstowy (*.txt)|*.txt";

            if (ofd.ShowDialog() == true)
            {
                string text = File.ReadAllText(ofd.FileName);
                textBox.Text = text;
            }
        }

        private void CommandBinding_ExecutedZapisz(object sender, ExecutedRoutedEventArgs e)
        {
            var sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == true)
                File.WriteAllText(sfd.FileName, textBox.Text);
        }*/


    }
}
