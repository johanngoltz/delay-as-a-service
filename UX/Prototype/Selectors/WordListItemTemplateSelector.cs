using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Prototype.Selectors
{
    public class WordListItemTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            DependencyObject parent = container;
            while (!(parent is ItemsControl)) parent = VisualTreeHelper.GetParent(parent);
            var itemsControl = parent as ItemsControl;
            return itemsControl.Items.Count > itemsControl.IndexFromContainer(container) + 1 ?
                itemsControl.Resources["DefaultItemTemplate"] as DataTemplate :
                itemsControl.Resources["LastItemTemplate"] as DataTemplate;
            //            return base.SelectTemplateCore(item, container);
        }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            return base.SelectTemplateCore(item);
        }
    }
}
