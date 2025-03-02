using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class EmoloyeesProject
{
    public int EmployeeSsn { get; set; }

    public int ProjectNum { get; set; }

    public int? WorkingHours { get; set; }

    public virtual Employee EmployeeSsnNavigation { get; set; } = null!;

    public virtual Project ProjectNumNavigation { get; set; } = null!;
}
