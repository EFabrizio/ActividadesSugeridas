using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.eva_plantilla_momentos_metodologia
{
    public class EditModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public EditModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_plantillas_momentos_metodologia eva_plantillas_momentos_metodologia { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_plantillas_momentos_metodologia = await _context.eva_plantilla_momentos_metodologia
                .Include(e => e.Metodologia)
                .Include(e => e.PlantillaMetodologia).SingleOrDefaultAsync(m => m.IdMomento == id);

            if (eva_plantillas_momentos_metodologia == null)
            {
                return NotFound();
            }
           ViewData["IdMetodologia"] = new SelectList(_context.eva_cat_metodologias, "IdMetodologia", "IdMetodologia");
           ViewData["IdPlantillaMetodo"] = new SelectList(_context.eva_plantilla_metodologia, "IdPlantillaMetodo", "IdPlantillaMetodo");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_plantillas_momentos_metodologia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_plantillas_momentos_metodologiaExists(eva_plantillas_momentos_metodologia.IdMomento))
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

        private bool eva_plantillas_momentos_metodologiaExists(short id)
        {
            return _context.eva_plantilla_momentos_metodologia.Any(e => e.IdMomento == id);
        }
    }
}
