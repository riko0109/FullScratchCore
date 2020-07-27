using FullScratchCore.Models.Command;
using FullScratchCore.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FullScratchCore.Models
{
    public class TabItemBase
    {
        public enum ControlType
        {
            Text,
            CSV,
            Image
        }

        /// <summary>
        /// tabが持つ子コントロールのタイプ　テキスト、グリッド、イメージ
        /// </summary>
        private ControlType _TabType { get; set; }
        public ControlType TabType
        {
            get
            {
                return _TabType;
            }
            set
            {
                _TabType = value;
            }
        }

        /// <summary>
        /// ヘッダーに表示される文字列
        /// </summary>
        public string Header { get; protected internal set; }

        /// <summary>
        /// TabItemのアイデンティティ
        /// </summary>
        private string _TabID { get; set; }
        public string TabID
        {
            get
            {
                return _TabID;
            }
            set
            {
                _TabID = value;
            }
        }


        public TabItemBase(string header, ControlType type)
        {
            this.Header = header;
            this.ExecuteCmd = new TabCloseCmd();
            this.TabType = type;
            this.TabID = System.Guid.NewGuid().ToString();

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

