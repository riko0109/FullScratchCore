using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FullScratchCore.Models
{
    public class Directory : IDisposable, INotifyPropertyChanged
    {
        #region プロパティ
        /// <summary>
        /// DirectoryInfoを格納。値はここを参照する
        /// </summary>
        public DirectoryInfo DirectoryInfo { get; set; }

        /// <summary>
        /// このフォルダが持つ子フォルダ
        /// </summary>
        private ObservableCollection<Directory> _ChildDirectories { get; set; }
        public ObservableCollection<Directory> ChildDirectories
        {
            get
            {
                return _ChildDirectories;
            }
            set
            {
                _ChildDirectories = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(_ChildDirectories));
            }
        }

        /// <summary>
        /// ツリーに表示される文字列
        /// </summary>
        public string Header
        {
            get
            {
                if (DirectoryInfo == null)
                {
                    return string.Empty;
                }
                else
                {
                    return DirectoryInfo.Name;
                }
            }
        }

        /// <summary>
        /// ツリーが展開されているかどうかのフラグ
        /// </summary>
        private bool _IsExpanded { get; set; }
        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set
            {
                _IsExpanded = value;
                Expanded_Changed(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// ツリーが選択されているかどうかのフラグ
        /// </summary>
        private bool _IsSelected { get; set; }
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                if (IsSelected)
                {
                    Selected_Changed(this);
                    OnSelectedChanged(this);
                }
            }
        }
        public static Action SelectedChanged;

        public delegate void SelectedChangedHandler(object sender);
        public static event SelectedChangedHandler OnSelectedChanged;

        /// <summary>
        /// 選択されているディレクトリ
        /// </summary>
        public static Directory _SelectedDirectory { get; private set; }
        public static Directory SelectedDirectory
        {
            get { return _SelectedDirectory; }
            set
            {
                _SelectedDirectory = value;
            }
        }
        #endregion

        #region イベント類

        /// <summary>
        /// ツリーが展開されたときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Expanded_Changed(object sender, EventArgs e)
        {
            GetChildDirectories();
        }

        /// <summary>
        /// ツリーが選択されたときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Selected_Changed(object sender)
        {
            SelectedDirectory = this;
        }


        /// <summary>
        /// プロパティ変更通知用イベントハンドラ
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;

        private static void NotifyStaticPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (StaticPropertyChanged != null)
                StaticPropertyChanged(null, new PropertyChangedEventArgs(propertyName));
        }



        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Directory()
        {
        }

        /// <summary>
        /// ファイルパス指定コンストラクタ
        /// </summary>
        /// <param name="path"></param>
        public Directory(string path)
        {
            DirectoryInfo = new DirectoryInfo(path);
            ChildDirectories = new ObservableCollection<Directory> { new Directory() };
        }

        #endregion

        #region メソッド
        /// <summary>
        /// ルートディレクトリ取得
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Directory> GetRootDirectory()
        {
            var Drives = new ObservableCollection<Directory>();

            var root = DriveInfo.GetDrives();


            foreach (var d in root)
            {
                Drives.Add(new Directory(d.RootDirectory.FullName));
            }

            return Drives;
        }

        /// <summary>
        /// 当該フォルダの子フォルダを取得する
        /// </summary>
        public void GetChildDirectories()
        {
            if (!DirectoryInfo.Exists)
            {
                ChildDirectories = new ObservableCollection<Directory>();
            }

            var dir = new ObservableCollection<Directory>();

            try
            {
                foreach (var d in DirectoryInfo.GetDirectories())
                {
                    dir.Add(new Directory(d.FullName));
                }
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    MessageBox.Show(e + "\n" + e.InnerException.Message);
                }
                else
                {
                    MessageBox.Show(e.Message);
                }
            }

            ChildDirectories = dir;

        }
        #endregion

        #region　デストラクタ
        /// <summary>
        /// デストラクタ
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

