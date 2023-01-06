using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HW13.Accounts
{
    public abstract class Account : INotifyPropertyChanged
    {

        public Guid Id = Guid.NewGuid();
        public Client Owner;
        protected decimal _depositMoney = 0;
        public decimal money => _depositMoney;
        public string moneyString => _depositMoney.ToString("C");
        public void SendMoney(Account account, decimal amount)
        {
            if (_depositMoney < amount)
            {
                throw new NotEnoughMoneyEx(account, amount);
            }
            AddMoney(-amount);
            account.AddMoney(amount);
            MoneyTransfer?.Invoke(this, account, amount);
        }
        public static Account operator +(Account target, decimal amount)
        {
            target.AddMoney(amount);
            return target;
        }
        public void AddMoney(decimal amount)
        {
            _depositMoney += amount;
            OnPropertyChanged("MoneyString");
            MoneyAdd?.Invoke(this, amount);
        }
        public event MoneyTransferDelegate MoneyTransfer;

        public event MoneyAddDelegate MoneyAdd;

        public delegate void MoneyTransferDelegate(Account from, Account to, decimal amount);

        public delegate void MoneyAddDelegate(Account to, decimal amount);

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
