using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Examples.Design.Anderson.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual bool SetProperty<T>(ref T? field, T? value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value)) { return false; }

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            return true;
        }
    }
}