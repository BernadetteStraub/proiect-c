using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Straub_Bernadette_proiect.CustomCommands
{
    public class StopCommand
    {
        private static RoutedUICommand launch_command;
        static StopCommand()
        {
            var myInputGestures = new InputGestureCollection();
            myInputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            launch_command = new RoutedUICommand("Launch", "Launch", typeof(StopCommand), myInputGestures);
        }
        public static RoutedUICommand Launch { get { return launch_command; } }
    }
}
