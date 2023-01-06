using System;

namespace BankSys_ClassLibrary.Accounts
{
    [Serializable]
    internal class NotEnoughMoneyEx : Exception
    {
        public Client Client;
        public NotEnoughMoneyEx(Account account, decimal amount)
            : base($"{account.Owner.Name}: trying to send {amount} rub. from {account.Id} with {account.moneyString} deposit.")
        {
            Client = account.Owner;
        }
    }
        
}