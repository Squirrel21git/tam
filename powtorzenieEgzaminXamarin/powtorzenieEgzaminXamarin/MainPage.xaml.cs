using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace powtorzenieEgzaminXamarin
{
    public partial class MainPage : ContentPage
    {
        Random random= new Random();
        public MainPage()
        {
            InitializeComponent();
        }

        private void DragGestureRecognizer_DragStarting(object sender, DragStartingEventArgs e)
        {
            int temp = random.Next(10);

            e.Data.Properties.Add("liczba", temp);
        }

        private async void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
        {
            label.Text = e.Data.Properties["liczba"].ToString();
            await Navigation.PushAsync(new Page1());
        }
    }
}
