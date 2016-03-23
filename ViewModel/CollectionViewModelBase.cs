using System;
using System.Runtime.CompilerServices;
using Phonelogic.Alert.MVVMBaseTypes;

namespace Phonelogic.Alert.ViewModel
{
    public abstract class CollectionViewModelBase : ViewModelBase
    {
        private System.Windows.Threading.DispatcherTimer _timer;

        public CollectionViewModelBase()
        {
            LoadedOk = true;
        }
        protected void StartAutoRefresh(int refreshIntervalInSeconds)
        {
            _timer = new System.Windows.Threading.DispatcherTimer();
            _timer.Tick += new EventHandler(RefreshAll);
            _timer.Interval = new TimeSpan(0, 0, refreshIntervalInSeconds);
            _timer.Start();
        }

        protected void StopAutoRefresh()
        {
            _timer.Tick -= RefreshAll;
            _timer.Stop();
        }

        protected abstract void RefreshAll(object sender, EventArgs e);

        public void RefreshAll()
        {
            this.RefreshAll(null, null);
        }

        private String _DataStatusHeadingMsg = "";
        public String DataStatusHeadingMsg
        {
            get { return _DataStatusHeadingMsg; }
            set
            {
                _DataStatusHeadingMsg = value;
                NotifyPropertyChanged();
            }
        }

        private String _DataStatusMsg ="";
        public String DataStatusMsg
        {
            get { return _DataStatusMsg; }
            set
            {
                _DataStatusMsg = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _showGridData;
        public Boolean ShowGridData
        {
            get { return _showGridData; }
            set
            {
                _showGridData = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime _loadDate;
        public DateTime LoadDate
        {
            get { return _loadDate; }
            set
            {
                _loadDate = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _showLoadDatetimeHeading = false;

        public Boolean ShowLoadDatetimeHeading
        {
            get { return _showLoadDatetimeHeading; }
            set
            {
                _showLoadDatetimeHeading = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _loadedOk;
        public Boolean LoadedOk
        {
            get { return _loadedOk; }
            set
            {
                _loadedOk = value;
                NotifyPropertyChanged();
            }
        }

        private string _loadError;
        public string LoadError
        {
            get { return _loadError; }
            set
            {
                _loadError = value;
                NotifyPropertyChanged();
            }
        }

        private string _loadMethod;
        public string LoadMethod
        {
            get { return _loadMethod; }
            set
            {
                _loadMethod = value;
                NotifyPropertyChanged();
            }
        }

        protected void LoadFailed(Exception e, [CallerMemberName] string name = null)
        {
            LoadMethod = name;
            LoadedOk = false;
            LoadError = e.Message;
            if (e.InnerException != null)
                if (!String.IsNullOrEmpty(e.InnerException.Message))
                    LoadError = LoadError + e.InnerException.Message;

        }
    }
}