using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabManager.Data;
using LabManager.Models;

namespace LabManager.Areas.Identity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LabManager.Data.ApplicationDbContext _context;

        public IndexModel(LabManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
