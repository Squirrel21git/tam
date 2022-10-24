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
    public partial class ShowUsersPage : ContentPage
    {
        public ShowUsersPage()
        {
            InitializeComponent();
            userPicker.ItemsSource = User.List;
        }

        private void userPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            User user = userPicker.SelectedItem as User;
            name.Text = "Imie: " + user.Name;
            surname.Text = "Nazwisko: " + user.Lastname;
            age.Text = "Wiek: " + user.Age.ToString();
            posts_count.Text = "Liczba postów:" + Post.List.Count(x => x.User == user).ToString();
        }
    }
}