using System.Windows;
using GalaSoft.MvvmLight.Threading;
using Hardcodet.Wpf.TaskbarNotification;


namespace Phonelogic.Alert
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
 
        static App()
        {
         DispatcherHelper.Initialize();
        }

        public TaskbarIcon MyNotifyIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //create the notifyicon (it's a resource declared in NotifyIconResources.xaml
            MyNotifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            MyNotifyIcon.Dispose(); //the icon would clean up automatically, but this is cleaner
            base.OnExit(e);
        }
    }
}
