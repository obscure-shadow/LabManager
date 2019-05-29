using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabManager.Data;
using LabManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using LabManager.Models.ViewModels;

namespace LabManager.Controllers
{

    [Authorize]
    public class ChemicalsController : Controller
    {

        private readonly UserManager<Employee> _userManager;

        private readonly ApplicationDbContext _context;
        public ChemicalsController(ApplicationDbContext context, UserManager<Employee> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<Employee> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        //=========================================================================================
        // GET: Chemicals
        public async Task<IActionResult> Index(string sortOrder)
        {
            // if sortOrder is null, run the initial call
            // if sortOrder = Name_Desc, make a call to the db (var chemical...) with an orderby chem.Name desc before select chem. 
            // else, if sortOrder = Name, do the same with an orderby Name

            // NOTE: Create a factory function for this!

            if (sortOrder == null)
            {
                //Gets chemicals from database:
                var chemical = from chem in _context.Chemicals
                    .Include(chem => chem.Employee)
                    .Include(chem => chem.ChemicalType)
                    .Include(chem => chem.Manufacturer)
                               select chem;

                return View(await chemical.ToListAsync());

            } else if (sortOrder == "Name")
            {
                ViewData["Name"] = sortOrder;
                var chemical = from chem in _context.Chemicals
                    .Include(chem => chem.Employee)
                    .Include(chem => chem.ChemicalType)
                    .Include(chem => chem.Manufacturer)
                               orderby chem.Name
                               select chem;

                return View(await chemical.ToListAsync());
                
            } else if (sortOrder == "Name_Desc")
            {
                ViewData["Name_Desc"] = sortOrder;
                var chemical = from chem in _context.Chemicals
                .Include(chem => chem.Employee)
                .Include(chem => chem.ChemicalType)
                .Include(chem => chem.Manufacturer)
                               orderby chem.Name descending
                               select chem;

                return View(await chemical.ToListAsync());

            } else if (sortOrder == "ReceivedDate")
                {
                    ViewData["ReceivedDate"] = sortOrder;
                    var chemical = from chem in _context.Chemicals
                        .Include(chem => chem.Employee)
                        .Include(chem => chem.ChemicalType)
                        .Include(chem => chem.Manufacturer)
                                   orderby chem.ReceivedDate
                                   select chem;

                    return View(await chemical.ToListAsync());

            } else if (sortOrder == "ReceivedDate_Desc")
                {
                    ViewData["ReceivedDate_Desc"] = sortOrder;
                    var chemical = from chem in _context.Chemicals
                    .Include(chem => chem.Employee)
                    .Include(chem => chem.ChemicalType)
                    .Include(chem => chem.Manufacturer)
                                   orderby chem.ReceivedDate descending
                                   select chem;

                    return View(await chemical.ToListAsync());

                } else if (sortOrder == "OpenDate")
                {
                    ViewData["OpenDate"] = sortOrder;
                    var chemical = from chem in _context.Chemicals
                        .Include(chem => chem.Employee)
                        .Include(chem => chem.ChemicalType)
                        .Include(chem => chem.Manufacturer)
                        orderby chem.OpenDate
                        select chem;

                return View(await chemical.ToListAsync());

                } else if (sortOrder == "OpenDate_Desc")
                {
                    ViewData["OpenDate_Desc"] = sortOrder;
                    var chemical = from chem in _context.Chemicals
                        .Include(chem => chem.Employee)
                        .Include(chem => chem.ChemicalType)
                        .Include(chem => chem.Manufacturer)
                    orderby chem.OpenDate descending
                    select chem;

                    return View(await chemical.ToListAsync());

                } else if (sortOrder == "ExpirationDate")
            {
                ViewData["ExpirationDate"] = sortOrder;
                var chemical = from chem in _context.Chemicals
                    .Include(chem => chem.Employee)
                    .Include(chem => chem.ChemicalType)
                    .Include(chem => chem.Manufacturer)
                               orderby chem.ExpirationDate
                               select chem;

                return View(await chemical.ToListAsync());

            } else if (sortOrder == "ExpirationDate_Desc")
            {
                ViewData["ExpirationDate_Desc"] = sortOrder;
                var chemical = from chem in _context.Chemicals
                .Include(chem => chem.Employee)
                .Include(chem => chem.ChemicalType)
                .Include(chem => chem.Manufacturer)
                               orderby chem.ExpirationDate descending
                               select chem;

                return View(await chemical.ToListAsync());

            } else if (sortOrder == "Employee")
            {
                ViewData["Employee"] = sortOrder;
                var chemical = from chem in _context.Chemicals
                    .Include(chem => chem.Employee)
                    .Include(chem => chem.ChemicalType)
                    .Include(chem => chem.Manufacturer)
                               orderby chem.Employee.FirstName
                               select chem;

                return View(await chemical.ToListAsync());

            } else if (sortOrder == "Employee_Desc")
            {
                ViewData["Employee_Desc"] = sortOrder;
                var chemical = from chem in _context.Chemicals
                .Include(chem => chem.Employee)
                .Include(chem => chem.ChemicalType)
                .Include(chem => chem.Manufacturer)
                               orderby chem.Employee.FirstName descending
                               select chem;

                return View(await chemical.ToListAsync());
            } else if (sortOrder == "Manufacturer")
            {
                ViewData["Manufacturer"] = sortOrder;
                var chemical = from chem in _context.Chemicals
                    .Include(chem => chem.Employee)
                    .Include(chem => chem.ChemicalType)
                    .Include(chem => chem.Manufacturer)
                               orderby chem.Manufacturer.Name
                               select chem;

                return View(await chemical.ToListAsync());

            } else if (sortOrder == "Manufacturer_Desc")
            {
                ViewData["Manufacturer_Desc"] = sortOrder;
                var chemical = from chem in _context.Chemicals
                .Include(chem => chem.Employee)
                .Include(chem => chem.ChemicalType)
                .Include(chem => chem.Manufacturer)
                               orderby chem.Manufacturer.Name descending
                               select chem;

                return View(await chemical.ToListAsync());

            } else if (sortOrder == "ChemicalType")
            {
                ViewData["ChemicalType"] = sortOrder;
                var chemical = from chem in _context.Chemicals
                    .Include(chem => chem.Employee)
                    .Include(chem => chem.ChemicalType)
                    .Include(chem => chem.Manufacturer)
                               orderby chem.ChemicalType.Name
                               select chem;

                return View(await chemical.ToListAsync());

            } else if (sortOrder == "ChemicalType_Desc")
            {
                ViewData["ChemicalType_Desc"] = sortOrder;
                var chemical = from chem in _context.Chemicals
                .Include(chem => chem.Employee)
                .Include(chem => chem.ChemicalType)
                .Include(chem => chem.Manufacturer)
                               orderby chem.ChemicalType.Name descending
                               select chem;

                return View(await chemical.ToListAsync());
            }

            return View();
        }
        //========================================================================================
        // GET: Chemicals/Create
        public IActionResult Create()
        {
            ChemicalCreateViewModel chemicalCreateViewModel = new ChemicalCreateViewModel();

            var ChemicalTypeData = _context.ChemicalTypes;
            List<SelectListItem> ChemicalTypeList = new List<SelectListItem>();

            ChemicalTypeList.Insert(0, new SelectListItem
            {
                Text = "Select",
                Value = ""
            });

            foreach (var chemtype in ChemicalTypeData)
            {
                SelectListItem chemTypeItem = new SelectListItem
                {
                    Value = chemtype.ID.ToString(),
                    Text = chemtype.Name
                };
                ChemicalTypeList.Add(chemTypeItem);
            };
            chemicalCreateViewModel.ChemicalType = ChemicalTypeList;
            //-------------------------------------------------------------------------------------------------------
            //NOTE: Manufacturers Dropdown:

            var ManufacturerData = _context.Manufacturers;
            List<SelectListItem> ManufacturersList = new List<SelectListItem>();

            ManufacturersList.Insert(0, new SelectListItem
            {
                Text = "Select",
                Value = ""
            });

            foreach (var m in ManufacturerData)
            {
                SelectListItem manufacturerItem = new SelectListItem
                {
                    Value = m.ID.ToString(),
                    Text = m.Name
                };
                ManufacturersList.Add(manufacturerItem);
            }

            chemicalCreateViewModel.Manufacturer = ManufacturersList;
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

            chemicalCreateViewModel.Employee = EmployeesList;
            return View(chemicalCreateViewModel);
        }

        //-------------------------------------------------------------------------------------------------------

        // POST: Chemicals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChemicalCreateViewModel chemicalCreateViewModel)
        {
            //NOTE: Bind was automatically scaffolded with the controller:
                //Create([Bind("ID,Name,ReceivedDate,OpenDate,ExpirationDate,COA,OpenedBy,Note,EmployeeID,ManufacturerID,ChemicalTypeID")] Chemical chemical)

            ModelState.Remove("Chemical.Employee");
            ModelState.Remove("Chemical.EmployeeId");

            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {

                chemicalCreateViewModel.Chemical.Employee = user;
                _context.Add(chemicalCreateViewModel.Chemical);
                await _context.SaveChangesAsync();
                //The routing occurs here instead of in the view because the Chemicals id must be created before the redirect occurs
                return RedirectToAction("Index");
            }

            //----------------------------------------------------------------------------------------------------
            //NOTE: ChemicalType dropdown:

            var ChemicalTypeData = _context.ChemicalTypes;

            List<SelectListItem> ChemicalTypesList = new List<SelectListItem>();

            ChemicalTypesList.Insert(0, new SelectListItem
            {
                Text = "Select",
                Value = ""
            });
            foreach (var cat in ChemicalTypeData)
            {
                SelectListItem chemicalTypesList = new SelectListItem
                {
                    Value = cat.ID.ToString(),
                    Text = cat.Name
                };
                ChemicalTypesList.Add(chemicalTypesList);
            };

            chemicalCreateViewModel.ChemicalType = ChemicalTypesList;
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

            chemicalCreateViewModel.Manufacturer = ManufacturersList;
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

            chemicalCreateViewModel.Employee = EmployeesList;

            //----------------------------------------------------------------------------------------------------
            return View(chemicalCreateViewModel);
        }
        
//========================================================================================
        // GET: Chemicals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chemical = await _context.Chemicals
                .Include(chem => chem.ChemicalType)
                .Include(chem => chem.Manufacturer)
                .Include(chem => chem.Employee)
                .FirstOrDefaultAsync(chem => chem.ID == id);

            if (chemical == null)
            {
                return NotFound();
            }

            ViewData["ChemicalTypeID"] = new SelectList(_context.ChemicalTypes, "ID", "Name", chemical.ChemicalTypeID);

            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ID", "Name", chemical.ManufacturerID);

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", chemical.EmployeeId);

            return View(chemical);
        }
        //-------------------------------------------------------------------------------------------------------

