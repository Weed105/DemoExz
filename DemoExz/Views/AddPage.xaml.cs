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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public List<string> Types_Equipment { get; set; } = new();
        public List<string> Types_Faults { get; set; } = new();
        public List<string> Executors { get; set; } = new();

        public DateTime Today { get; } = DateTime.Now;
        public DbTechnoserviceContext dbTechnoservice = new DbTechnoserviceContext();

        public AddPage()
        {
            InitializeComponent();
            DataContext = this;

            var types_equipment = dbTechnoservice.Equipment.ToList();
            var types_faults = dbTechnoservice.TypeFaults.ToList();
            var executors = dbTechnoservice.Users.ToList();
             
            if (Types_Equipment.Count == 0)
            {
                foreach (var type in types_equipment)
                
                    Types_Equipment.Add(type.Title);
                
                foreach (var type in types_faults)
                
                    Types_Faults.Add(type.Title);

                foreach (var user in executors)
                    if (user.Role == "Исполнитель")
                        Executors.Add($"{user.Name} {user.Surname}");
                
            }
        }

        private void AddApplication(object sender, RoutedEventArgs e)
        {
            string description = new TextRange(Description.Document.ContentStart, Description.Document.ContentEnd).Text;
            if (!Client.Text.Equals("") && !TypeEquipment.Text.Equals("") && !NameEquipment.Text.Equals("") && !TypeFault.Text.Equals("") && !Executor.Text.Equals("") && !description.Equals(""))
            {
                Application application = new Application
                {
                    Idapplication = dbTechnoservice.Applications.Max(i => i.Idapplication) + 1,
                    DateAddition = new DateOnly(Today.Year, Today.Month, Today.Day),
                    Equipment = dbTechnoservice.Equipment.Where(i => i.Title.Equals(TypeEquipment.Text)).SingleOrDefault().Idequipment,
                    EquipmentName = NameEquipment.Text,
                    TypeFault = dbTechnoservice.TypeFaults.Where(i => i.Title.Equals(TypeFault.Text)).SingleOrDefault().IdtypeFault,
                    DescriptionProblem = description,
                    Client = Client.Text,
                    Status = "В ожидании",
                    Executor = dbTechnoservice.Users.Where(i => i.Name.Equals(Executor.Text.Split()[0]) && i.Surname.Equals(Executor.Text.Split()[1])).SingleOrDefault().Iduser,
                };
                dbTechnoservice.Applications.Add(application);
                dbTechnoservice.SaveChanges();
                MessageBox.Show("Заявка добавлена", "Внимание");
                NavigationService.Navigate(new ListPage());
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Внимание");
            }
        }

    }
}
