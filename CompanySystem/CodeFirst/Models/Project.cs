using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Project
    {
        [Key]
        public int PNum { get; set; }

        public string PName { get; set; }

        public string Location { get; set; }

        public string City { get; set; }

        [ForeignKey(nameof(Department))]
        public int DNum { get; set; }

        public Department Department { get; set; }  


    }
}
