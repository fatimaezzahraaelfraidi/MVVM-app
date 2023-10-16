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
    public class IndexModel : PageModel
    {
        private readonly EcomApp.Data.AppDbContext _context;

        public IndexModel(EcomApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Models.Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Clients != null)
            {
                Client = await _context.Clients.ToListAsync();
            }
        }
    }
}
