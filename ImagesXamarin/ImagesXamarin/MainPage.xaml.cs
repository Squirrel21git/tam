using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImagesXamarin
{
    public partial class MainPage : ContentPage
    {
        

        List<List<string>> images = new List<List<string>>
        {
            new List<string>
            {
                "https://cdn.pixabay.com/photo/2012/06/19/10/32/owl-50267_960_720.jpg",
                "https://cdn.pixabay.com/photo/2017/01/14/12/59/iceland-1979445_960_720.jpg",
                "https://cdn.pixabay.com/photo/2018/08/12/16/59/parrot-3601194_960_720.jpg"
            },
            new List<string>
            {

            },
            new List<string>
            {

            }
        };


        int typeNum = 0;
        int imgNum = 0;
        public MainPage()
        {
            InitializeComponent();
            

            image.Source = images[typeNum][imgNum];
            labelCount.Text = (imgNum+1) + " OF " + images[typeNum].Count;

            uriBtn.BorderColor = Color.Orange;
        }

        private void PrevButton_Clicked(object sender, EventArgs e)
        {
            if (imgNum == 0)
               ChangeImg(-1);
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ChangeImg(int num)
        {

            if (num == -1)
            {
                imgNum = images[typeNum].Count - 1;

            }
                
            image.Source = images[typeNum][imgNum];
        }
    }
}
