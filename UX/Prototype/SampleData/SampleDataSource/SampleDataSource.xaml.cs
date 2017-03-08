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

        private string _DepartureTime = string.Empty;

        public string DepartureTime
        {
            get
            {
                return this._DepartureTime;
            }

            set
            {
                if (this._DepartureTime != value)
                {
                    this._DepartureTime = value;
                    this.OnPropertyChanged("DepartureTime");
                }
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
#endif
}
