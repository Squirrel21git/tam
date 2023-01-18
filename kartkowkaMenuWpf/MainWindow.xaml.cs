using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace kartkowkaMenuWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Osoba> osoby = new ObservableCollection<Osoba>();
        public MainWindow()
        {
            InitializeComponent();
            data.ItemsSource = osoby;

            osoby.Add(new Osoba("Adam", "Nowak"));
            osoby.Add(new Osoba("Jan", "Kowalski"));
        }


        private void Always_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Dodaj_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DodajOsobe dodaj = new DodajOsobe();

            dodaj.ShowDialog();

            if (dodaj.imie.Text != "" && dodaj.nazwisko.Text != "")
                osoby.Add(new Osoba(dodaj.imie.Text.Trim(), dodaj.nazwisko.Text.Trim()));
        }

        private void Zapisz_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string jsonString = JsonSerializer.Serialize(osoby);
            File.WriteAllText("osoby.json", jsonString);
        }
    }
}
