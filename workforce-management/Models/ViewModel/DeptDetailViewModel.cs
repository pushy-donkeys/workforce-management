using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workforceManagement.Models.ViewModel
{
    public class DeptDetailViewModel
    {
        public Department Dept { get; set; }
        public IEnumerable<Employee> Employee { get; set; }
    }
}
