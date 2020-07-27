using FullScratchCore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FullScratchCore.ViewModels
{
    class CustomTreeViewModel : ViewModelBase
    {
        /// <summary>
        /// ルートディレクトリオブジェクト
        /// </summary>
        public ObservableCollection<Directory> RootDirectory { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustomTreeViewModel()
        {
            RootDirectory = Directory.GetRootDirectory();
            Directory.SelectedChanged += SelectedItemTextUpdate;

        }

        /// <summary>
        /// 選択フォルダパス表示用プロパティ
        /// </summary>
        private string _SelectedItemText { get; set; }
        public string SelectedItemText
        {
            get
            {
                return _SelectedItemText;
            }
            set
            {
                _SelectedItemText = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(_SelectedItemText));
                OnSelectedChanged?.Invoke(this);
            }
        }

        /// <summary>
        /// Treeviewの選択されたアイテムが更新された時のイベントハンドラ
        /// </summary>
        private void SelectedItemTextUpdate()
        {
            this.SelectedItemText = Directory.SelectedDirectory.DirectoryInfo.FullName;
        }

        public delegate void SelectedChangedEventHandler(object sender);
        public static event SelectedChangedEventHandler OnSelectedChanged;

    }
}

