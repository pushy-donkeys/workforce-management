using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using workforceManagement.Models;

namespace workforceManagement.Migrations
{
    [DbContext(typeof(workforceManagementContext))]
    [Migration("20170822214019_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("workforceManagement.Models.Computer", b =>
                {
                    b.Property<int>("ComputerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CommissionDate");

                    b.Property<DateTime?>("DecommisionDate");

                    b.Property<string>("Make")
                        .IsRequired();

                    b.Property<string>("Manufacturer")
                        .IsRequired();

                    b.HasKey("ComputerId");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("workforceManagement.Models.ComputerEmp", b =>
                {
                    b.Property<int>("ComputerEmpId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ComputerId");

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime?>("End");

                    b.Property<DateTime>("Start");

                    b.HasKey("ComputerEmpId");

                    b.HasIndex("ComputerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ComputerEmp");
                });

            modelBuilder.Entity("workforceManagement.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("workforceManagement.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<DateTime>("Startdate");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("workforceManagement.Models.TrainingPrgEmp", b =>
                {
                    b.Property<int>("TrainingPrgEmpId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<int>("TrainingProgramId");

                    b.HasKey("TrainingPrgEmpId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("TrainingPrgEmp");
                });

            modelBuilder.Entity("workforceManagement.Models.TrainingProgram", b =>
                {
                    b.Property<int>("TrainingProgramId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<int>("MaxAttendees");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("TrainingProgramId");

                    b.ToTable("TrainingProgram");
                });

            modelBuilder.Entity("workforceManagement.Models.ComputerEmp", b =>
                {
                    b.HasOne("workforceManagement.Models.Computer", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("workforceManagement.Models.Employee", "Employee")
                        .WithMany("ComputerEmp")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("workforceManagement.Models.Employee", b =>
                {
                    b.HasOne("workforceManagement.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("workforceManagement.Models.TrainingPrgEmp", b =>
                {
                    b.HasOne("workforceManagement.Models.Employee", "Employee")
                        .WithMany("TrainingPrgEmp")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("workforceManagement.Models.TrainingProgram", "TrainingProgram")
                        .WithMany("TrainingPrgEmp")
                        .HasForeignKey("TrainingProgramId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
