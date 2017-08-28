using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using workforceManagement.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace workforceManagement.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new workforceManagementContext(serviceProvider.GetRequiredService<DbContextOptions<workforceManagementContext>>()))
            {
                if (context.Computer.Any())
                {
                    return;
                }
                //seeding COMPUTERS
                var computers = new Computer[]
                {
                    new Computer {
                     Make= "Macbook",
                     Manufacturer= "Apple",
                     CommissionDate= new DateTime(2017, 5, 23, 6, 12, 45)},
                    new Computer {
                     Make= "L70-G50",
                     Manufacturer= "Lenovo",
                     CommissionDate= new DateTime(2016, 7, 4, 9, 50, 4)},
                    new Computer {
                     Make= "Notebook",
                     Manufacturer= "Samsung",
                     CommissionDate= new DateTime(2017, 8, 18, 7, 2, 32)}
                };

                foreach (Computer i in computers)
                {
                    context.Computer.Add(i);
                }
                context.SaveChanges();

                //seeding DEPARTMENTS
                var departments = new Department[]
                {
                    new Department {
                        DepartmentName = "Marketing"                     
                    },
                    new Department {
                        DepartmentName = "Accounting"
                    }
                };

                foreach (Department i in departments)
                {
                    context.Department.Add(i);
                }
                context.SaveChanges();

                //seeding EMPLOYEES
                var employees = new Employee[]
                {
                    new Employee {
                        Firstname = "Jon",
                        Lastname= "snow",
                        DepartmentId= 1
                    },
                    new Employee {
                        Firstname = "Bill",
                        Lastname= "Johnson",
                        DepartmentId= 2
                    },
                    new Employee {
                        Firstname = "Carol",
                        Lastname= "Bridges",
                        DepartmentId= 1
                    }
                };

                foreach (Employee i in employees)
                {
                    context.Employee.Add(i);
                }
                context.SaveChanges();

                //seeding TRAINING PROGRAMS
                var trainingPrograms = new TrainingProgram[]
                {
                    new TrainingProgram {
                        Name = "Doing Your Best",
                        MaxAttendees = 12,
                        StartDate = new DateTime(2018, 8, 28, 2,3,0)
                    },
                    new TrainingProgram {
                        Name = "Excelling at Excel",
                        MaxAttendees = 21,
                        StartDate = new DateTime(2017, 8, 28, 2,3,0)
                    },
                    new TrainingProgram {
                        Name = "Bring Your Things",
                        MaxAttendees = 3,
                        StartDate = new DateTime(2016, 7, 28, 2,3,0)
                    },
                    new TrainingProgram {
                        Name = "Do Life Better",
                        MaxAttendees = 45,
                        StartDate = new DateTime(2015, 7, 28, 2,3,0)
                    }
                };

                foreach (TrainingProgram i in trainingPrograms)
                {
                    context.TrainingProgram.Add(i);
                }
                context.SaveChanges();

                //seeding COMPUTER-EMPLOYEES
                var ComputerEmp = new ComputerEmp[]
                {
                    //new ComputerEmp {
                    //    EmployeeId = employees.Single(e => e.Firstname == "Jon").EmployeeId,
                    //    ComputerId = computers.Single(c => c.Make== "Macbook").ComputerId,
                    //    Start = DateTime.Now
                    //},
                    //new ComputerEmp {
                    //    EmployeeId = employees.Single(e => e.Firstname == "Bill").EmployeeId,
                    //    ComputerId = computers.Single(c => c.Make== "Macbook").ComputerId,
                    //    Start = DateTime.Now
                    //},
                    //new ComputerEmp {
                    //    EmployeeId = employees.Single(e => e.Firstname == "Carol").EmployeeId,
                    //    ComputerId = computers.Single(c => c.Make== "Notebook").ComputerId,
                    //    Start = DateTime.Now
                    //}
                    new ComputerEmp {
                        EmployeeId = 1,
                        ComputerId = 1,
                        Start = DateTime.Now
                    },
                    new ComputerEmp {
                        EmployeeId = 2,
                        ComputerId = 2,
                        Start= DateTime.Now,
                        End = new DateTime(2019, 8, 28, 2,3,0)
                    },
                    new ComputerEmp {
                        EmployeeId =3,
                        ComputerId = 3,
                        Start = DateTime.Now
                    }
                };

                foreach (ComputerEmp i in ComputerEmp)
                {
                    context.ComputerEmp.Add(i);
                }
                context.SaveChanges();


                //ADDED SEEDED DATA FOR TRAININGPRGEMP
                //AUTHOR: RYAN
                var trainingPrgEmp = new TrainingPrgEmp[]
                {

                    new TrainingPrgEmp {
                        EmployeeId = 1,
                        TrainingProgramId = 1

                    },
                    new TrainingPrgEmp {
                        EmployeeId = 2,
                        TrainingProgramId = 2
                    },
                    new TrainingPrgEmp {
                        EmployeeId =3,
                        TrainingProgramId = 3
                    }

                };

                foreach (TrainingPrgEmp i in trainingPrgEmp)
                {
                    context.TrainingPrgEmp.Add(i);
                }
                context.SaveChanges();
                //END 
            }
        }
    }
}