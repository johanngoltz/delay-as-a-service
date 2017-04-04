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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Prototype.Controls
{
    public sealed partial class TimeDisplay : UserControl
    {
        public TimeDisplay()
        {
            this.InitializeComponent();
        }

        private static PropertyChangedCallback onTimeChangedCallback = new PropertyChangedCallback(OnTimeChanged);
        public static readonly DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(string), typeof(TimeDisplay), PropertyMetadata.Create("00:00", onTimeChangedCallback));
        public static readonly DependencyProperty TillProperty = DependencyProperty.Register("Till", typeof(string), typeof(TimeDisplay), PropertyMetadata.Create("00:00", onTimeChangedCallback));

        public string From
        {
            get { return (string)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public string Till
        {
            get { return (string)GetValue(TillProperty); }
            set { SetValue(TillProperty, value); }
        }

        private static void OnTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as TimeDisplay).setDisplayRange(!d.GetValue(FromProperty).Equals(d.GetValue(TillProperty)));
        }

        private void setDisplayRange(bool showRange)
        {
            seperatorTextBlock.Visibility = tillTextBlock.Visibility = showRange ? Visibility.Visible : Visibility.Collapsed;            
        }
    }
}
