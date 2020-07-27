using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace FullScratchCore.Models.Commands
{
    class TestCmd : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;    
        }

        public void Execute(object parameter)
        {
            MessageBox.Show((parameter == null) ? "null":parameter.ToString());
        }
    }
}
