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
    public partial class ShowPostsPage : ContentPage
    {
        public ShowPostsPage()
        {
            InitializeComponent();
            postsListView.ItemsSource = Post.List;
        }

        private void postsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Post;

            DisplayAlert(item.User.NameAndLastname, item.Description, "Zamknij");
        }
    }
}