using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class Employee
{
    public int Ssn { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? Birthdate { get; set; }

    public int? Dnum { get; set; }

    public int? SuperSsn { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();

    public virtual Department? DnumNavigation { get; set; }

    public virtual ICollection<EmoloyeesProject> EmoloyeesProjects { get; set; } = new List<EmoloyeesProject>();

    public virtual ICollection<Employee> InverseSuperSsnNavigation { get; set; } = new List<Employee>();

    public virtual Employee? SuperSsnNavigation { get; set; }
}
