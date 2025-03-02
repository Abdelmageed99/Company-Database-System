using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Dependent
    {
        [ForeignKey(nameof(Employee))]
        public int SSN {  get; set; }
        public int DependentID {  get; set; }
        public string DependentName {  get; set; }

        public char Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public Employee? Employee { get; set; }


    }
}
