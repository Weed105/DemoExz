using System;
using System.Collections.Generic;

namespace DemoExz;

public partial class TypeFault
{
    public int IdtypeFault { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
