using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workforceManagement.Models;

namespace workforceManagement.Models.ViewModels
{
    public class TrainingProgramViewModel
    {
        // create an instance of TrainingProgram
        public TrainingProgram TrainProg { get; set; }
        // this allows us to get a list of all employees attending a program
        public List<Employee> Emp { get; set; }
    }
}
