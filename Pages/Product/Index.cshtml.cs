using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcomApp.Data;
using EcomApp.Models;

namespace EcomApp.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly EcomApp.Data.AppDbContext _context;

        public IndexModel(EcomApp.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CategoryFilter { get; set; }

        public IList<Models.Product> Product { get; set; } = new List<Models.Product>();
        public IList<Models.Category> Categories { get; set; } = new List<Models.Category>();

        public async Task OnGetAsync()
        {
            IQueryable<Models.Product> productsQuery = _context.Products.Include(p => p.Category);

            // Filter by category if a category filter is selected
            if (!string.IsNullOrEmpty(CategoryFilter))
            {
                int categoryId = int.Parse(CategoryFilter);
                productsQuery = productsQuery.Where(p => p.Category.Id == categoryId);
            }

            // Apply search filter
            if (!string.IsNullOrEmpty(SearchString))
            {
                productsQuery = productsQuery.Where(p => p.Name.Contains(SearchString));
            }
            
            // Retrieve products and categories
            Product = await productsQuery.ToListAsync();
            Categories = await _context.Categories.ToListAsync();
        }
    }
}
