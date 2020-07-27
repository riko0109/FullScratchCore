using FullScratchCore.Command;
using FullScratchCore.Models;
using FullScratchCore.Models.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FullScratchCore.ViewModels
{
    public class CustomTabViewModel : ViewModelBase
    {
        /// <summary>
        /// タブアイテムを保持するコレクション
        /// </summary>
        private static ObservableCollection<TabItemBase> _Tabs { get; set; } = new ObservableCollection<TabItemBase>();
        public static ObservableCollection<TabItemBase> Tabs
        {
            get
            {
                return _Tabs;
            }
            set
            {
                _Tabs = value;
            }
        }

        public CustomTabViewModel()
        {
        }

        private TabItemBase _SelectedTabItem { get; set; }
        public TabItemBase SelectedTabItem
        {
            get
            {
                return _SelectedTabItem;
            }
            set
            {
                _SelectedTabItem = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(_SelectedTabItem));
            }
        }

        public void TabAdd(TabItemBase tab)
        {
            Tabs.Add(tab);
        }

        public void TabAdd(List<TabItemBase> tabs)
        {
            foreach (var t in tabs)
            {
                Tabs.Add(t);
            }
        }
    }
}

