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

        private Route _Route = new Route();

        public Route Route
        {
            get
            {
                return this._Route;
            }

            set
            {
                if (this._Route != value)
                {
                    this._Route = value;
                    this.OnPropertyChanged("Route");
                }
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
    }

    public class Route : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _BeginStation = string.Empty;

        public string BeginStation
        {
            get
            {
                return this._BeginStation;
            }

            set
            {
                if (this._BeginStation != value)
                {
                    this._BeginStation = value;
                    this.OnPropertyChanged("BeginStation");
                }
            }
        }

        private string _EndStation = string.Empty;

        public string EndStation
        {
            get
            {
                return this._EndStation;
            }

            set
            {
                if (this._EndStation != value)
                {
                    this._EndStation = value;
                    this.OnPropertyChanged("EndStation");
                }
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

        private Departure _Departure = new Departure();

        public Departure Departure
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
    }

    public class Days : System.Collections.ObjectModel.ObservableCollection<DaysItem>
    { 
    }

    public class Departure : INotifyPropertyChanged
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
#endif
}
