using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace workforceManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public DateTime Startdate { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<TrainingPrgEmp> TrainingPrgEmp;
        public ICollection<ComputerEmp> ComputerEmp;
    }
}
