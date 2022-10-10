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
        }

        async void button_Clicked(object sender, EventArgs e)
        {
            EventItem.List.Add(new EventItem(subjectE.Text,infoE.Text));
            await Navigation.PopAsync();
        }
    }
}