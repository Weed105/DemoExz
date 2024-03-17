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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public readonly DbTechnoserviceContext _technoserviceContext = new DbTechnoserviceContext();

        public AuthPage()
        {
            InitializeComponent();
            Global.CurrentUser = new User();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new ListPage());

            var user = _technoserviceContext.Users.SingleOrDefault(u => u.Login == login.Text);
            if (user == null)
                MessageBox.Show("Неверный логин или пароль");
            else
            {
                if (user.Password.Equals(password.Password))
                {
                    Global.CurrentUser = user;

                    NavigationService.Navigate(new ListPage());
                }
                else
                    MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
