using FullScratchCore.Models.Common;
using FullScratchCore.ViewModels;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows.Input;
using static FullScratchCore.Models.TabItemBase;

namespace FullScratchCore.Models.Command
{
    public class OpenFileCmd : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var Opener = new FileOpener(Encoding.Default, ControlType.Text);
            if(parameter==null)
            {
                Opener.OpenFile();
            }
            else
            {
                Opener.OpenFile((string)parameter);
            }
        }
    }
}

