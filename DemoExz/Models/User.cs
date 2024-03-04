using System;
using System.Collections.Generic;

namespace DemoExz;

public partial class User
{
    public int Iduser { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
