using System;
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
        //public LabThingsController(ApplicationDbContext context)
        public LabThingsController(ApplicationDbContext context, UserManager<Employee> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        //private Task<Employee> GetCurrentUserAsync() => _context.GetUserAsync(HttpContext.User);

        private Task<Employee> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //=========================================================================================
        // GET: LabThings
        //NOTE: Gets a labthing from _context (database) and includes navigation properties category, manufacturer, and employee.
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LabThing
                .Include(lt => lt.Employee)
                .Include(lt => lt.Category)
                .Include(lt => lt.Manufacturer);
            return View(await applicationDbContext.ToListAsync());
        }

        //========================================================================================
        //GET: LabThings/Create
        public IActionResult Create()
        {
        //-------------------------------------------------------------------------------------------------------
        //NOTE: Categories Dropdown:
            
        //NOTE: The variable labThingCreateViewModel is used at the end of all navigation properties to add the nav prop to the view model:
            LabThingCreateViewModel labThingCreateViewModel = new LabThingCreateViewModel();

        // NOTE: Gets Categories with the LabThing and creates a list
            var CategoryData = _context.Categories;
            List<SelectListItem> CategoriesList = new List<SelectListItem>();

            //NOTE: Adds an empty list item at the first position in the list as a placeholder:
            CategoriesList.Insert(0, new SelectListItem
            {
                Text = "Select",
                Value = ""
            });

            //NOTE: Loops through each item in the list, stores it in categoryItem, and adds it to the categories list created above.
            foreach (var cat in CategoryData)
            {
                SelectListItem categoryItem = new SelectListItem
                {
                    Value = cat.ID.ToString(),
                    Text = cat.Name
                };
                CategoriesList.Add(categoryItem);
            };
            labThingCreateViewModel.Category = CategoriesList;
            //-------------------------------------------------------------------------------------------------------
            //NOTE: Manufacturers Dropdown:

            var ManufacturerData = _context.Manufacturers;
            List<SelectListItem> ManufacturersList = new List<SelectListItem>();

            ManufacturersList.Insert(0, new SelectListItem
            {
                Text = "Select",
                Value = ""
            });

            foreach(var m in ManufacturerData)
            {
                SelectListItem manufacturerItem = new SelectListItem
                {
                    Value = m.ID.ToString(),
                    Text = m.Name
                };
                ManufacturersList.Add(manufacturerItem);
            }

            labThingCreateViewModel.Manufacturer = ManufacturersList;
            //-------------------------------------------------------------------------------------------------------------
            //NOTE: Employee Dropdown:

            var EmployeeData = _context.Employees;
            List<SelectListItem> EmployeesList = new List<SelectListItem>();

            EmployeesList.Insert(0, new SelectListItem
            {
                Text = "Select",
                Value = ""
            });

            foreach (var e in EmployeeData)
            {
                SelectListItem employeeItem = new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.FirstName
                };
                EmployeesList.Add(employeeItem);
            }

            labThingCreateViewModel.Employee = EmployeesList;

            //----------------------------------------------------------------------------------------------------
            return View(labThingCreateViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LabThingCreateViewModel ltViewModel)
        {

            //The Employee and EmployeeID fields must be disregarded in order to determine if the model state is valid
            ModelState.Remove("LabThing.Employee");
            ModelState.Remove("LabThing.EmployeeId");

            //The user is instead obtained by the current authorized user
            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                //The Employee Id is declaired using the async method above and established once model state is determined
                ltViewModel.LabThing.Employee = user;
                _context.Add(ltViewModel.LabThing);
                await _context.SaveChangesAsync();
                //The routing occurs here instead of in the view because the LabThing id must be created before the redirect occurs
                return RedirectToAction("Index");
            }
            //----------------------------------------------------------------------------------------------------
            //NOTE: Category dropdown:

            //Get category data from the database
            var CategoryData = _context.Categories;

            List<SelectListItem> CategoriesList = new List<SelectListItem>();

            //Include the select option in the category list
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

        //----------------------------------------------------------------------------------------------------
        //NOTE: Manufacturer dropdown:

            var ManufacturerData = _context.Manufacturers;

            List<SelectListItem> ManufacturersList = new List<SelectListItem>();

            //Include the select option in the manufacturer list
            ManufacturersList.Insert(0, new SelectListItem
            {
                Text = "Select",
                Value = ""
            });
            foreach (var m in ManufacturerData)
            {
                SelectListItem manufacturersList = new SelectListItem
                {
                    Value = m.ID.ToString(),
                    Text = m.Name
                };
                ManufacturersList.Add(manufacturersList);
            };

            ltViewModel.Manufacturer = ManufacturersList;

            //----------------------------------------------------------------------------------------------------
            //NOTE: Employee dropdown:

            var EmployeeData = _context.Employees;

            List<SelectListItem> EmployeesList = new List<SelectListItem>();

            //Include the select option in the employee list
            EmployeesList.Insert(0, new SelectListItem
            {
                Text = "Select",
                Value = ""
            });
            foreach (var e in EmployeeData)
            {
                SelectListItem employeesList = new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.FirstName
                };
                EmployeesList.Add(employeesList);
            };

            ltViewModel.Employee = EmployeesList;

            //----------------------------------------------------------------------------------------------------
            return View(ltViewModel);
        }

        //=========================================================================================
        //GET Edit/[id]
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var labThing = await _context.LabThing
                .Include(lt => lt.Category)
                .Include(lt => lt.Manufacturer)
                .Include(lt => lt.Employee)
                .FirstOrDefaultAsync(lt => lt.ID == id);

            if (labThing == null)
            {
                return NotFound();
            }

            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name", labThing.CategoryID);

            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ID", "Name", labThing.ManufacturerID);

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", labThing.EmployeeId);

            return View(labThing);
        }
        //-------------------------------------------------------------------------------------------------------------
        //POST: Edit/[id]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
            //(int? id, [Bind("ID", "Name", "SerialNo", "ModelNo", "AcquisitionDate", "CalibratedOn", "CalibrationDue", "MaintenanceOn", "MaintenanceDue", "Note", "CategoryID", "ManufacturerID", "EmployeeId", labThing.ID)]);
        {
            if(id == null)
            {
                return NotFound();
            }

            var labThingToUpdate = await _context.LabThing.FirstOrDefaultAsync(lt => lt.ID == id);

            if (await TryUpdateModelAsync<LabThing>(labThingToUpdate, 
                "",
                lt => lt.CategoryID, lt => lt.ManufacturerID, lt => lt.EmployeeId))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name", labThingToUpdate.CategoryID);

            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ID", "Name", labThingToUpdate.ManufacturerID);

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", labThingToUpdate.EmployeeId);

            return View(labThingToUpdate);
        }


        //==============================================================================

        //GET: LabThings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labThing = await _context.LabThing
                .Include(lt => lt.Category)
                .Include(lt => lt.Manufacturer)
                .Include(lt => lt.Employee)
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

            var labThing = await _context.LabThing
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
            var labThing = await _context.LabThing.FindAsync(id);
            _context.LabThing.Remove(labThing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabThingExists(int id)
        {
            return _context.LabThing.Any(e => e.ID == id);
        }

        //=========================================================================================
        //=========================================================================================

        //=========================================================================================
    }
}
