using FullScratchCore.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace FullScratchCore.Models
{
    /// <summary>
    /// Menuを表すオブジェクト
    /// </summary>
    public class Menu : INotifyPropertyChanged
    {
        /// <summary>
        /// Menuに表示される文字列
        /// </summary>
        public string Header { get; private set; }

        /// <summary>
        /// 親メニュー
        /// </summary>
        public Menu ParentMenu { get; private set; }

        /// <summary>
        /// プロパティ変更通知イベント
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Menuが持つ子メニュー
        /// </summary>
        public ObservableCollection<Menu> ChildMenus { get; private set; } = new ObservableCollection<Menu>();


        /// <summary>
        /// ヘッダー引数ありコンストラクタ　デバッグ用
        /// </summary>
        /// <param name="header"></param>
        public Menu(string header)
        {
            this.Header = header;
        }

        /// <summary>
        /// ヘッダー、子アイテム引数ありコンストラクタ
        /// </summary>
        /// <param name="header"></param>
        /// <param name="childmenu"></param>
        public Menu(string header, ObservableCollection<Menu> childmenus, ICommand executecmd)
        {
            this.Header = header;
            this.ChildMenus = childmenus;
            this.ExecuteCmd = executecmd;
        }

        /// <summary>
        /// ヘッダー、子アイテム引数ありコンストラクタ
        /// </summary>
        /// <param name="header"></param>
        /// <param name="childmenu"></param>
        public Menu(string header, ObservableCollection<Menu> childmenus)
        {
            this.Header = header;
            this.ChildMenus = childmenus;
        }

        /// <summary>
        /// ヘッダー、子アイテム引数ありコンストラクタ デバッグ用
        /// </summary>
        /// <param name="header"></param>
        /// <param name="childitems"></param>
        public Menu(string header, ICommand executecmd)
        {
            this.Header = header;
            this.ExecuteCmd = executecmd;
        }



        /// <summary>
        /// 実行するコマンド
        /// </summary>
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
        /// 子メニューの個数を返す
        /// </summary>
        /// <returns></returns>
        public int GetChildCount()
        {
            return ChildMenus.Count;
        }

        /// <summary>
        /// 子メニューにメニューを追加する
        /// </summary>
        /// <param name="menu"></param>
        public void AddChild(Menu menu)
        {
            ChildMenus.Add(menu);
        }
    }
}


