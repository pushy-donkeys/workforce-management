using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using workforceManagement.Models;
using workforceManagement.Models.ViewModels;

namespace workforceManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly workforceManagementContext _context;

        public EmployeesController(workforceManagementContext context)
        {
            _context = context;    
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var workforceManagementContext = _context.Employee.Include(e => e.Department);
            return View(await workforceManagementContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                //BEGIN THE INCLUDE FOR THE JOIN TABLES
                //THIS GETS BACK THE TABLES FOR COMPUTER AND TRAININGPRGEMP FOR THE SELECTED EMPLOYEE
                .Include("ComputerEmp.Computer")
                .Include("TrainingPrgEmp.TrainingProgram")
                //END 
                .SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "DepartmentId", "DepartmentId");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Firstname,Lastname,Startdate,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "DepartmentId", "DepartmentId", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            EmployeeEditViewModel Empvm = new EmployeeEditViewModel();
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
            .Include(c => c.ComputerEmp)
            .Include(t => t.TrainingPrgEmp)
            .Include(d => d.Department)

            .SingleOrDefaultAsync(m => m.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }
            Empvm.Emp = employee;
            var compy = _context.Computer.Include("ComputerEmp.Computer").ToList();
            var trainy = _context.TrainingProgram.Include("TrainingPrgEmp").ToList();

            //TrainingProgram Start date greater than datetime.now and not signed up for specific employee
            //add to viewmodel every trainingProgram that fits this condition
            List<TrainingProgram> allPrograms = new List<TrainingProgram>();
            HashSet<TrainingProgram> futurePrograms = new HashSet<TrainingProgram>();
            List<TrainingProgram> pastPrograms = new List<TrainingProgram>();
            List<TrainingProgram> currentPrograms = new List<TrainingProgram>();
            List<TrainingProgram> allPastPrograms = new List<TrainingProgram>();
            
            //GET A LIST OF ALL PROGRAMS WHERE THE START DATE IS IN THE FUTURE OR ON THE SAME DATE
            foreach(var x in trainy)
            {
                if(x.StartDate >= DateTime.Today)
                {
                    allPrograms.Add(x);
                }
            }

            //GET A LIST OF ALL PROGRAMS WHERE THE END DATE IS IN THE PAST
            foreach(var x in trainy)
            {
                if(x.EndDate < DateTime.Now)
                {
                    allPastPrograms.Add(x);
                }
            }
            //GET ALL TRAINING PROGRAMS THE CURRENT EMPLOYEE CAN ATTEND
            foreach(var y in allPrograms)
            {
                if(!_context.TrainingPrgEmp.Any(tpe => tpe.EmployeeId == id && y.TrainingProgramId == tpe.TrainingProgramId))
                {
                    Empvm.future.Add(y);
                }
            }
            //GET ALL TRAINING PROGRAMS THE CURRENT EMPLOYEE IS ATTENDING NOW
            foreach(var z in allPrograms)
            {
                if(_context.TrainingPrgEmp.Any(tpe => tpe.EmployeeId == id && z.TrainingProgramId ==tpe.TrainingProgramId))
                {
                    Empvm.current.Add(z);
                }
            }
            //GET ALL TRAINING PROGRAMS THE CURRENT EMPLOYEE HAS ATTENDED IN THE PAST
            foreach(var x in allPastPrograms)
            {
                if (_context.TrainingPrgEmp.Any(tpe => tpe.EmployeeId == id && x.TrainingProgramId == tpe.TrainingProgramId))
                {
                    Empvm.past.Add(x);
                }
            }

            //currently signed up, but hasn't started yet
            //add to viewmodel every trainingProgram that they will attend in the future 

            //trainingProgram StartDate Less than datetime.now and they have attended it, for specific employee
            //add to viewmodel every trainingProgram that they have attended in the past

            //if computerEmp.employeeId == selected employeeId / add to viewmodel 
            //if computer.decommisionDate == null / add to viewmodel 
            //if computeremp.End != null / add to viewmodel 

            //List 1
            List<Computer> notDecommissioned = new List<Computer>();
            //BEGIN LOOPING OVER EVERY COMPUTER TO FIND ONES THAT ARE IN CIRCULATION
            foreach(var x in compy)
            { 
                if(x.DecommisionDate == null)
                {
                    notDecommissioned.Add(x);
                }
            }
            //END

            //BEGIN LOOPING OVER COMPUTERS IN CIRCULATION TO FIND ONES THAT 
            //EXIST ON THE COMPUTER TABLE AND COMPUTEREMP TABLE AND HAS AN END DATE
            //AND COMPUTERS THAT DON'T EXIST ON THE COMPUTEREMP TABLE
            foreach (var y in notDecommissioned)
            {
                if (_context.ComputerEmp.Any(ce => y.ComputerId == ce.ComputerId && ce.End != null))
                {
                    Empvm.Comp.Add(y);
                }
                if (!_context.ComputerEmp.Any(ce => y.ComputerId == ce.ComputerId ))
                {
                    Empvm.Comp.Add(y);
                }

            }
            //END

            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "DepartmentId", "DepartmentId", employee.DepartmentId);

            return View(Empvm);

        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeEditViewModel Empvm)
        {
            if( id != Empvm.Emp.EmployeeId)
            {
                return NotFound();
            }
           
            //If a selection has been made for a computer then update the database.
            if(Empvm.ComputerId != null )
            {
                ComputerEmp empcomp = new ComputerEmp() { EmployeeId = Empvm.Emp.EmployeeId, ComputerId = Empvm.ComputerId ?? default(int) };
            if (ModelState.IsValid)
            {
                try
                {
                        _context.Update(Empvm.Emp);
                        _context.Add(empcomp);
                        await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                    {
                    if (!EmployeeExists(Empvm.Emp.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
        }
            //If no selection has been made, no changes will be made to the database
            else if(Empvm.ComputerId == null)
            {
                ComputerEmp empcomp = new ComputerEmp() { EmployeeId = Empvm.Emp.EmployeeId, ComputerId = Empvm.ComputerId ?? default(int) };

                if (ModelState.IsValid)
                {
                    try
                    { 
                        _context.Update(Empvm.Emp);
                       
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EmployeeExists(Empvm.Emp.EmployeeId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Index");
                }
            }

            //If a selection has been made for a training program, update the database
            if ( Empvm.TrainId != null)
            {
                TrainingPrgEmp emptrain = new TrainingPrgEmp() { EmployeeId = Empvm.Emp.EmployeeId, TrainingProgramId = Empvm.TrainId ?? default(int) };
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Empvm.Emp);
                        _context.Add(emptrain);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EmployeeExists(Empvm.Emp.EmployeeId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            //if no selection has been made, the database will not be updated
            else if (Empvm.TrainId == null)
            {
                TrainingPrgEmp emptrain = new TrainingPrgEmp() { EmployeeId = Empvm.Emp.EmployeeId, TrainingProgramId = Empvm.TrainId ?? default(int) };

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Empvm.Emp);
                     
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EmployeeExists(Empvm.Emp.EmployeeId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
           



            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "DepartmentId", "DepartmentId", Empvm.Emp.DepartmentId);
            return View(Empvm.Emp);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.EmployeeId == id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
