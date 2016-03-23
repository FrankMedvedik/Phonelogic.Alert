using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Phonelogic.Alert.ViewModel
{
    public class EntityBase : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        private readonly Dictionary<string, List<string>> _DataErrors = new Dictionary<string, List<string>>();

        public Dictionary<string, List<string>> DataErrors
        {
            get { return _DataErrors; }
        }

        #region INotifyDataErrorInfo Members

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors
        {
            get
            {
                return (from e in DataErrors
                    where e.Value.Count > 0
                    select e).Any();
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (DataErrors.ContainsKey(propertyName))
            {
                return DataErrors[propertyName];
            }
            return DataErrors.Values;
        }

        protected virtual void OnErrorsChanged(string property)
        {
            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(property));
                NotifyPropertyChanged("HasErrors");
            }
        }

        protected bool ValidateRequiredString(string propName, string value, string errorText)
        {
            //Clear any existing errors since we're revalidating now
            if (DataErrors.ContainsKey(propName))
                DataErrors[propName].Remove(errorText);

            if (string.IsNullOrEmpty(value))
            {
                AddError(propName, errorText);
                return false;
            }

            OnErrorsChanged(propName);
            return true;
        }

        protected bool ValidateStringLength(string propName, string value, int len)
        {
            string errorText = "Value must be < " + len.ToString() + " chars!";
            //Clear any existing errors since we're revalidating now
            if (DataErrors.ContainsKey(propName))
                DataErrors[propName].Remove(errorText);

            if (value.Length > len)
            {
                AddError(propName, errorText);
                return false;
            }

            OnErrorsChanged(propName);
            return true;
        }

        protected void AddError(string propName, string errorText)
        {
            EnsureErrorList(propName);
            if (DataErrors[propName].SingleOrDefault(e => e == errorText) == null)
                DataErrors[propName].Add(errorText);
            OnErrorsChanged(propName);
        }

        private void EnsureErrorList(string propertyName)
        {
            if (!DataErrors.ContainsKey(propertyName))
            {
                DataErrors[propertyName] = new List<string>();
            }
        }

        protected void RemoveDataErrors(string propertyName)
        {
            if (DataErrors.ContainsKey(propertyName))
            {
                DataErrors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnNotifyPropertyChanged(string propName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propName));
        //    }
        //}

        protected void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            var e = PropertyChanged;
            if (e != null) e(this, new PropertyChangedEventArgs(name));
        }


        #endregion
    }
}
