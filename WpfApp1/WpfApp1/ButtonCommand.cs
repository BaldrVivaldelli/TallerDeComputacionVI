using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class ButtonCommand : ICommand
    {
        private Action WhattoExecute;
        private Func<bool> WhentoExecute;
        public ButtonCommand(Action What, Func<bool> When) 
        {
            WhattoExecute = What;
            WhentoExecute = When;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return WhentoExecute(); 
        }
        public void Execute(object parameter)
        {
            WhattoExecute(); 
        }
    }
}