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
        public Employee Emp { get; set; }
        public EmployeeEditViewModel()
        {
            Comp = new List<Computer>();
            Train = new List<TrainingProgram>();
        }
    }
}
