using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.ObjectModel;

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

            for(int i=1;i<=Int16.MaxValue;i++)
            {
                LineCount.Add(i);
            }
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

        public ObservableCollection<int> LineCount { get; set; } = new ObservableCollection<int>();


    }
}

