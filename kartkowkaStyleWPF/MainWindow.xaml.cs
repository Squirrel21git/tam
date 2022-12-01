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

namespace kartkowkaStyleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();


            var textList = userText.Text.Trim().Split();

            var stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;

            for (int i = 0; i < textList.Length; i++)
            {
                var label = new Label();

                label.Content = textList[i];
                label.Style = (Style)Resources[$"color{random.Next(1,4)}"];

                stack.Children.Add(label);
            }

            results.Children.Add(stack);
        }
    }
}
