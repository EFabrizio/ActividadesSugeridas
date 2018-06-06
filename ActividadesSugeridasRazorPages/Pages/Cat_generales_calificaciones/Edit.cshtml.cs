using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Cat_generales_calificaciones
{
    public class EditModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public EditModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public cats_generales cats_generales { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cats_generales = await _context.cat_generales
                .Include(c => c.Gene).SingleOrDefaultAsync(m => m.IdGeneral == id);

            if (cats_generales == null)
            {
                return NotFound();
            }
           ViewData["IdTipoGeneral"] = new SelectList(_context.cat_tipos_generales, "IdTipoGeneral", "IdTipoGeneral");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(cats_generales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cats_generalesExists(cats_generales.IdGeneral))
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

        private bool cats_generalesExists(short id)
        {
            return _context.cat_generales.Any(e => e.IdGeneral == id);
        }
    }
}
