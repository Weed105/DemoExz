using System;
using System.Collections.Generic;

namespace DemoExz;

public partial class Equipment
{
    public int Idequipment { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
