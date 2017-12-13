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
            return base.SelectTemplate(item, container);
        }
    }
}
