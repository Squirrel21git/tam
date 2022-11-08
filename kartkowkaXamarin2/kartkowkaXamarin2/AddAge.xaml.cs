using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using kartkowkaXamarin2.Classes;

namespace kartkowkaXamarin2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAge : ContentPage
    {
        public AddAge()
        {
            InitializeComponent();
        }

        private void CreateUserButton_Clicked(object sender, EventArgs e)
        {
            Data.List.Add(new Data(int.Parse(age.Text)));
            age.Text = "";
        }

        private void ShowAgeButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Wiek: " , Data.List[Data.List.Count - 1].Age.ToString(), "Zamknij");
        }
    }
}