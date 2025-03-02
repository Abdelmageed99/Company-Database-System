using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public  class Location
    {
        public int LocationID {  get; set; }
        public string LocationName { get; set; }

        [ForeignKey(nameof(Department))]
        public int DNum { get; set; }
        public Department Department { get; set; }
    }
}
