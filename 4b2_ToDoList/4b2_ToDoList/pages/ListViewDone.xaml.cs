using _4b2_ToDoList.classes;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _4b2_ToDoList.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewDone : ContentPage
    {
        public ListViewDone()
        {
            InitializeComponent();
            eventsItemListViewDone.ItemsSource = EventItem.ListDone;
        }

        private void eventsItemListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as EventItem;
            DisplayAlert(item.Subject, item.Info, "Zamknij");
        }

    }
}
