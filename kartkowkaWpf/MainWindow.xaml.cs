using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kartkowkaWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        Button[,] buttons = new Button[2, 2];
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++) {
                    buttons[i, j] = new Button();
                    grid.Children.Add(buttons[i, j]);
                    Grid.SetColumn(buttons[i, j], j);
                    Grid.SetRow(buttons[i, j], i);
                    buttons[i, j].Click += Button_Click_1;
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++) {
                    buttons[i, j].Content = (random.Next(1, 5)).ToString();
                }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = (random.Next(1, 5)).ToString();
        }
    }
}
