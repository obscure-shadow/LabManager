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
        public LabThingsController(ApplicationDbContext context, UserManager<Employee> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<Employee> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //=========================================================================================
        // GET: LabThings

        //NOTE: Gets a labthing from _context (database) and includes navigation properties category, manufacturer, and employee.
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString)
        {

            //**********************************************************************************************
            //NOTE: Filters:
            //This filter works; it is attached to the "Name" of the LabThing. When the LabThing name is clicked, the entire list of labthings are ordered in descending order.

            ViewData["Name_Desc"] = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";

            ViewData["SerialNo_Desc"] = String.IsNullOrEmpty(sortOrder) ? "SerialNo_desc" : "";

            ViewData["ModelNo_Desc"] = String.IsNullOrEmpty(sortOrder) ? "ModelNo_desc" : "";

            ViewData["AcquisitionDate_Desc"] = String.IsNullOrEmpty(sortOrder) ? "AcquisitionDate_desc" : "";

            ViewData["CalibratedOn_Desc"] = String.IsNullOrEmpty(sortOrder) ? "CalibratedOn_desc" : "";

            ViewData["CalibrationDue_Desc"] = String.IsNullOrEmpty(sortOrder) ? "CalibrationDue_desc" : "";

            ViewData["MaintenanceOn_Desc"] = String.IsNullOrEmpty(sortOrder) ? "MaintenanceOn_desc" : "";

            ViewData["MaintenanceDue_Desc"] = String.IsNullOrEmpty(sortOrder) ? "MaintenanceDue_desc" : "";

            ViewData["Note_Desc"] = String.IsNullOrEmpty(sortOrder) ? "Note_desc" : "";

            //--------------------------Drop-down sorting:---------------------------------------------

            ViewData["Employee_Desc"] = String.IsNullOrEmpty(sortOrder) ? "Employee_desc" : "";

            //---------------------------------------------------------------------------------------------

            //Gets the LabThings from the database
            //var applicationDbContext = _context.LabThing
            var labThing = from lt in _context.LabThing
                        .Include(lt => lt.Employee)
                        .Include(lt => lt.Category)
                        .Include(lt => lt.Manufacturer)
                           select lt;


            switch (sortOrder){
                // SORT BY NAME:
                case "Name_desc":
                    labThing = labThing.OrderByDescending(lt => lt.Name);
                    break;
                case "Name":
                    labThing = labThing.OrderByDescending(lt => lt.Name);
                    break;
                default:
                    labThing = labThing.OrderBy(lt => lt.Name);
                    break;

                //SORT BY SERIALNO:
                case "SerialNo_desc":
                    labThing = labThing.OrderByDescending(lt => lt.SerialNo);
                    break;
                case "SerialNo":
                    labThing = labThing.OrderByDescending(lt => lt.SerialNo);
                    break;

                //SORT BY MODELNO:
                case "ModelNo_desc":
                    labThing = labThing.OrderByDescending(lt => lt.ModelNo);
                    break;
                case "ModelNo":
                    labThing = labThing.OrderByDescending(lt => lt.ModelNo);
                    break;

                //SORT BY ACQUISITIONDATE:
                case "AcquisitionDate_desc":
                    labThing = labThing.OrderByDescending(lt => lt.AcquisitionDate);
                    break;
                case "AcquisitionDate":
                    labThing = labThing.OrderByDescending(lt => lt.AcquisitionDate);
                    break;

                //SORT BY CALIBRATEDON:
                case "CalibratedOn_desc":
                    labThing = labThing.OrderByDescending(lt => lt.CalibratedOn);
                    break;
                case "CalibratedOn":
                    labThing = labThing.OrderByDescending(lt => lt.CalibratedOn);
                    break;

                //SORT BY CALIBRATIONDUE:
                case "CalibrationDue_desc":
                    labThing = labThing.OrderByDescending(lt => lt.CalibrationDue);
                    break;
                case "CalibrationDue":
                    labThing = labThing.OrderByDescending(lt => lt.CalibrationDue);
                    break;

                //SORT BY MAINTENANCEON:
                case "MaintenanceOn_desc":
                    labThing = labThing.OrderByDescending(lt => lt.MaintenanceOn);
                    break;
                case "MaintenanceOn":
                    labThing = labThing.OrderByDescending(lt => lt.MaintenanceOn);
                    break;

                //SORT BY MAINTENANCEDUE:
                case "MaintenanceDue_desc":
                    labThing = labThing.OrderByDescending(lt => lt.MaintenanceDue);
                    break;
                case "MaintenanceDue":
                    labThing = labThing.OrderByDescending(lt => lt.MaintenanceDue);
                    break;

                //SORT BY NOTE:
                case "Note_desc":
                    labThing = labThing.OrderByDescending(lt => lt.Note);
                    break;
                case "Note":
                    labThing = labThing.OrderByDescending(lt => lt.Note);
                    break;

                //SORT BY EMPLOYEE:
                //case "Employee_desc":
                //    labThing = labThing.OrderByDescending(lt => lt.Employee);
                //    break;
                //case "Employee":
                //    labThing = labThing.OrderByDescending(lt => lt.Employee);
                //    break;

                case "Employee_desc":
                    labThing = labThing.OrderBy(lt => lt.Employee.FirstName);
                    break;
                case "Employee":
                    labThing = labThing.OrderBy(lt => lt.Employee.FirstName);
                    break;

            }
            return View(await labThing.ToListAsync());
            //**********************************************************************************************





            //ViewData["CurrentSort"] = sortOrder;

            //ViewData["NameSortDescParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["NameSortAscParm"] = string.IsNullOrEmpty(sortOrder) ? "name_asc" : "";

            //ViewData["EmployeeSortDescParm"] = sortOrder == "Employee" ? "employee_desc" : "Employee";
            //ViewData["EmployeeSortAscParm"] = sortOrder == "Employee" ? "employee_asc" : "Employee";

            //ViewData["CategorySortParm"] = sortOrder == "Category" ? "category_desc" : "Category";
            //ViewData["ManufacturerSortParm"] = sortOrder == "Manufacturer" ? "manufacturer_desc" : "Manufacture";


            //searchString = currentFilter;

            //ViewData["CurrentFilter"] = searchString;

            //var labthing = from lt in _context.LabThing
            //               select lt;
            //if(!string.IsNullOrEmpty(searchString))
            //{
            //NOTE: If a search term is entered in the search box and the user does not remove it and click search again, the search term will stay "locked in" indefinitely. This else statement needs to be more user-friendly and the search term should "refresh back to null" after a search is performed.
            //    labthing = labthing.Where(lt => lt.Name.Contains(searchString));
            //    return View(labthing);
            //}

            //switch (sortOrder)
            //{
            //    case "name_desc": labthing = labthing.OrderByDescending(lt => lt.Name);
            //        break;
            //    case "name_asc":
            //        labthing = labthing.OrderBy(lt => lt.Name);
            //        break;

            //    case "employee_desc": labthing = labthing.OrderByDescending(lt => lt.Employee.FirstName);
            //        break;
            //    case "employee_asc":
            //        labthing = labthing.OrderBy(lt => lt.Employee.FirstName);
            //        break;

            //    case "category_desc":
            //        labthing = labthing.OrderByDescending(lt => lt.Category.Name);
            //        break;
            //}

            //int pageSize = 3;
            //return View(await LabThing.CreateAsync(labthing, pageNumber ?? 1, pageSize));
            //return View(await labthing.ToListAsync());




            //var applicationDbContext = _context.LabThing
            //    .Include(lt => lt.Employee)
            //    .Include(lt => lt.Category)
            //    .Include(lt => lt.Manufacturer);
            //return View(await applicationDbContext.ToListAsync());
            //return View(await labthing.CreateAsync(labthing));
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

        {
            if(id == null)
            {
                return NotFound();
            }

            var labThingToUpdate = await _context.LabThing.FirstOrDefaultAsync(lt => lt.ID == id);

            if (await TryUpdateModelAsync<LabThing>(labThingToUpdate, 
                "",
lt => lt.Name, lt => lt.SerialNo, lt => lt.ModelNo, lt => lt.AcquisitionDate, lt => lt.CalibratedOn, lt => lt.CalibrationDue, lt => lt.MaintenanceOn, lt=> lt.MaintenanceDue, lt => lt.Note, lt => lt.CategoryID, lt => lt.ManufacturerID, lt => lt.EmployeeId))
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
    }
}
