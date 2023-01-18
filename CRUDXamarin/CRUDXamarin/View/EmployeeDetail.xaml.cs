using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeDetail : ContentPage
    {
        public EmployeeDetail()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(addressEntry.Text))
                await DisplayAlert("Invalid", "Blank or WhiteSpace value is Invalid!", "OK");
            else
                AddNewEmplyee();
        }

        async void AddNewEmplyee()
        {
            await App.MyDatabase.CreateEmplyee(new Model.EmployeeModel
            {
                Name = nameEntry.Text.ToUpper(),
                Address = addressEntry.Text
            });
            await Navigation.PopAsync();
        }
    }
}