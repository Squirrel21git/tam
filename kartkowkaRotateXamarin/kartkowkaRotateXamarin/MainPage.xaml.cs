using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using TabbedPage = Xamarin.Forms.TabbedPage;

namespace kartkowkaRotateXamarin
{
    public partial class MainPage : TabbedPage
    {
        private int Rotation = 0;
        private ObservableCollection<int> RotationHistory = new ObservableCollection<int>();
        public MainPage()
        {
            InitializeComponent();
            historyList.ItemsSource = RotationHistory;
        }

        private void Rotate_Clicked(object sender, EventArgs e)
        {
            int temp = 0;
            int.TryParse(userInput.Text, out temp);

            if (temp < 1 || temp > 360)
                return;

            Rotation += temp;
            lblRotate.Text = Rotation.ToString();
            lblRotate.RotateTo(Rotation);
            RotationHistory.Add(temp);
        }
    }
}
