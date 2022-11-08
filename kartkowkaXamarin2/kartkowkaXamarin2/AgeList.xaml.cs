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
    public partial class AgeList : ContentPage
    {
        public AgeList()
        {
            InitializeComponent();
            ageListView.ItemsSource = Data.List;
        }

    }
}