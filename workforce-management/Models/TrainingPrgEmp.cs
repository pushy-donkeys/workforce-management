using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace workforceManagement.Models
{
    public class TrainingPrgEmp
    {
        [Key]
        public int TrainingPrgEmpId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public int TrainingProgramId { get; set; }
        public TrainingPrgEmp TrainingProgram { get; set; }
    }
}
