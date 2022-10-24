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
    public partial class CreatePostPage : ContentPage
    {
        public CreatePostPage()
        {
            InitializeComponent();
            userPicker.ItemsSource = User.List;
        }

        private void AddPostButton_Clicked(object sender, EventArgs e)
        {
            Post.List.Add(new Post(userPicker.SelectedItem as User, description.Text));
            description.Text = "";
        }
    }
}