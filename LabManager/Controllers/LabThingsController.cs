using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabManager.Data;
using LabManager.Models;

namespace LabManager.Controllers
{
    public class LabThingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LabThingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LabThings
        public async Task<IActionResult> Index()
        {
            return View(await _context.LabThing.ToListAsync());
        }

        // GET: LabThings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labThing = await _context.LabThing
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labThing == null)
            {
                return NotFound();
            }

            return View(labThing);
        }

        // GET: LabThings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LabThings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,SerialNo,ModelNo,AcquisitionDate,CalibratedOn,CalibrationDue,MaintenanceOn,MaintenanceDue,Note,EmployeeID,CategoryID,ManufacturerID")] LabThing labThing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labThing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labThing);
        }

        // GET: LabThings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labThing = await _context.LabThing.FindAsync(id);
            if (labThing == null)
            {
                return NotFound();
            }
            return View(labThing);
        }

        // POST: LabThings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,SerialNo,ModelNo,AcquisitionDate,CalibratedOn,CalibrationDue,MaintenanceOn,MaintenanceDue,Note,EmployeeID,CategoryID,ManufacturerID")] LabThing labThing)
        {
            if (id != labThing.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labThing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabThingExists(labThing.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(labThing);
        }

        // GET: LabThings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labThing = await _context.LabThing
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labThing == null)
            {
                return NotFound();
            }

            return View(labThing);
        }

        // POST: LabThings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labThing = await _context.LabThing.FindAsync(id);
            _context.LabThing.Remove(labThing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabThingExists(int id)
        {
            return _context.LabThing.Any(e => e.ID == id);
        }
    }
}
