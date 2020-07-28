using FullScratchCore.Models;
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
        private ObservableCollection<FileListItem> _FileList { get; set; } = new ObservableCollection<FileListItem>();
        public ObservableCollection<FileListItem> FileList
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

        private FileListItem _SelectedListItem { get; set; }
        public FileListItem SelectedListItem
        {
            get
            {
                return _SelectedListItem;
            }
            set
            {
                _SelectedListItem = value;
                FileListItem.SelectedListItem = _SelectedListItem;
                if (SelectedListItem != null)
                {
                    SelectedFileChanged(this);
                }
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(_SelectedListItem));
            }
        }

        public string FilePath
        {
            get
            {
                return SelectedListItem.FullPath;
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
        }

        private void FileListUpdate(object sender)
        {
            FileList.Clear();
                try
                {
                     foreach (FileInfo f in ((Models.Directory)sender).DirectoryInfo.GetFiles())
                     {
                         FileList.Add(new FileListItem(f));
                     }
                }
                catch
                {
                }
        }
    }
}

