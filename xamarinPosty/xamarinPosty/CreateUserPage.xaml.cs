using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarinPosty.Classes;

namespace xamarinPosty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateUserPage : ContentPage
    {
        public CreateUserPage()
        {
            InitializeComponent();
        }

        private void CreateUserButton_Clicked(object sender, EventArgs e)
        {
            if (name.Text != "" && surname.Text != "" && age.Text != "")
            {
                if (genderM.IsChecked)
                    User.List.Add(new User(name.Text, surname.Text, int.Parse(age.Text), "Mężczyzna"));
                else
                    User.List.Add(new User(name.Text, surname.Text, int.Parse(age.Text), "Kobieta"));

                name.Text = "";
                surname.Text = "";
                age.Text = "";
            }
        }
    }
}