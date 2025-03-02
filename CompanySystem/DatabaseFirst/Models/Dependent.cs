using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class Dependent
{
    public int EmployeeSsn { get; set; }

    public string DependentId { get; set; } = null!;

    public string DependentName { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? Birthdate { get; set; }

    public virtual Employee EmployeeSsnNavigation { get; set; } = null!;
}
