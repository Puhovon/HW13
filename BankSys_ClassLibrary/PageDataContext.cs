using System.ComponentModel;
using System.Runtime.CompilerServices;
using BankSys_ClassLibrary;

namespace HW13.DataContext
{
    public abstract class PageDataContext : INotifyPropertyChanged
    {

        public BankSys BankSystem => BankSys.I;

        public BankSys BankSys => BankSys.I;


        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
