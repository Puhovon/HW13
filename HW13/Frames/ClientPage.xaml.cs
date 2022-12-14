using HW13.Accounts;
using HW13.DataContext;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HW13.Frames
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        private ClientPageContext _ctx => DataContext as ClientPageContext;
        public ClientPage()
        {
            InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            PageManager.I.Load<Index>(new IndexContext());
        }

        /// <summary>
        /// Show dialog box with a question
        /// </summary>
        /// <param name="message">Question to ask</param>
        /// <returns>Returns true if user has clicked Yes</returns>
        private bool Ask(string message)
        {
            var response = MessageBox.Show(message, "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            return response == MessageBoxResult.Yes;
        }

        /// <summary>
        /// Create common account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _ctx.AddAccount<CommonAccount>();
        }

        /// <summary>
        /// Delete common account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if (!Ask("Delete account?")) return;
            _ctx.DeleteAccount<CommonAccount>();
        }

        /// <summary>
        /// Add some money to account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonAdd25(object sender, RoutedEventArgs e)
        {
            _ctx.AddQuartet<CommonAccount>();
        }

        /// <summary>
        /// Send money to another client's common account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonSend(object sender, RoutedEventArgs e)
        {
            PageManager.I.Load<ChooseClientPage>(new ChooseClientPageContext
            {
                Sender = _ctx.Client,
                AccountType = typeof(CommonAccount),
                Accounts = BankSysCore.I.Clients
                    .Where(t => t != _ctx.Client && t.GetAccount<CommonAccount>() != null)
                    .ToList(),
            });
        }

        /// <summary>
        /// Create deposit account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _ctx.AddAccount<DepositAccount>();
        }

        /// <summary>
        /// Delete deposit account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if (!Ask("Delete account?")) return;
            _ctx.DeleteAccount<DepositAccount>();
        }

        /// <summary>
        /// Add some money to deposit account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositAdd25(object sender, RoutedEventArgs e)
        {
            _ctx.AddQuartet<DepositAccount>();
        }

        /// <summary>
        /// Send money to another client's deposit account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositSend(object sender, RoutedEventArgs e)
        {
            PageManager.I.Load<ChooseClientPage>(new ChooseClientPageContext
            {
                Sender = _ctx.Client,
                AccountType = typeof(DepositAccount),
                Accounts = BankSysCore.I.Clients
                    .Where(t => t != _ctx.Client && t.GetAccount<DepositAccount>() != null)
                    .ToList(),
            });
        }
    }
}
