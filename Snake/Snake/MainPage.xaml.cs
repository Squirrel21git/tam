using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Snake
{
    public partial class MainPage : ContentPage
    {
        Random random = new Random();

        List<Snake> snakes = new List<Snake>();
        List<Apple> apples = new List<Apple>();
        List<int> kierunki = new List<int>();

        int ostatniKierunek = 1, wynik = 0;
        decimal tempX, tempY;
        bool timer;

        public MainPage()
        {
            InitializeComponent();

            Round();
        }

        private void Round()
        {
            timer = true;

            snakes.Add(new Snake(0.5m, 0.45m));
            snakes.Add(new Snake(0.5m, 0.5m));
            snakes.Add(new Snake(0.5m, 0.55m));
            snakes.Add(new Snake(0.5m, 0.6m));

            for (int i = 0; i < snakes.Count; i++)
            {
                layout.Children.Add(snakes[i]);
                AbsoluteLayout.SetLayoutBounds(snakes[i], new Rect((double)snakes[i].X, (double)snakes[i].Y, 40, 40));
                AbsoluteLayout.SetLayoutFlags(snakes[i], AbsoluteLayoutFlags.PositionProportional);
            }


            NoweJablko();

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 200), () =>
            {
                // do something every 60 seconds
                if (timer)
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Ruch();
                        if (Zjedz())
                        {
                            snakes.Add(new Snake(tempX, tempY));
                            layout.Children.Add(snakes.Last());
                            AbsoluteLayout.SetLayoutBounds(snakes.Last(), new Rect((double)snakes.Last().X, (double)snakes.Last().Y, 40, 40));
                            AbsoluteLayout.SetLayoutFlags(snakes.Last(), AbsoluteLayoutFlags.PositionProportional);

                            wynik++;
                            result.Text = "Points: " + wynik.ToString();
                        }
                    });
                else
                    EndAlert();

                return timer;
            });

            
        }

        private async void EndAlert()
        {
            if (!await DisplayAlert("Play again!", "Would you like to play again?", "Yes", "No"))
                return;

            for (int i = 0; i < snakes.Count; i++)
                layout.Children.Remove(snakes[i]);
            layout.Children.Remove(apples.Last());

            apples.Clear();
            snakes.Clear();
            kierunki.Clear();

            ostatniKierunek = 1;
            wynik = 0;

            result.Text = "Points: " + wynik;

            Round();
        }

        private bool Zjedz()
        {
            tempX = snakes.Last().X;
            tempY = snakes.Last().Y;

            if (apples.Last().X == snakes.First().X && apples.Last().Y == snakes.First().Y)
            {
                layout.Children.Remove(apples.Last());
                NoweJablko();

                return true;
            }

            return false;
        }

        private void NoweJablko()
        { 
            apples.Clear();

            bool ok;
            decimal x, y;

            do
            {
                ok = true;
                x = random.Next(10) * 0.1m;
                y = random.Next(20) * 0.05m;

                for (int i = 0; i < snakes.Count(); i++)
                    if (snakes[i].X == x && snakes[i].Y == y)
                    {
                        ok = false;
                        break;
                    }

            } while (!ok);

            apples.Add(new Apple(x, y));
            layout.Children.Add(apples.Last());
            AbsoluteLayout.SetLayoutBounds(apples[0], new Rect((double)apples[0].X, (double)apples[0].Y, 40, 40));
            AbsoluteLayout.SetLayoutFlags(apples[0], AbsoluteLayoutFlags.PositionProportional);
        }
        
        private void Ruch()
        {
            Pozycje(); 

            if (kierunki.Count > 0)
            {
                ostatniKierunek = kierunki[0];
                kierunki.RemoveAt(0);
            }

            

            switch (ostatniKierunek)
            {
                case 1:
                    snakes[0].Y -= 0.05m;
                    break;
                case 2:
                    snakes[0].Y += 0.05m;
                    break;
                case 3:
                    snakes[0].X -= 0.1m;
                    break;
                case 4:
                    snakes[0].X += 0.1m;
                    break;
            }

            for (int i = 1; i < snakes.Count(); i++)
                if (snakes[0].X == snakes[i].X && snakes[0].Y == snakes[i].Y)
                {
                    timer = false;
                    return;
                }

            if (snakes[0].X >= 0 && snakes[0].X <= 1 && snakes[0].Y >= 0 && snakes[0].Y <= 1)
                for (int i = 0; i < snakes.Count; i++)
                    AbsoluteLayout.SetLayoutBounds(snakes[i], new Rect((double)snakes[i].X, (double)snakes[i].Y, 40, 40));
            else
                timer = false;
        }

        private void Pozycje()
        {
            for (int i = snakes.Count - 1; i > 0; i--)
            {
                snakes[i].X = snakes[i - 1].X;
                snakes[i].Y = snakes[i - 1].Y;
            }
        }

        public void kierunek (int k)
        {
            if (kierunki.Count > 0)
            {
                if (kierunki.Last() != k)
                    kierunki.Add(k);
            }
            else
                kierunki.Add(k);
        }

        private void Up_Swiped(object sender, SwipedEventArgs e)
        {
            if (ostatniKierunek != 2)
                kierunek(1);
        }

        private void Down_Swiped(object sender, SwipedEventArgs e)
        {
            if (ostatniKierunek != 1)
                kierunek(2);
        }

        private void Left_Swiped(object sender, SwipedEventArgs e)
        {
            if (ostatniKierunek != 4)
                kierunek(3);
        }

        private void Right_Swiped(object sender, SwipedEventArgs e)
        {
            if (ostatniKierunek != 3)
                kierunek(4);
        }
    }
}
