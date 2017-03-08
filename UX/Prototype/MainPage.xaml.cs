using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Vorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 dokumentiert.

namespace Prototype
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage instance;
        public MainPage()
        {
            instance = this;
            this.InitializeComponent();
            scrollViewer.ManipulationDelta += ScrollViewer_ManipulationDelta;
            ((scrollViewer.Content as Pivot).Items[0] as PivotItem).ManipulationDelta += MainPage_ManipulationDelta;
            
        }

        private void MainPage_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ScrollViewer_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnPointerEntered(PointerRoutedEventArgs e)
        {
            base.OnPointerEntered(e);
        }
    }

    public class ScrollModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ScrollMode.Auto;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ScrollMode.Auto;
        }
    }
}
