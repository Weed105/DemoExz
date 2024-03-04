using System;
using System.Collections.Generic;

namespace DemoExz;

public partial class Application
{
    public int Idapplication { get; set; }

    public DateOnly? DateAddition { get; set; }

    public int? Equipment { get; set; }

    public string? EquipmentNumber { get; set; }

    public string? EquipmentName { get; set; }

    public int? TypeFault { get; set; }

    public string? DescriptionProblem { get; set; }

    public string? Client { get; set; }

    public string? Status { get; set; }

    public int? Executor { get; set; }

    public string? Comment { get; set; }

    public TimeOnly? ExecutionTime { get; set; }

    public DateOnly? DateCompletion { get; set; }

    public int? Cost { get; set; }

    public virtual Equipment? EquipmentNavigation { get; set; }

    public virtual User? ExecutorNavigation { get; set; }

    public virtual TypeFault? TypeFaultNavigation { get; set; }
}
