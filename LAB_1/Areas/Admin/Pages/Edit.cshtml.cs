using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAB_1.Data;
using WEB.Models;

namespace WEB.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly LAB_1.Data.ApplicationDbContext _context;

        public EditModel(LAB_1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Good Good { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Goods == null)
            {
                return NotFound();
            }

            var good =  await _context.Goods.FirstOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }
            Good = good;
           ViewData["SectionId"] = new SelectList(_context.Sections, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Good).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodExists(Good.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GoodExists(int id)
        {
          return (_context.Goods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
