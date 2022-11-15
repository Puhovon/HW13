using HW13.DataContext;
using System.Windows.Controls;

namespace HW13.Frames
{
    /// <summary>
    /// Логика взаимодействия для Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        public Index()
        {
            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PageManager.I.Load<ClientPage>(new ClientPageContext
            {
                Client = ClientsList.SelectedItem as Client,
            });
        }
    }
}
