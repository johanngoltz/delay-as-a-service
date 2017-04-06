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
using Blend.SampleData.SampleDataSource;
using Windows.UI;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace Prototype
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class AddTimeBasedAlarm : Page
    {
        public AddTimeBasedAlarm()
        {
            AlarmsItem newAlarm = new AlarmsItem();

            foreach (var item in new string[] { "Mo", "Di", "Mi", "Do", "Fr", "Sa", "So" }.Select(abbreviation => new DaysItem() { Abbreviaton = abbreviation }))
                newAlarm.Time.Interval.Days.Add(item);
            foreach (var item in new string[] { "Start", "Changeover", "Destination" }.Select(type => new StopsItem { WaypointType = type }))
                newAlarm.Stops.Add(item);

            this.InitializeComponent();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

			SolidColorBrush Red = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
			SolidColorBrush StandardColor = (SolidColorBrush)Application.Current.Resources["SystemControlForegroundChromeDisabledLowBrush"];
			Boolean valid = true;
			if (Stop0.Text.Length == 0)
			{
				Stop0.BorderBrush = Red;
				valid = false;
			}
			else
			{
				Stop0.BorderBrush = StandardColor;
			}
			if (Stop2.Text.Length == 0)
			{
				Stop2.BorderBrush = Red;
				valid = false;
			}
			else
			{
				Stop2.BorderBrush = StandardColor;
			}
			if (!valid)
			{
				e.Cancel = true;
			}
			else
			{
				foreach (var alarm in SampleDataSource.Alarms)
					foreach (var emptyStop in alarm.Stops.Where(stop => stop.Name.Length == 0))
						alarm.Stops.Remove(emptyStop);
			}
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }
    }
}
