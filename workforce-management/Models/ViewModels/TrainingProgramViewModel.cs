using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workforceManagement.Models;

namespace workforceManagement.Models.ViewModels
{
    public class TrainingProgramViewModel
    {
        // This is the instance that holds the TrainingProgram the user wants to view 
        public TrainingProgram TrainProg { get; set; }

        // this is a list of all employees attending a particular program
        public List<Employee> Emp { get; set; }
    }
}
