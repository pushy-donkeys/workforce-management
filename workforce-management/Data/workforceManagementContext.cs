using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace workforceManagement.Models
{
    public class workforceManagementContext : DbContext
    {
        public workforceManagementContext (DbContextOptions<workforceManagementContext> options)
            : base(options)
        {
        }

        public DbSet<workforceManagement.Models.Employee> Employee { get; set; }
    }
}
