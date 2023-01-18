using Android.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace essentialXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactInfo : ContentPage
    {
        public ContactInfo()
        {
            InitializeComponent();
        }

        private void EditBtn_Clicked(object sender, EventArgs e)
        {
            
        }

        private void DeleteBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}