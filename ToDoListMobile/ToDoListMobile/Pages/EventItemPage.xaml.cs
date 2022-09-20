using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListMobile.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventItemPage : ContentPage
    {
        public EventItemPage()
        {
            InitializeComponent();
        }

        async void buttonE_Clicked(object sender, EventArgs e)
        {
            EventItem.List.Add(new EventItem(subjectE.Text, infoE.Text));
            await Navigation.PopAsync();
        }
    }
}