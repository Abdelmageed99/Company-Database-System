using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Department
    {
        [Key]
        public int DNum { get; set; }
        public string DName { get; set; }

        [ForeignKey(nameof(Manager))]
        public int ManagerId { get; set; }

        public Employee Manager { get; set; }

        public List<Employee>? Employees { get; set; }
        public DateTime HireDate { get; set; }

        public List<Project>? Projects { get; set; }
    }
}
