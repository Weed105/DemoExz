using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Логика взаимодействия для ChangePage.xaml
    /// </summary>
    public partial class ChangePage : Page
    {
        public List<string> Statuses { get; set; } = new List<string>
        {
            "В ожидании",
            "В работе",
            "Выполнено"
        };
        public List<string> Executors { get; set; } = new();
        public DbTechnoserviceContext dbTechnoservice = new DbTechnoserviceContext();

        public ChangePage()
        {
            InitializeComponent();
            DataContext = this;

            var executors = dbTechnoservice.Users.ToList();
            if (Executors.Count == 0)
            {
                foreach (var user in executors)
                    if (user.Role == "Исполнитель")
                        Executors.Add($"{user.Name} {user.Surname}");
            }
            Status.SelectedItem = Global.SelectedApplication.Status;
            ExecutorChange.SelectedItem = Global.SelectedApplication.ExecutorNavigation.Name + " " + Global.SelectedApplication.ExecutorNavigation.Surname;

            Description.Document.Blocks.Clear();
            Description.Document.Blocks.Add(new Paragraph(new Run(Global.SelectedApplication.DescriptionProblem)));

        }

        private void ChangeApplication(object sender, RoutedEventArgs e)
        {
            string description = new TextRange(Description.Document.ContentStart, Description.Document.ContentEnd).Text;
            if (!Status.Text.Equals("") && !ExecutorChange.Text.Equals("") && !description.Equals(""))
            {
                Application application = dbTechnoservice.Applications.Where(i => i.Idapplication == Global.SelectedApplication.Idapplication).FirstOrDefault();
                application.Status = Status.Text;
                application.Executor = dbTechnoservice.Users.Where(i => i.Name.Equals(ExecutorChange.Text.Split()[0]) && i.Surname.Equals(ExecutorChange.Text.Split()[1])).SingleOrDefault().Iduser;
                application.DescriptionProblem = new TextRange(Description.Document.ContentStart, Description.Document.ContentEnd).Text;
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
