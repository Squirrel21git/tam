using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BankWPF2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PersonData.list.Add(new PersonData("Arek", 26, "arek@gmail.com"));
            PersonData.list.Add(new PersonData("Wiola", 20, "wiola@gmail.com"));
            PersonData.list.Add(new PersonData("Adam", 35, "adam@gmail.com"));
            PersonData.list.Add(new PersonData("Karol", 19, "karol@gmail.com"));


            listaImion.ItemsSource = PersonData.list;
        }

        private void listaImion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(listaImion.SelectedIndex.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddToList addToList = new AddToList();

            addToList.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (listaImion.SelectedIndex != -1)
                PersonData.list.Remove(listaImion.SelectedItem as PersonData);
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            var header = sender as GridViewColumnHeader;
            string columnNameToSort = header.Content.ToString();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listaImion.ItemsSource);
            ListSortDirection howToSort = ListSortDirection.Ascending;

            if (view.SortDescriptions.Any())
            {
                SortDescription item = view.SortDescriptions.ElementAt(0);
                if (columnNameToSort == item.PropertyName.ToString())
                    if (item.Direction == ListSortDirection.Descending)
                        howToSort = ListSortDirection.Ascending;
                    else
                        howToSort = ListSortDirection.Descending;
            }

            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(columnNameToSort, howToSort));
        }
    }
}
