using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EcomApp.Data;
using EcomApp.Models;
using Microsoft.Extensions.Options;

namespace EcomApp.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly EcomApp.Data.AppDbContext _context;
        private readonly ILogger<CreateModel> _logger;

        public List<SelectListItem> Options { get; set; }

        public CreateModel(EcomApp.Data.AppDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
             Options = _context.Categories.Select(a =>
             new SelectListItem
             {
                 Value = a.Id.ToString(),
                 Text = a.Name
             }).ToList();
            if (Product != null && Product.Category != null)
            {
                foreach (var option in Options)
                {
                    if(int.Parse(option.Value) == Product.Category.Id)
                    {
                        Console.WriteLine(Product.Category.ToString);
                        option.Selected = true;
                    }
                }
            }
                return Page();
        }

        [BindProperty]
        public Models.Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("id  "+Product.Category.Id+"  name "+Product.Category.Name);
            if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    if (modelStateVal.Errors.Count > 0)
                    {
                        foreach (var error in modelStateVal.Errors)
                        {
                            _logger.LogError($"{modelStateKey}: {error.ErrorMessage}");
                        }
                    }
                }

                return Page();
            }
            Product.Category = _context.Categories.Find(Product.Category.Id);
            
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
