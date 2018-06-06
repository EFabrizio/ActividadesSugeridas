using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Cat_generales_calificaciones
{
    public class DeleteModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public DeleteModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cats_generales = await _context.cat_generales.FindAsync(id);

            if (cats_generales != null)
            {
                _context.cat_generales.Remove(cats_generales);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
