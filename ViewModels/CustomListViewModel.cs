using FullScratchCore.Models.Command;
using FullScratchCore.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static FullScratchCore.Models.Directory;

namespace FullScratchCore.ViewModels
{
    public class CustomListViewModel : ViewModelBase
    {


        /// <summary>
        /// FileListに表示するオブジェクト
        /// </summary>
        private ObservableCollection<FileInfo> _FileList { get; set; }
        public ObservableCollection<FileInfo> FileList
        {
            get
            {
                return _FileList;
            }
            set
            {
                _FileList = value;
                RaisePropertyChanged();
            }
        }

        private FileInfo _SelectedListItem { get; set; }
        public FileInfo SelectedListItem
        {
            get
            {
                return _SelectedListItem;
            }
            set
            {
                _SelectedListItem = value;
                if (SelectedListItem != null)
                {
                    SelectedFileChanged(this);
                }

                RaisePropertyChanged();
            }
        }

        private ICommand _ExecuteCmd { get; set; }
        public ICommand ExecuteCmd
        {
            get
            {
                return _ExecuteCmd;
            }
            set
            {
                _ExecuteCmd = value;
            }
        }


        /// <summary>
        /// イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        public delegate void SelectedChangedEventHandler(object sender);
        public static event SelectedChangedEventHandler SelectedFileChanged;

        public CustomListViewModel()
        {
            Models.Directory.OnSelectedChanged += FileListUpdate;
            this.ExecuteCmd = new OpenFileCmd();
        }

        private void FileListUpdate(object sender)
        {
            try
            {
                FileList = new ObservableCollection<FileInfo>(((Models.Directory)sender).DirectoryInfo.GetFiles());
            }
            catch
            {
            }
        }



    }
}

