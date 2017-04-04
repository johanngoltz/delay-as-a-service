using Blend.SampleData.SampleDataSource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Prototype.Controls
{
    public sealed partial class WeekdaySelector : UserControl
    {
        public WeekdaySelector()
        {
            this.InitializeComponent();
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            (sender as ToggleButton).Checked += (checkedSender, rE) => (DataContext as Days).Add(new DaysItem() { Abbreviaton = (checkedSender as ContentControl).Content.ToString() });
            (DataContext as Days).Remove((DataContext as Days).Where(item => item.Abbreviaton == (sender as ContentControl).Content.ToString()).First());
        }
    }
}
