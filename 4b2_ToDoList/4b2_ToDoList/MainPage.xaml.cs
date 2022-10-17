using _4b2_ToDoList.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using _4b2_ToDoList.pages;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace _4b2_ToDoList
{
    public partial class MainPage : ContentPage
    {
        JsonSO jsonSaver = new JsonSO();

        public MainPage()
        {
            InitializeComponent();
            List<EventItem> temp = new List<EventItem>(EventItem.List as ObservableCollection<EventItem>);
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ToDoList.json");

            if (File.Exists(path))
            {
                var ListEventItem = JsonConvert.DeserializeObject<List<EventItem>>(File.ReadAllText(path));

                EventItem.List = new ObservableCollection<EventItem>(ListEventItem);
            }

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
        private async void ToolbarItem_ClickedFinished(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListViewDone());
        }

        private void MenuItem_Delete(object sender, EventArgs e)
        {
            var item = (sender as MenuItem).CommandParameter as EventItem;
            EventItem.List.Remove(item);
            jsonSaver.SaveToJson(EventItem.List, "List");
        }

        private async void MenuItem_Edit(object sender, EventArgs e)
        {
            var item = (sender as MenuItem).CommandParameter as EventItem;
            await Navigation.PushAsync(new EventItemPage(item.Id));
        }

        private void MenuItem_Finish(object sender, EventArgs e)
        {
            var item = (sender as MenuItem).CommandParameter as EventItem;
            EventItem.List.Remove(item);

            List<EventItem> temp = new List<EventItem>(EventItem.List as ObservableCollection<EventItem>);
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ToDoListDone.json");
            if (File.Exists(path))
            {
                var ListEventItem = JsonConvert.DeserializeObject<List<EventItem>>(File.ReadAllText(path));
                EventItem.ListDone = new ObservableCollection<EventItem>(ListEventItem);
            }

            EventItem.ListDone.Add(item);
            jsonSaver.SaveToJson(EventItem.List, "List");
            jsonSaver.SaveToJson(EventItem.ListDone, "ListDone");
        }

        private void ToolbarItem_SaveToJson(object sender, EventArgs e)
        {
            var jsonSaver = new JsonSO();

            jsonSaver.SaveToJson(EventItem.List, "List");
        }
    }
}
