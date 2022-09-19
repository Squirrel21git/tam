using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarinForms_09_19
{
    public partial class MainPage : ContentPage
    {
        Random random = new Random();
        List<string> przyslowia = new List<string>()
        {
            "A kto z nami nie wypije – tego we dwa kije.",
            "Aby do wiosny!",
            "Apetyt rośnie w miarę jedzenia",
            "Aniołowie pijanych na rękach swych noszą.",
            "Atak jest najlepszą obroną.",
            "Co cię nie zabije, to cię wzmocni.",
            "Co dwie głowy, to nie jedna.",
            "Chcesz się dowiedzieć prawdy o sobie, pokłóć się z przyjacielem.",
            "Czego nie można zmienić, to trzeba polubić.",
            "Dla głupiego każdy dzień święto.",
            "Do Rzymu przez Krym.",
            "Kto ma złota worek, przed tym wszystkie drzwi otworem.",
            "Nie na to żyjemy, byśmy jedli i pili, lecz na to pijem i jemy, abyśmy żyli."
        };

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            obrot.Text = przyslowia[random.Next(0, przyslowia.Count)];
        }

        private void Change_Color(object sender, EventArgs e)
        {
            obrot.TextColor = ((Button)sender).BackgroundColor;
        }
    }
}
