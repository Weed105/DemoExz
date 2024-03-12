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

        public readonly DbTechnoserviceContext _technoserviceContext = new DbTechnoserviceContext();


        public ListPage()
        {
            InitializeComponent();
            GetApplications();
        }

        public async void GetApplications()
        {
            var applicationsDb = _technoserviceContext.Applications.ToList();
            _technoserviceContext.Equipment.ToList();
            _technoserviceContext.TypeFaults.ToList();
            _technoserviceContext.Users.ToList();

            Applications.ItemsSource = applicationsDb;
            //MessageBox.Show(applicationsDb[0].EquipmentNavigation.Title);
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
