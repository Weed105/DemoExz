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
    }
}
