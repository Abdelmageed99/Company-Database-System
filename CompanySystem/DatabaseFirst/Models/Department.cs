using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class Department
{
    public int Dnum { get; set; }

    public string Dname { get; set; } = null!;

    public int? ManagerId { get; set; }

    public DateOnly? Hiredate { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual Employee? Manager { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
