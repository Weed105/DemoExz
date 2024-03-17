using MaterialDesignColors;
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
        public List<string> Params { get; set; } =new ();
        public readonly DbTechnoserviceContext _technoserviceContext = new DbTechnoserviceContext();

        public ListPage()
        {
            InitializeComponent();
            GetApplications();
            DataContext = this;

            //var bindingPaths = Applications.Columns.Select(column => ((Binding)(column as DataGridBoundColumn).Binding).Path.Path);

            for (int i = 0; i < Applications.Columns.Count; i++)
            {
                Params.Add(Applications.Columns[i].Header.ToString());
            }
        }

        public async void GetApplications()
        {
            var applicationsDb = _technoserviceContext.Applications.ToList();
            _technoserviceContext.Equipment.ToList();
            _technoserviceContext.TypeFaults.ToList();
            _technoserviceContext.Users.ToList();

            if (Global.CurrentUser.Role == "Исполнитель")
            {
                AddButton.Visibility = Visibility.Collapsed;
                Applications.ItemsSource = applicationsDb.Where(a=> a.Executor == Global.CurrentUser.Iduser).ToList();
            }
            else
            {
                AddButton.Visibility = Visibility.Visible;
                Applications.ItemsSource = applicationsDb;
            }
        }

        private void GoingToAddPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage());
        }

        private void GoingToChangePage(object sender, RoutedEventArgs e)
        {
            if (Applications.SelectedItem != null)
            {
                Global.SelectedApplication = (Application)Applications.SelectedItem;

                if (Global.CurrentUser.Role == "Исполнитель")
                    NavigationService.Navigate(new WorkPage());
                else
                    NavigationService.Navigate(new ChangePage());
            }
            else
                MessageBox.Show("Выберите заявку для изменения", "Внимание");
        }
        private void GoingToStatisticsPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StatisticsPage());
        }

        private void SerchClick(object sender, RoutedEventArgs e)
        {
            var applicationsDb = _technoserviceContext.Applications.ToList();
            if (Global.CurrentUser.Role == "Исполнитель")
                applicationsDb = applicationsDb.Where(a => a.Executor == Global.CurrentUser.Iduser).ToList();
            else
                applicationsDb = _technoserviceContext.Applications.ToList();


            if (!Search.Text.Equals(""))
            {
                Applications.ItemsSource = applicationsDb.Where(p => p.EquipmentNumber.Contains(Search.Text.ToLower().Trim())).ToList();
            }
            else
            {
                Applications.ItemsSource = applicationsDb;

            }
        }
    }
}
