using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VMF.UI.Helpers
{
    public class OptionsTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BlankTemplate { get; set; }

        public DataTemplate BinaryzationTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FilterType filterType = (FilterType)item;
            switch (filterType)
            {
                case FilterType.GrayScale:
                case FilterType.None:
                    return BlankTemplate;
                case FilterType.Binaryzation:
                    return BinaryzationTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
