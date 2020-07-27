using FullScratchCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace FullScratchCore.Models.Command
{
    class TabCloseCmd : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CustomTabViewModel.Tabs.RemoveAt(CustomTabViewModel.Tabs.IndexOf(CustomTabViewModel.Tabs.FirstOrDefault(x => x.TabID == parameter)));
        }

    }
}

