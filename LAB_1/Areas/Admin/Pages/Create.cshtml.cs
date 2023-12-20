using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LAB_1.Data;
using WEB.Models;

namespace WEB.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly LAB_1.Data.ApplicationDbContext _context;

        public CreateModel(LAB_1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SectionId"] = new SelectList(_context.Sections, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Good Good { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Goods == null || Good == null)
            {
                return Page();
            }

            _context.Goods.Add(Good);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
