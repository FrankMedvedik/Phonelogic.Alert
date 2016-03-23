using System.Windows;
using System.Windows.Controls;

namespace Phonelogic.Alert
{
    public partial class MyCallsInQueueView : UserControl
    {
        private Phonelogic.Alert.ViewModel.MyCallsInQueueViewModel _vm;
        
        public MyCallsInQueueView()
        {
            
            InitializeComponent();
            _vm = new Phonelogic.Alert.ViewModel.MyCallsInQueueViewModel();
            DataContext = _vm;

        }
        
        private async void btnTakeCall_Click(object sender, System.Windows.RoutedEventArgs e)
        {

                if (_vm.SelectedCallInQueue == null) return;
                await LyncSvc.PullFromQueue(_vm.SelectedCallInQueue.Id);
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
            
        }

        public string TheForeground
        {
            get { return (string)GetValue(TheForegroundProperty); }
        }
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TheForegroundProperty =
            DependencyProperty.Register("TheForeground", typeof(string), typeof(MyCallsInQueueView), new PropertyMetadata("Black"));

        public string TheBackground
        {
            get { return _vm.TheBackground; }
        }
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TheBackgroundProperty =
            DependencyProperty.Register("TheBackground", typeof(string), typeof(MyCallsInQueueView), new PropertyMetadata("#a6dbed"));

        }
}
