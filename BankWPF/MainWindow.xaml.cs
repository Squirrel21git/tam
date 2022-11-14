using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BankWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AccountsManager accountManager = new();

        public MainWindow()
        {
            InitializeComponent();
            accountManager.CreateBillingsAccount("Jan", "Kowalski", 123);
            accountManager.CreateBillingsAccount("Marek", "Kowalski", 123);
            accountManager.CreateBillingsAccount("Jacek", "Kowalski", 123);


            listaGlowna.ItemsSource = accountManager.GetAllAccounts();
            whatShow.Content = "Wszystkie konta klientów";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pesel pesel = new();
            pesel.ShowDialog();

            listaGlowna.ItemsSource = accountManager.GetAllAccountFor(Convert.ToInt64(pesel.peselTemp)).ToList();
            whatShow.Content = "Wszystkie konta klienta: " + pesel.peselTemp;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddAccount addAccount = new();
            addAccount.ShowDialog();

            if (addAccount.accountType.Text == "Rozliczeniowe")
                accountManager.CreateBillingsAccount(addAccount.nameToAdd.Text, addAccount.surnameToAdd.Text, Convert.ToInt64(addAccount.peselToAdd.Text));
            else
                accountManager.CreateSavingsAccount(addAccount.nameToAdd.Text, addAccount.surnameToAdd.Text, Convert.ToInt64(addAccount.peselToAdd.Text));

            listaGlowna.ItemsSource = accountManager.GetAllAccountFor(Convert.ToInt64(addAccount.peselToAdd.Text)).ToList();
            whatShow.Content = "Utworzone konto";
        }

        //private void listaImion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //MessageBox.Show(listaImion.SelectedIndex.ToString());
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    AddToList addToList = new AddToList();

        //    addToList.Show();
        //}


        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    if (listaImion.SelectedIndex != -1)
        //        PersonData.list.Remove(listaImion.SelectedItem as PersonData);
        //}

        //private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        //{
        //    var header = sender as GridViewColumnHeader;
        //    string columnNameToSort = header.Content.ToString();

        //    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listaImion.ItemsSource);
        //    ListSortDirection howToSort = ListSortDirection.Ascending;

        //    if (view.SortDescriptions.Any())
        //    {
        //        SortDescription item = view.SortDescriptions.ElementAt(0);
        //        if (columnNameToSort == item.PropertyName.ToString())
        //            if (item.Direction == ListSortDirection.Descending)
        //                howToSort = ListSortDirection.Ascending;
        //            else
        //                howToSort = ListSortDirection.Descending;
        //    }

        //    view.SortDescriptions.Clear();
        //    view.SortDescriptions.Add(new SortDescription(columnNameToSort, howToSort));
        //}
    }
}
