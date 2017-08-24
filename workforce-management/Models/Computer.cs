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
        [Required]
        public DateTime CommissionDate { get; set; }
        public DateTime? DecommisionDate { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public ICollection<ComputerEmp> ComputerEmp { get; set; }
    }
}
