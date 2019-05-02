﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabManager.Data;
using LabManager.Models;
using LabManager.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LabManager.Controllers
{
    [Authorize]
    public class LabThingsController : Controller
    {

        private readonly UserManager<Employee> _userManager;

        private readonly ApplicationDbContext _context;

        public LabThingsController(ApplicationDbContext context, UserManager<Employee> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<Employee> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //=========================================================================================


        // GET: LabThings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LabThings
                .Include(lt => lt.Category);
            //    .Include(lt => lt.Employee);
            return View(await applicationDbContext.ToListAsync());
        }


    //    var labThing = await _context.LabThings
    //.Include(lt => lt.Category)
    //.FirstOrDefaultAsync(x => x.ID == id);



        //========================================================================================
        //NOTE: Original Create method:

        //GET: LabThings/Create
        public IActionResult Create()
        {
            //NOTE: Added ViewData to the original method:
            //ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", labThing.CategoryID);

            //NOTE: Example from Brittany's BSite project:
            var CategoryData = _context.Categories;
            List<SelectListItem> CategoriesList = new List<SelectListItem>();

            CategoriesList.Insert(0, new SelectListItem
            {
                Text = "Select",
                Value = ""
            });

            foreach (var cat in CategoryData)
            {
                SelectListItem categoryItem = new SelectListItem
                {
                    Value = cat.ID.ToString(),
                    Text = cat.Name
                };
                CategoriesList.Add(categoryItem);
            };

            LabThingCreateViewModel labThingCreateViewModel = new LabThingCreateViewModel();

            labThingCreateViewModel.Category = CategoriesList;

            return View(labThingCreateViewModel);
        }

        //-------------------------------------------------------------------------------------------------------------

        //POST: LabThings/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("ID,Name,SerialNo,ModelNo,AcquisitionDate,CalibratedOn,CalibrationDue,MaintenanceOn,MaintenanceDue,Note,EmployeeID,CategoryID,ManufacturerID")] LabThing labThing)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(labThing);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", labThing.CategoryID);

        //     return View(labThing);
        // }

        //----------------------------------------------------------------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LabThingCreateViewModel ltViewModel)
        {

            //The Employee and EmployeeId fields must be disregarded in order to determine if the model state is valid
            ModelState.Remove("LabThing.Employee");
            ModelState.Remove("LabThing.EmployeeID");

            //The user is instead obtained by the current authorized user
            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                //The Employee Id is declaired using the async method above and established once model state is determined
                ltViewModel.LabThing.Employee = user;
                _context.Add(ltViewModel.LabThing);
                await _context.SaveChangesAsync();
                //The routing occurs here instead of in the view because the LabThing id must be created before the redirect occurs
                return RedirectToAction("Details", new { id = ltViewModel.LabThing.CategoryID });

            }

            //Get product type data from the database
            var CategoryData = _context.Categories;

            List<SelectListItem> CategoriesList = new List<SelectListItem>();

            //Include the select option in the product type list
            CategoriesList.Insert(0, new SelectListItem
            {
                Text = "Select",
                Value = ""
            });
            foreach (var cat in CategoryData)
            {
                SelectListItem categoriesList = new SelectListItem
                {
                    Value = cat.ID.ToString(),
                    Text = cat.Name
                };
                CategoriesList.Add(categoriesList);
            };

            ltViewModel.Category = CategoriesList;
            return View(ltViewModel);

        }

            //=========================================================================================
            //NOTE: Original Edit methods:
            // GET: LabThings/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labThing = await _context.LabThings.FindAsync(id);
            if (labThing == null)
            {
                return NotFound();
            }
            //NOTE: Added ViewData:
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", labThing.CategoryID);
            return View(labThing);
        }

        //-------------------------------------------------------------------------------------------------------------

        // POST: LabThings/Edit/5
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

        //==============================================================================
        //NOTE: Original details method:

        //GET: LabThings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labThing = await _context.LabThings
                .Include(lt => lt.Category)
                .FirstOrDefaultAsync(x => x.ID == id);
            if (labThing == null)
            {
                return NotFound();
            }

            return View(labThing);
        }


        //=========================================================================================
        //NOTE: Original Delete method:

        // GET: LabThings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labThing = await _context.LabThings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labThing == null)
            {
                return NotFound();
            }

            return View(labThing);
        }
        //-------------------------------------------------------------------------------------------------------------
        // POST: LabThings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labThing = await _context.LabThings.FindAsync(id);
            _context.LabThings.Remove(labThing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabThingExists(int id)
        {
            return _context.LabThings.Any(e => e.ID == id);
        }

        //=========================================================================================
        //=========================================================================================

        //=========================================================================================
    }
}
