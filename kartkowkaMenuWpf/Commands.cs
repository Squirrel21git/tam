using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kartkowkaMenuWpf
{
    public class Commands
    {
        public static readonly RoutedUICommand Dodaj = new RoutedUICommand(
                 "Dodaj",
                 "_Dodaj",
                 typeof(Commands),
                 new InputGestureCollection()
                 {
                    new KeyGesture(Key.F1)
                 }
             );
        public static readonly RoutedUICommand Zapisz = new RoutedUICommand(
                 "Zapisz",
                 "_Zapisz",
                 typeof(Commands),
                 new InputGestureCollection()
                 {
                    new KeyGesture(Key.F2)
                 }
             );
    }
}
