using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Employee
    {
        [Key]
        public int SSN {  get; set; }

        public string FName { get; set; }
        public string? LName { get; set; }

        public DateTime? Birthdate { get; set; }


        [ForeignKey(nameof(Department))]
        public int DNum { get; set; }

        public Department? Department { get; set; }


        [ForeignKey(nameof(SuperSsnNavigation))]
        public int SuperSsn { get; set; }

        public Employee? SuperSsnNavigation { get; set; }
        public List<Employee> InverseSuperSsnNavigation { get; set; }

        public List<Dependent> Dependents { get; set; }

        public List<EmployeesProject> EmployeesProjects { get; set; }

        public Department ManagedDepartment { get; set; }


    }
}
