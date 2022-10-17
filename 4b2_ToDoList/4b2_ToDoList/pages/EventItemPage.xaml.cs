using _4b2_ToDoList.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _4b2_ToDoList.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventItemPage : ContentPage
    {
        public EventItemPage()
        {
            InitializeComponent();
            pageAddEdit.Title = "Dodaj";
        }

        public EventItemPage(int id)
        {
            InitializeComponent();

            var item = EventItem.List.Any(x => x.Id == id) ? EventItem.List.Single(x => x.Id == id) : EventItem.ListDone.Single(x => x.Id == id);
            pageAddEdit.Title = "Edytuj: " + item.Subject;

            subjectE.Text = item.Subject;
            infoE.Text = item.Info;
            idE.Text = item.Id.ToString();
        }

        async void button_Clicked(object sender, EventArgs e)
        {
            var jsonSaver = new JsonSO();
            int id = 0;
            if (idE.Text == "")
            { 
                id = EventItem.List.Any() ? EventItem.List.Max(x => x.Id) + 1 : 1;
                EventItem.List.Add(new EventItem(id, subjectE.Text, infoE.Text));
                jsonSaver.SaveToJson(EventItem.List, "List");

            }
            else
            {
                id = int.Parse(idE.Text);
                if (EventItem.List.Any(x => x.Id == id))
                {
                    EventItem.List.Remove(EventItem.List.Single(x => x.Id == int.Parse(idE.Text)));
                    EventItem.List.Add(new EventItem(id, subjectE.Text, infoE.Text));
                    jsonSaver.SaveToJson(EventItem.List, "List");
                }
                else
                {
                    EventItem.ListDone.Remove(EventItem.ListDone.Single(x => x.Id == int.Parse(idE.Text)));
                    EventItem.ListDone.Add(new EventItem(id, subjectE.Text, infoE.Text));
                    jsonSaver.SaveToJson(EventItem.ListDone, "ListDone");

                }
            }
            

           
            await Navigation.PopAsync();
        }
    }
}