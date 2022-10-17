using _4b2_ToDoList.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _4b2_ToDoList.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewDone : ContentPage
    {
        JsonSO jsonSaver = new JsonSO();
        public ListViewDone()
        {
            InitializeComponent();

            List<EventItem> temp = new List<EventItem>(EventItem.List as ObservableCollection<EventItem>);
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ToDoListDone.json");
            if (File.Exists(path))
            {
                var ListEventItem = JsonConvert.DeserializeObject<List<EventItem>>(File.ReadAllText(path));
                EventItem.ListDone = new ObservableCollection<EventItem>(ListEventItem);
            }

            eventsItemListViewDone.ItemsSource = EventItem.ListDone;
        }

        private void eventsItemListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as EventItem;
            DisplayAlert(item.Subject, item.Info, "Zamknij");
        }

        private void MenuItem_Unfinish(object sender, EventArgs e)
        {
            var item = (sender as MenuItem).CommandParameter as EventItem;
            EventItem.ListDone.Remove(item);
            EventItem.List.Add(item);
            jsonSaver.SaveToJson(EventItem.List, "List");
            jsonSaver.SaveToJson(EventItem.ListDone, "ListDone");
        }

        private async void MenuItem_Edit(object sender, EventArgs e)
        {
            var item = (sender as MenuItem).CommandParameter as EventItem;
            await Navigation.PushAsync(new EventItemPage(item.Id));
        }

        private void MenuItem_Delete(object sender, EventArgs e)
        {
            var item = (sender as MenuItem).CommandParameter as EventItem;
            EventItem.ListDone.Remove(item);
            jsonSaver.SaveToJson(EventItem.ListDone, "ListDone");
        }
    }
}
