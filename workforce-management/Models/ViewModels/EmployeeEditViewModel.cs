using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workforceManagement.Models.ViewModels
{
    public class EmployeeEditViewModel
    {
        public List<Computer> Comp { get; set; }
        public List<TrainingProgram>Train {get;set;}
        public int? ComputerId { get; set; }
        public int? TrainId { get; set; }
        public Employee Emp { get; set; }
        public List<Department> depotlist { get; set; }
        public HashSet<TrainingProgram> future { get; set; } = new HashSet<TrainingProgram>();
        public List<TrainingProgram> current { get; set; } = new List<TrainingProgram>();
        public List<TrainingProgram> past { get; set; }= new List<TrainingProgram>();
        public EmployeeEditViewModel()
        {
            Comp = new List<Computer>();
            Train = new List<TrainingProgram>();
            depotlist = new List<Department>();
        }
    }
}
