using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HW13.DataContext
{
    public class ChooseClientPageContext : PageDataContext
    {
        private bool _validAmount;

        private bool _recieverSelected;

        public Client Sender;

        public Type AccountType;

        public bool CanSend => _validAmount && _recieverSelected;

        public Visibility CanSendVisibility => CanSend? Visibility.Visible : Visibility.Hidden;

        public List<Client> Accounts { get; set; }

        public decimal AmountToSend;

        public string AmountToSendString
        {
            get => AmountToSend.ToString();
            set
            {
                _validAmount = decimal.TryParse(value, out AmountToSend);
                OnPropertyChanged("CanSendVisibility");
            }
        }

        public Client Receiver
        {
            set
            {
                _recieverSelected = true;
                OnPropertyChanged("CanSendVisibility");
            }
        }
    }
}
