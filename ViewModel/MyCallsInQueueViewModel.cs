using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls.Primitives;
using GalaSoft.MvvmLight.Messaging;
using Hardcodet.Wpf.TaskbarNotification;
using Phonelogic.Alert.Configuration;
using Phonelogic.Alert.Model;
using Phonelogic.Alert.Services;
using AppColors = Phonelogic.Alert.MVVMMessenger.AppColors;

namespace Phonelogic.Alert.ViewModel
    
{
    public class MyCallsInQueueViewModel : CollectionViewModelBase
    {
        public MyCallsInQueueViewModel()
        {
         StartAutoRefresh(ApiRefreshFrequency.LyncApi);
        }

        private CallInQueue _selectedCallInQueue;
        public CallInQueue SelectedCallInQueue
        {
            get { return _selectedCallInQueue; }
            set
            {
                _selectedCallInQueue = value;
                NotifyPropertyChanged();
            }
        }
        protected override void RefreshAll(object sender, EventArgs e)
        {
           GetMyQueuedCalls();
        }
        public async void GetMyQueuedCalls()
        {
            try
            {
                LoadDate = DateTime.Now;
                //var cq = await LyncSvc.GetMyQueuedCalls();
                var cq = await LyncSvc.GetMyTestDataCalls();

                if (cq.Count > 0)
                {
                    CallsInQueue = new ObservableCollection<CallInQueue>(cq.Select(c => new CallInQueue()
                    {
                        CallerId = c.CallerId,
                        Id = c.Id,
                        JobNumber = c.JobNumber,
                        TimeIn = c.TimeIn
                    }).ToList());

                    ShowGridData = true;
                    ShowBalloon();
                }
                else
                {
                    ShowGridData = false;
                    CloseBalloon();
                }
                LoadedOk = true;

            }
            catch (Exception e)
            {
                LoadFailed(e);
            }
        }

        #region CallsInQueue

        private ObservableCollection<CallInQueue> _CallsInQueue = new ObservableCollection<CallInQueue>();

        public ObservableCollection<CallInQueue> CallsInQueue
         {
             get { return _CallsInQueue; }
             set
             {
                _CallsInQueue = value;
                 NotifyPropertyChanged();
                 AppColors ac = new AppColors()
                 {
                     TheForeground = ColorToBrushSvc.GetForeground(CallsInQueue.Count),
                     TheBackground = ColorToBrushSvc.GetBackground(CallsInQueue.Count)
                 };
                NotifyPropertyChanged("TheForeground");
                NotifyPropertyChanged("TheBackground");
                Messenger.Default.Send(ac);
             }
         }
        #endregion

         #region DisplayColors

         public  string TheBackground
        {
            get
            {
                return ColorMappingSvc.GetBackground(CallsInQueue.Count);
            }
        }

        public string TheForeground
        {
            get {
                return ColorMappingSvc.GetForeground(CallsInQueue.Count);
            }
        }

        public void ShowBalloon()
        {
            if (!BallonVisible)
            {
                BallonVisible = true;
                UserBalloon balloon = new UserBalloon();
                TaskbarIcon MyNotifyIcon = (TaskbarIcon) App.Current.Resources["NotifyIcon"];
                MyNotifyIcon.ShowCustomBalloon(balloon, PopupAnimation.Slide, null);
            }
        }
        public void CloseBalloon()
        {
            if (BallonVisible)
            {
                BallonVisible = false;
                TaskbarIcon MyNotifyIcon = (TaskbarIcon)App.Current.Resources["NotifyIcon"];
                MyNotifyIcon.CloseBalloon();
            }
        }


        public bool BallonVisible { get; set; }

        public new Boolean ShowGridData
        {
            set
            {
                base.ShowGridData = value;
            }
            get { return base.ShowGridData; }
        }


        #endregion

    }
}


