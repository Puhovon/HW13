using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HW13.DataContext
{
    public abstract class PageDataContext : INotifyPropertyChanged
    {
        public BankSysCore BankSystem => BankSysCore.I;

        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
