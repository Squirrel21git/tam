using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            accountManager.CreateBillingsAccount("Jan", "Kowalski", 777);
            accountManager.CreateBillingsAccount("Marek", "Kowalski", 254);
            accountManager.CreateBillingsAccount("Jacek", "Kowalski", 123);
            accountManager.CreateSavingsAccount("Jacek", "Kowalski", 123);


            listaGlowna.ItemsSource = accountManager.GetAllAccounts();
            whatShow.Content = "Wszystkie konta klientów";
        }

        private void CommandBinding_CanAlwaysExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void AccountList_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Pesel pesel = new();
            pesel.ShowDialog();
            if (pesel.peselTemp.All(x => char.IsDigit(x)) && pesel.peselTemp.Length > 0)
            {
                listaGlowna.ItemsSource = accountManager.GetAllAccountFor(Convert.ToInt64(pesel.peselTemp)).ToList();
                whatShow.Content = "Wszystkie konta klienta: " + pesel.peselTemp;
            }
        }

        private void AllAccountsList_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            listaGlowna.ItemsSource = accountManager.GetAllAccounts();
            whatShow.Content = "Wszystkie konta klientów";
        }

        private void CreateAccount_Executed(object sender, ExecutedRoutedEventArgs e)
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

        private void CloseBank_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CloseMonth_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            accountManager.CloseMonth();
            listaGlowna.ItemsSource = null;
            listaGlowna.ItemsSource = accountManager.GetAllAccounts();
            whatShow.Content = "Wszystkie konta klientów";
        }

        private void AddMoney_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Account selectedAccount = listaGlowna.SelectedItem as Account;

            if (selectedAccount != null)
            {
                AddTakeMoney addTake = new();
                addTake.ShowDialog();

                if (addTake.amountTemp > 0.0m)
                {
                    accountManager.AddMoney(selectedAccount.AccountNumber, addTake.amountTemp);
                    listaGlowna.ItemsSource = accountManager.GetAllAccountFor(selectedAccount.Pesel).ToList();
                    whatShow.Content = "Wszystkie konta klienta" + selectedAccount.Pesel.ToString();
                }
            }
            
        }

        private void TakeMoney_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Account selectedAccount = listaGlowna.SelectedItem as Account;

            if (selectedAccount != null)
            {
                AddTakeMoney addTake = new();
                addTake.ShowDialog();

                if (addTake.amountTemp > 0.0m && addTake.amountTemp < selectedAccount.Balance)
                {
                    accountManager.TakeMoney(selectedAccount.AccountNumber, addTake.amountTemp);
                    listaGlowna.ItemsSource = accountManager.GetAllAccountFor(selectedAccount.Pesel).ToList();
                    whatShow.Content = "Wszystkie konta klienta" + selectedAccount.Pesel.ToString();
                }
                else
                    MessageBox.Show("Podaj poprawną kwotę", "Błąd");
            }
        }

        private void AddMoney_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listaGlowna.SelectedItem != null)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void TakeMoney_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listaGlowna.SelectedItem != null && (listaGlowna.SelectedItem as Account).Balance > 0.0m)
                e.CanExecute = true;
            else
                e.CanExecute = false;
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
