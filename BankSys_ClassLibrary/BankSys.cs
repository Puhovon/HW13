using System.Collections.Generic;
using System.Linq;
using HW13;
using HW13.Accounts;
using HW13.Utils;

namespace BankSys_ClassLibrary
{
    public class BankSys : Singleton<BankSys>
    {
        private List<Client> _clients = new List<Client>();
        public List<Client> Clients
        {
            get => _clients;
            set => _clients = value;
        }
        public List<Account> Accounts => Clients.SelectMany(t => t.Accounts).ToList();
        protected override void Init()
        {
            for (int i = 0; i < 10; i++)
            {
                var client = new Client
                {
                    Name = NameGenerator.RandomName,
                    Phone = string.Join("", "1234567890".ToCharArray().Select(t => Randomizer.Next(0, 9).ToString())),
                    PersonalConditions = new HW13.Data.PersonalConditions(),
                };
                var account = new CommonAccount
                {
                    Owner = client,
                };
                account = (CommonAccount)(account + Randomizer.Next(1, 30) * 25);
                client.Accounts.Add(account);
                Clients.Add(client);
            }
        }
    }
}
