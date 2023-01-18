﻿using System;
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
using System.Windows.Shapes;

namespace BankWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Pesel.xaml
    /// </summary>
    public partial class Pesel : Window
    {
        public string peselTemp = "";
        public Pesel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            peselTemp = peselAccount.Text;
            this.Close();
        }
    }
}