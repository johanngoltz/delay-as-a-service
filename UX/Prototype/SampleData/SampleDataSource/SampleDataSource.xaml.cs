//      *********    DIESE DATEI DARF NICHT GEÄNDERT WERDEN     *********
//      Diese Datei wurde von einem Designwerkzeug erstellt. Änderungen
//      dieser Datei können Fehler verursachen.
namespace Blend.SampleData.SampleDataSource
{
    using System; 
    using System.ComponentModel;

// Um den Speicherbedarf der Beispieldaten in der Produktionsanwendung deutlich zu reduzieren, legen Sie
// die Konstante für bedingte Kompilierung DISABLE_SAMPLE_DATA fest, und deaktivieren Sie die Beispieldaten zur Laufzeit.
#if DISABLE_SAMPLE_DATA
    internal class SampleDataSource { }
#else

    public class SampleDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SampleDataSource()
        {
            try
            {
                Uri resourceUri = new Uri("ms-appx:/SampleData/SampleDataSource/SampleDataSource.xaml", UriKind.RelativeOrAbsolute);
                Windows.UI.Xaml.Application.LoadComponent(this, resourceUri);
            }
            catch
            {
            }
        }

        private Alarms _Alarms = new Alarms();

        public Alarms Alarms
        {
            get
            {
                return this._Alarms;
            }
        }

        private Tickets _Tickets = new Tickets();

        public Tickets Tickets
        {
            get
            {
                return this._Tickets;
            }
        }

        private Feedback _Feedback = new Feedback();

