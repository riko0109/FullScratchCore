using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FullScratchCore.ViewModels
{
    public abstract class ViewModelBase : System.Windows.Controls.UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

