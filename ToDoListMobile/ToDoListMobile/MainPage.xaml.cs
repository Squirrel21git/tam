using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListMobile.Classes;
using ToDoListMobile.Pages;
using Xamarin.Forms;

namespace ToDoListMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            eventsItemListView.ItemsSource = EventItem.List;
        }

        private void eventsItemListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as EventItem;

            DisplayAlert(item.Subject, item.Info, "Zamknij");
        }

        private async void ToolbarItem_ClickedAdd(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventItemPage());
        }
    }
}
