using Blend.SampleData.SampleConnections;
using Blend.SampleData.SampleDataSource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace Prototype
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class AddConnectionBasedAlarm : Page
    {
        public AddConnectionBasedAlarm()
        {
			AlarmsItem newAlarm = new AlarmsItem();

			foreach (var item in new string[] { "Mo", "Di", "Mi", "Do", "Fr", "Sa", "So" }.Select(abbreviation => new DaysItem() { Abbreviaton = abbreviation }))
				newAlarm.Time.Interval.Days.Add(item);
			foreach (var item in new string[] { "Start", "Changeover", "Destination" }.Select(type => new StopsItem { WaypointType = type }))
				newAlarm.Stops.Add(item);
			
			this.InitializeComponent();

			DatePicker.Date = DateTime.Now;

			SampleDataSource.Alarms.Clear();
			SampleDataSource.Alarms.Insert(0, newAlarm);
        }

		public void GenerateConnections()
		{
			SolidColorBrush Red = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
			SolidColorBrush StandardColor = (SolidColorBrush) Application.Current.Resources["SystemControlForegroundChromeDisabledLowBrush"];
			AlarmsItem Alarm = SampleDataSource.Alarms[0];
			Boolean valid = true;
			if (Stop0.Text.Length == 0)
			{
				Stop0.BorderBrush = Red;
				valid = false;
			} else
			{
				Stop0.BorderBrush = StandardColor;
			}
			if (Stop2.Text.Length == 0)
			{
				Stop2.BorderBrush = Red;
				valid = false;
			} else
			{
				Stop2.BorderBrush = StandardColor;
			}
			if (valid)
			{
				SampleConnections.Connection.Clear();
				IValueConverter st = (IValueConverter)new StringTimeConverter();
				TimeSpan StartTime = (TimeSpan)st.Convert(SampleDataSource.Alarms[0].Time.Departure.Earliest, null, null, null);
				TimeSpan EndTime;
				ConnectionItem ConnectionItem;
				Random Random = new Random();
				for (int i = 1; i < 3; i++)
				{
					StartTime += new TimeSpan(0, Random.Next(10), 0);
					EndTime = StartTime + new TimeSpan(0, 30 + Random.Next(15), 0);
					ConnectionItem = new ConnectionItem();
					ConnectionItem.StartTime = StartTime.ToString();
					ConnectionItem.EndTime = EndTime.ToString();
					ConnectionItem.Changeovers = Random.Next(3);
					SampleConnections.Connection.Add(ConnectionItem);
				};
				connectionList.Visibility = Windows.UI.Xaml.Visibility.Visible;
			} else
			{
				connectionList.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			}
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

				SampleDataSource.Alarms[0].Time.Departure.Earliest = (connectionList.ItemsSource as Connection)[connectionList.SelectedIndex].StartTime;
				SampleDataSource.Alarms[0].Time.Departure.Latest = (connectionList.ItemsSource as Connection)[connectionList.SelectedIndex].EndTime;
			}
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);
		}
	}

	public class StringTimeConverter : IValueConverter
	{
		object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
		{
			TimeSpan toBeReturned;
			TimeSpan.TryParse(value.ToString(), out toBeReturned);
			return toBeReturned;
		}

		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value.ToString();
		}
	}

	public class TimeFormatter : IValueConverter
	{
		object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
		{
			TimeSpan toBeReturned;
			TimeSpan.TryParse(value.ToString(), out toBeReturned);
			return toBeReturned.ToString(@"hh\:mm");
		}

		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value.ToString();
		}
	}
}
