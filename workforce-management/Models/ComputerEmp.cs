using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace workforceManagement.Models
{
    public class ComputerEmp
    {
        [Key]
        public int ComputerEmpId { get; set; }
        public int ComputerId { get; set; }
        public Computer Computer { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
