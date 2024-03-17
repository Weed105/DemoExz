using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExz
{
    class Global
    {
        public static User CurrentUser { get; set; } = new User
        {
            Iduser = 0,
            Surname = string.Empty,
            Name = string.Empty,
            Patronymic = string.Empty,
            Login= string.Empty,
            Password = string.Empty,
            Role = string.Empty,
        };

        public static Application SelectedApplication { get; set; }
    }
}
