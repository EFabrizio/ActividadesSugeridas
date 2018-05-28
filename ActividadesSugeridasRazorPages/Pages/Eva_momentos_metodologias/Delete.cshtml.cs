﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_metodologias
{
    public class DeleteModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public DeleteModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_momentos_metodologias eva_momentos_metodologias { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_momentos_metodologias = await _context.eva_momentos_metodologia
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.eva_cat_metodologias)
                .Include(e => e.eva_plantilla_metodologia)
                .Include(e => e.eva_plantilla_momentos_metodologia)
                .Include(e => e.rh_cat_personas).SingleOrDefaultAsync(m => m.IdMomentoDet == id);

            if (eva_momentos_metodologias == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_momentos_metodologias = await _context.eva_momentos_metodologia.FindAsync(id);

            if (eva_momentos_metodologias != null)
            {
                _context.eva_momentos_metodologia.Remove(eva_momentos_metodologias);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
