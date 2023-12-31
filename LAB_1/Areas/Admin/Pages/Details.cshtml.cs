﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB.Data;
using WEB.Models;

namespace WEB.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WEB.Data.ApplicationDbContext _context;

        public DetailsModel(WEB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Good Good { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Goods == null)
            {
                return NotFound();
            }

            var good = await _context.Goods.FirstOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }
            else 
            {
                Good = good;
            }
            return Page();
        }
    }
}
