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
            this.TextBoxInstance = new TextBox();
            this.Header = header;
            this.Contents = contents;
            this.TabType = Type;
            this.TabID = System.Guid.NewGuid().ToString();
        }

        private TextBox TextBoxInstance { get; set; }

        public string Contents
        {
            get
            {
                return TextBoxInstance.Text;
            }
            set
            {
                TextBoxInstance.Text = value;
            }
        }

       

        public Int32 CaretIndex
        {
            get
            {
                return TextBoxInstance.CaretIndex;
            }
        }
    }
}

