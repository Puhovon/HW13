using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.DataContext
{
    public class ClientPageContext : PageDataContext
    {
        public Client Client { get; set; }

        public void AddAccount<T>()
            where T : Accounts.Account, new()
        {
            Client.AddAccount<T>();
        }
        public void DeleteAccount<T>()
            where T : Accounts.Account
        {
            Client.DeleteAccount<T>();
        }
        public void AddQuartet<T>()
            where T : Accounts.Account
        {
            var account = Client.GetAccount<T>();
            if (account != null)
            {
                account += 250;
            }
        }
    }
}
