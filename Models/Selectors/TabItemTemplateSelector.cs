using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FullScratchCore.Models.Selector
{
    public class TabItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextBoxTabTemplate { get; set; }
        public DataTemplate GridViewTabTemplate { get; set; }
        public DataTemplate ImageTabTemplate { get; set; }

        public override DataTemplate SelectTemplate(object Item, DependencyObject container)
        {
            switch (((TabItemBase)Item).TabType)
            {
                case TabItemBase.ControlType.Text:
                    return TextBoxTabTemplate;

                case TabItemBase.ControlType.CSV:
                    return GridViewTabTemplate;

                case TabItemBase.ControlType.Image:
                    return ImageTabTemplate;

                default:
                    return TextBoxTabTemplate;
            }
        }
    }
}
