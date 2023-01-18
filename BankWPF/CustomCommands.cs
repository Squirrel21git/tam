using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankWPF
{
    internal class CustomCommands
    {
        public static readonly RoutedUICommand AccountList = new RoutedUICommand (
                "_Lista kont klienta",
                "Lista kont klienta",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.L, ModifierKeys.Control)
                }
            );
        public static readonly RoutedUICommand AllAccountsList = new RoutedUICommand(
                "_Wszystkie konta",
                "Wszystkie konta",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.W, ModifierKeys.Control)
                }
            );
        public static readonly RoutedUICommand CreateAccount = new RoutedUICommand(
                "_Utwórz konto",
                "Utwórz konto",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.U, ModifierKeys.Control)
                }
            );
        public static readonly RoutedUICommand CloseBank = new RoutedUICommand(
                "_Zamknij bank",
                "Zamknij bank",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F9)
                }
            );
        public static readonly RoutedUICommand CloseMonth = new RoutedUICommand(
                "Zakończ _miesiąc",
                "Zakończ miesiąc",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F5)
                }
            );
        public static readonly RoutedUICommand AddMoney = new RoutedUICommand(
                "W_płata",
                "Wpłata",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.P, ModifierKeys.Alt)
                }
            );
        public static readonly RoutedUICommand TakeMoney = new RoutedUICommand(
                "W_ypłata",
                "Wypłata",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.Y, ModifierKeys.Alt)
                }
            );
    }
}
