using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace workforceManagement.Models
{
    public class Computer
    {
        [Key]
        public int ComputerId { get; set; }
        public DateTime CommissionDate { get; set; }
        public string Make { get; set; }
        public string Manufacturer { get; set; }
        public ICollection<ComputerEmp> ComputerEmp;
    }
}
