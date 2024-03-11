using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoExz
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        private readonly GetData _getData ;

        public List<Application> apps {  get; set; }

        public ListPage()
        {
            InitializeComponent();
            ViewData();
            Applications.DataContext = apps;
        }

        public async void ViewData()
        {
            var context = await _getData.GetApplications();
            apps = context;
        }

        private void GoingToAddPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage());
        }

        private void GoingToChangePage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangePage());
        }
        private void GoingToStatisticsPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StatisticsPage());
        }
    }
}
