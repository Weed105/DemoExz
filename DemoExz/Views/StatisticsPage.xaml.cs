using Microsoft.EntityFrameworkCore;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

namespace DemoExz
{
    /// <summary>
    /// Логика взаимодействия для StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        public readonly DbTechnoserviceContext _technoserviceContext = new DbTechnoserviceContext();

        public StatisticsPage()
        {
            InitializeComponent();
            count.Content = _technoserviceContext.Applications.Where(a => a.Status == "Выполнено").Count();
            var executedApplications = _technoserviceContext.Applications.Where(a => a.Status == "Выполнено").ToList();
            if (executedApplications.Any())
            {
                var totalExecutionTimeInSeconds = executedApplications.Sum(a => a.ExecutionTime.Value.ToTimeSpan().TotalSeconds);
                avg.Content = TimeSpan.FromSeconds(totalExecutionTimeInSeconds / executedApplications.Count).ToString(@"hh\:mm");
            }
           
            List<Object> valuePairs = new List<Object>();
            foreach (TypeFault type in _technoserviceContext.TypeFaults.ToList())
            {
                valuePairs.Add(new { Type = type.Title, Count = _technoserviceContext.Applications.Count(a => a.TypeFaultNavigation == type) });
            }
            Faults.ItemsSource = valuePairs;
        }
    }
}
