using _4b2_ToDoList.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _4b2_ToDoList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            List<EventItem> temp = new List<EventItem>(EventItem.List as ObservableCollection<EventItem>);
            var ListEventItem = JsonConvert.DeserializeObject<List<EventItem>>(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ToDoList.txt")));

            //MainPage = new MainPage();

            MainPage = new NavigationPage(new MainPage(ListEventItem));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