        public Feedback Feedback
        {
            get
            {
                return this._Feedback;
            }
        }
    }

    public class Alarms : System.Collections.ObjectModel.ObservableCollection<AlarmsItem>
    { 
    }

    public class AlarmsItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Time _Time = new Time();

        public Time Time
        {
            get
            {
                return this._Time;
            }

            set
            {
                if (this._Time != value)
                {
                    this._Time = value;
                    this.OnPropertyChanged("Time");
                }
            }
        }

        private Stops _Stops = new Stops();

        public Stops Stops
        {
            get
            {
                return this._Stops;
            }
        }
    }

    public class Time : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Interval _Interval = new Interval();

        public Interval Interval
        {
            get
            {
                return this._Interval;
            }

            set
            {
                if (this._Interval != value)
                {
                    this._Interval = value;
                    this.OnPropertyChanged("Interval");
                }
            }
        }

        private TimeRange _Departure = new TimeRange();

        public TimeRange Departure
        {
            get
            {
                return this._Departure;
            }

            set
            {
                if (this._Departure != value)
                {
                    this._Departure = value;
                    this.OnPropertyChanged("Departure");
                }
            }
        }

        private TimeRange _Arrival = new TimeRange();

        public TimeRange Arrival
        {
            get
            {
                return this._Arrival;
            }

            set
            {
                if (this._Arrival != value)
                {
                    this._Arrival = value;
                    this.OnPropertyChanged("Arrival");
                }
            }
        }
    }

    public class Interval : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Days _Days = new Days();

        public Days Days
        {
            get
            {
                return this._Days;
            }
        }
    }

    public class Days : System.Collections.ObjectModel.ObservableCollection<DaysItem>
    { 
    }

    public class DaysItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Abbreviaton = string.Empty;

        public string Abbreviaton
        {
            get
            {
                return this._Abbreviaton;
            }

            set
            {
                if (this._Abbreviaton != value)
                {
                    this._Abbreviaton = value;
                    this.OnPropertyChanged("Abbreviaton");
                }
            }
        }
    }

    public class TimeRange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Earliest = string.Empty;

        public string Earliest
        {
            get
            {
                return this._Earliest;
            }

            set
            {
                if (this._Earliest != value)
                {
                    this._Earliest = value;
                    this.OnPropertyChanged("Earliest");
                }
            }
        }

        private string _Latest = string.Empty;

        public string Latest
        {
            get
            {
                return this._Latest;
            }

            set
            {
                if (this._Latest != value)
                {
                    this._Latest = value;
                    this.OnPropertyChanged("Latest");
                }
            }
        }
    }

    public class Stops : System.Collections.ObjectModel.ObservableCollection<StopsItem>
    { 
    }

    public class StopsItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Name = string.Empty;

        public string Name
        {
            get
            {
                return this._Name;
            }

            set
            {
                if (this._Name != value)
                {
                    this._Name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        private string _WaypointType = string.Empty;

        public string WaypointType
        {
            get
            {
                return this._WaypointType;
            }

            set
            {
                if (this._WaypointType != value)
                {
                    this._WaypointType = value;
                    this.OnPropertyChanged("WaypointType");
                }
            }
        }
    }

    public class Tickets : System.Collections.ObjectModel.ObservableCollection<TicketsItem>
    { 
    }

    public class TicketsItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Date = string.Empty;

        public string Date
        {
            get
            {
                return this._Date;
            }

            set
            {
                if (this._Date != value)
                {
                    this._Date = value;
                    this.OnPropertyChanged("Date");
                }
            }
        }

        private Stops1 _Stops = new Stops1();

        public Stops1 Stops
        {
            get
            {
                return this._Stops;
            }
        }
    }

    public class StopsItem1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Name = string.Empty;

        public string Name
        {
            get
            {
                return this._Name;
            }

            set
            {
                if (this._Name != value)
                {
                    this._Name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        private string _WaypointType = string.Empty;

        public string WaypointType
        {
            get
            {
                return this._WaypointType;
            }

            set
            {
                if (this._WaypointType != value)
                {
                    this._WaypointType = value;
                    this.OnPropertyChanged("WaypointType");
                }
            }
        }
    }

    public class Stops1 : System.Collections.ObjectModel.ObservableCollection<StopsItem1>
    { 
    }

    public class FeedbackItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Stops2 _Stops = new Stops2();

        public Stops2 Stops
        {
            get
            {
                return this._Stops;
            }
        }

        private Time1 _Time = new Time1();

        public Time1 Time
        {
            get
            {
                return this._Time;
            }

            set
            {
                if (this._Time != value)
                {
                    this._Time = value;
                    this.OnPropertyChanged("Time");
                }
            }
        }
    }

    public class Feedback : System.Collections.ObjectModel.ObservableCollection<FeedbackItem>
    { 
    }

    public class StopsItem2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Name = string.Empty;

        public string Name
        {
            get
            {
                return this._Name;
            }

            set
            {
                if (this._Name != value)
                {
                    this._Name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        private string _WaypointType = string.Empty;

        public string WaypointType
        {
            get
            {
                return this._WaypointType;
            }

            set
            {
                if (this._WaypointType != value)
                {
                    this._WaypointType = value;
                    this.OnPropertyChanged("WaypointType");
                }
            }
        }
    }

    public class Stops2 : System.Collections.ObjectModel.ObservableCollection<StopsItem2>
    { 
    }

    public class Time1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Departure = string.Empty;

        public string Departure
        {
            get
            {
                return this._Departure;
            }

            set
            {
                if (this._Departure != value)
                {
                    this._Departure = value;
                    this.OnPropertyChanged("Departure");
                }
            }
        }

        private string _Arrival = string.Empty;

        public string Arrival
        {
            get
            {
                return this._Arrival;
            }

            set
            {
                if (this._Arrival != value)
                {
                    this._Arrival = value;
                    this.OnPropertyChanged("Arrival");
                }
            }
        }

        private string _Date = string.Empty;

        public string Date
        {
            get
            {
                return this._Date;
            }

            set
            {
                if (this._Date != value)
                {
                    this._Date = value;
                    this.OnPropertyChanged("Date");
                }
            }
        }
    }
#endif
}
