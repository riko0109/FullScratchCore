using FullScratchCore.Models;
using FullScratchCore.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace FullScratchCore.Command
{
    class NewFileCmd : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CustomTabViewModel.Tabs.Add(new TextTabItem("New.txt", string.Empty, Models.TabItemBase.ControlType.Text));
        }
    }
}

