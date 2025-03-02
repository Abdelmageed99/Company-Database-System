using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class Project
{
    public int Pnum { get; set; }

    public string Pname { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string? City { get; set; }

    public int Dnum { get; set; }

    public virtual Department DnumNavigation { get; set; } = null!;

    public virtual ICollection<EmoloyeesProject> EmoloyeesProjects { get; set; } = new List<EmoloyeesProject>();
}
