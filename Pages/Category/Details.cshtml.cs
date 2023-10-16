using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcomApp.Data;
using EcomApp.Models;

namespace EcomApp.Pages.Category
{
    public class DetailsModel : PageModel
    {
        private readonly EcomApp.Data.AppDbContext _context;

        public DetailsModel(EcomApp.Data.AppDbContext context)
        {
            _context = context;
        }

      public Models.Category Category { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }
    }
}
