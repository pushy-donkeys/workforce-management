using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace workforceManagement.Models
{
    public class TrainingProgram
    {
        [Key]
        public int TrainingProgramId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public int MaxAttendees { get; set; }
        public ICollection<TrainingPrgEmp> TrainingPrgEmp;


    }
}