        // POST: Chemicals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ReceivedDate,OpenDate,ExpirationDate,COA,OpenedBy,Note,EmployeeId,ManufacturerID,ChemicalTypeID")] Chemical chemical)

        {
            if (id != chemical.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chemical);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChemicalExists(chemical.ID))
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

                ViewData["ChemicalTypeID"] = new SelectList(_context.ChemicalTypes, "ID", "Name", chemical.ChemicalTypeID);

            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ID", "Name", chemical.ManufacturerID);

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", chemical.EmployeeId);

                return View(chemical);
        }
        //========================================================================================
        // GET: Chemicals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chemical = await _context.Chemicals
                .Include(chem => chem.ChemicalType)
                .Include(chem => chem.Manufacturer)
                .Include(chem => chem.Employee)
                .FirstOrDefaultAsync(x => x.ID == id);
            if (chemical == null)
            {
                return NotFound();
            }

            ViewData["ChemicalTypeID"] = new SelectList(_context.ChemicalTypes, "ID", "Name", chemical.ChemicalTypeID);

            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ID", "Name", chemical.ManufacturerID);

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", chemical.EmployeeId);

            return View(chemical);
        }

//========================================================================================

        // GET: Chemicals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chemical = await _context.Chemicals
                .Include(chem => chem.ChemicalType)
                .Include(chem => chem.Manufacturer)
                .Include(chem => chem.Employee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chemical == null)
            {
                return NotFound();
            }

            return View(chemical);
        }

        // POST: Chemicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chemical = await _context.Chemicals.FindAsync(id);
            _context.Chemicals.Remove(chemical);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChemicalExists(int id)
        {
            return _context.Chemicals.Any(e => e.ID == id);
        }
    }
}
