using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUDXamarin
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            flyout.listview.ItemSelected += OnSelectedItem;
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;

            if (item != null)
            {
                Detail = new NavigationPage(Activator.CreateInstance(item.TargetPage) as Page);
                flyout.listview.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
