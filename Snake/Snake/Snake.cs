using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Snake
{
    public class Snake  : BoxView
    {
        public new decimal X;
        public new decimal Y;

        public Snake(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }
    }
}
