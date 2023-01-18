using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stoper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopWatchPage : ContentPage
    { 
        Timer timer;
        bool isRunning;
        ObservableCollection<MyTime> lapTimes = new ObservableCollection<MyTime>();
        int hours = 0, mins = 0, secs = 0, milliseconds = 0;
    
        public StopWatchPage()
        {
            InitializeComponent();
            listLapTimes.ItemsSource = lapTimes;
            isRunning = false;
            timer = new Timer();
            lblStopWatch.Text = "00:00:00.00";
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            milliseconds++;
            if (milliseconds >= 1000)
            {
                secs++;
                milliseconds -= 1000;
            }
            if (secs == 59)
            {
                mins++;
                secs = 0;

            }
            if (mins == 59)
            {
                hours++;
                mins = 0;
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                lblStopWatch.Text = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", hours, mins, secs, milliseconds / 10);
            });
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            App.MyDatabase.AddMyTimes(lapTimes.ToList());
        }

        private void btnStartStop_Clicked(object sender, EventArgs e)
        {
            if (isRunning)
            {
                timer.Stop();
                ((Button)sender).Text = "start";
                isRunning = false;
            }
            else
            {
                if (timer.Container == null)
                {
                    timer = new Timer();
                    timer.Interval = 1;
                    timer.Elapsed += Timer_Elapsed;
                }
                timer.Start();
                ((Button)sender).Text = "stop";
                isRunning = true;
            }
        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            btnStartStop.Text = "start";
            isRunning = false;
            hours = 0;
            mins = 0;
            secs = 0;
            milliseconds = 0;
            lblStopWatch.Text = "00:00:00.00";
        }

        private void btnLap_Clicked(object sender, EventArgs e)
        {
            lapTimes.Add(new MyTime(lblStopWatch.Text));
        }

    }
}