using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class EmployeesProject
    {
        [ForeignKey(nameof(Employee))]
        public int SSN { get; set; }

        [ForeignKey(nameof(Project))]
        public int PNum { get; set; }

        public int WorkingHours { get; set; }

        public Employee Employee { get; set; }

        public Project Project { get; set; }
    }
}
