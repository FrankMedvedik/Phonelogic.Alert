using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Allows you to obtain the method or property name of the caller.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Parameter, Inherited = false)]
    public sealed class CallerMemberNameAttribute : Attribute { }
}

namespace Phonelogic.Alert.MVVMBaseTypes
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

     protected void NotifyPropertyChanged([CallerMemberName] string name = null)
      {
        var e = PropertyChanged;
        if (e != null) e(this, new PropertyChangedEventArgs(name));
      }

      public event PropertyChangedEventHandler PropertyChanged;
    }
}