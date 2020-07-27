using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FullScratchCore.Models
{
    class TextTabItem : TabItemBase
    {
        public TextTabItem(string header, string contents, ControlType Type) : base(header, Type)
        {
            this.Header = header;
            this.Contents = contents;
            this.TabType = Type;
            this.TabID = System.Guid.NewGuid().ToString();
        }

        private string _Contents { get; set; }
        public string Contents
        {
            get
            {
                return _Contents;
            }
            set
            {
                _Contents = value;
            }
        }
    }
}

