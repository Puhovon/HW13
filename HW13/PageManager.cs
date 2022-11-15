using HW13.DataContext;
using HW13.Utils;
using System.Windows.Controls;

namespace HW13
{
    public class PageManager : Singleton<PageManager>
    {
        public Frame Frame;
        protected override void Init() { }

        public void Load<T>(PageDataContext dataContext)
            where T : Page, new()
        {
            Page page = new T
            {
                DataContext = dataContext
            };
            Frame.NavigationService.Navigate(page);
        }
    }
}
