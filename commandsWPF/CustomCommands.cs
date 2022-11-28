using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace commandsWPF
{
    internal class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand(
                "Exit from app",
                "Exit",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.Q, ModifierKeys.Control)
                }
            );
    }
}
