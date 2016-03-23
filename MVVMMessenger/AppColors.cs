using System.Windows.Media;
using GalaSoft.MvvmLight;

namespace Phonelogic.Alert.MVVMMessenger
{
   public class AppColors : ObservableObject
    {
        /// <summary>
        /// The <see cref="TheForeground" /> property's name.
        /// </summary>
        public const string TheForegroundPropertyName = "TheForeground";

        private Brush _theForeground = new SolidColorBrush(Colors.Black);

        /// <summary>
        /// Sets and gets the TheForeground property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Brush TheForeground
        {
            get
            {
                return _theForeground;
            }

            set
            {
                if (_theForeground == value)
                {
                    return;
                }

                _theForeground = value;
                RaisePropertyChanged(TheForegroundPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="TheBackground" /> property's name.
        /// </summary>
        public const string TheBackgroundPropertyName = "TheBackground";

        private Brush _theBackground = new SolidColorBrush(Colors.LightGray);


        /// <summary>
        /// Sets and gets the TheBackground property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Brush TheBackground
        {
            get
            {
                return _theBackground;
            }

            set
            {
                if (_theBackground == value)
                {
                    return;
                }

                _theBackground = value;
                RaisePropertyChanged(TheBackgroundPropertyName);
            }
        }

        
    }
}
