using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stoper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                history.ItemsSource = await App.MyDatabase.ReadMyTimes();
            }
            catch
            {

            }
        }
    }
}