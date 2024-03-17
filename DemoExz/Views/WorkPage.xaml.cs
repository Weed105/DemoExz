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
    /// Логика взаимодействия для WorkPage.xaml
    /// </summary>
    public partial class WorkPage : Page
    {
        public DateTime Today { get; } = DateTime.Now;
        public DbTechnoserviceContext dbTechnoservice = new DbTechnoserviceContext();

        public List<string> Statuses { get; set; } = new List<string>
        {
            "В ожидании",
            "В работе",
            "Выполнено"
        };

        public WorkPage()
        {
            InitializeComponent();
            DataContext = this;
            Status.SelectedItem = Global.SelectedApplication.Status;

            Description.Document.Blocks.Clear();
            Description.Document.Blocks.Add(new Paragraph(new Run(Global.SelectedApplication.DescriptionProblem)));

            comment.Document.Blocks.Clear();
            comment.Document.Blocks.Add(new Paragraph(new Run(Global.SelectedApplication.Comment)));

            Cost.Text = Global.SelectedApplication.Cost.ToString();
            if (Global.SelectedApplication.ExecutionTime.HasValue)
                timeWork.SelectedTime = new DateTime(Global.SelectedApplication.ExecutionTime.Value.Ticks);


        }

        private void ChangeApplication(object sender, RoutedEventArgs e)
        {
            string description = new TextRange(Description.Document.ContentStart, Description.Document.ContentEnd).Text;
            string comm = new TextRange(comment.Document.ContentStart, comment.Document.ContentEnd).Text;
            if (!Status.Text.Equals("") && !comm.Equals("") && !description.Equals("") && !Cost.Text.Equals("") && timeWork.SelectedTime.HasValue)
            {
                Application application = dbTechnoservice.Applications.Where(i => i.Idapplication == Global.SelectedApplication.Idapplication).FirstOrDefault();

                application.Status = Status.Text;
                application.DescriptionProblem = description;
                application.Comment = comm;
                application.Cost = int.Parse(Cost.Text);
                application.ExecutionTime = new TimeOnly(timeWork.SelectedTime.Value.Hour, timeWork.SelectedTime.Value.Minute);
                application.DateCompletion = new DateOnly(Today.Year, Today.Month, Today.Day);

                dbTechnoservice.SaveChanges();
                MessageBox.Show("Изменения сохранены", "Внимание");
                NavigationService.Navigate(new ListPage());

            }

            else
            {
                MessageBox.Show("Заполните все поля", "Внимание");
            }
        }
    }
}
