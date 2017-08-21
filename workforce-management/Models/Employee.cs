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
        [Display(Name ="First Name")]
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [Required]
        [Display(Name ="Start Date")]
        public DateTime Startdate { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<TrainingPrgEmp> TrainingPrgEmp { get; set; }
        public ICollection<ComputerEmp> ComputerEmp { get; set; }
    }
}
