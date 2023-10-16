using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcomApp.Data;
using EcomApp.Models;

namespace EcomApp.Pages.Client
{
    public class DetailsModel : PageModel
    {
        private readonly EcomApp.Data.AppDbContext _context;

        public DetailsModel(EcomApp.Data.AppDbContext context)
        {
            _context = context;
        }

      public Models.Client Client { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            else 
            {
                Client = client;
            }
            return Page();
        }
    }
}
