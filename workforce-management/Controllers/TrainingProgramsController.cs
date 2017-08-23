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
    public class TrainingProgramsController : Controller
    {
        private readonly workforceManagementContext _context;

        public TrainingProgramsController(workforceManagementContext context)
        {
            _context = context;    
        }

        // GET: TrainingPrograms
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingProgram.ToListAsync());
        }

        // GET: TrainingPrograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // This creates a new instance of the TP view model
            // authored by Kyle Kellums

            TrainingProgramViewModel TPViewMod = new TrainingProgramViewModel();
            if (id == null)
            {
                return NotFound();
            }

            // Created a variable 'tp' to hold the specific instance the user clicked on in the index. The TrainingProgramId gets passed into the method.
            TrainingProgram tp = await _context.TrainingProgram.Include(etp => etp.TrainingPrgEmp)                
                .SingleOrDefaultAsync(m => m.TrainingProgramId == id);

            TPViewMod.TrainProg = tp;

            // loops through the ICollection in TrainingProgram.cs of TrainingPrgEmp
            foreach (var x in tp.TrainingPrgEmp)
            {
                // Since TrainingPrgEmp has an instance of Employee on it, we can access that Employee
                TPViewMod.Emp.Add(x.Employee);
            }

                if (TPViewMod.TrainProg == null)
            {
                return NotFound();
            }

            return View(TPViewMod);
        }

        // GET: TrainingPrograms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingProgramId,TrainingProgramName,StartDate,EndDate,Description,MaxAttendees")] TrainingProgram trainingProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trainingProgram);
        }

        // GET: TrainingPrograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingProgram = await _context.TrainingProgram.SingleOrDefaultAsync(m => m.TrainingProgramId == id);
            if (trainingProgram == null)
            {
                return NotFound();
            }
            return View(trainingProgram);
        }

        // POST: TrainingPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainingProgramId,TrainingProgramName,StartDate,EndDate,Description,MaxAttendees")] TrainingProgram trainingProgram)
        {
            if (id != trainingProgram.TrainingProgramId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingProgramExists(trainingProgram.TrainingProgramId))
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
            return View(trainingProgram);
        }

        // GET: TrainingPrograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingProgram = await _context.TrainingProgram
                .SingleOrDefaultAsync(m => m.TrainingProgramId == id);
            if (trainingProgram == null)
            {
                return NotFound();
            }

            return View(trainingProgram);
        }

        // POST: TrainingPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainingProgram = await _context.TrainingProgram.SingleOrDefaultAsync(m => m.TrainingProgramId == id);
            _context.TrainingProgram.Remove(trainingProgram);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrainingProgramExists(int id)
        {
            return _context.TrainingProgram.Any(e => e.TrainingProgramId == id);
        }
    }
}
