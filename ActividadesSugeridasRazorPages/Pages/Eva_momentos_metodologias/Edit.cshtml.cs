using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_metodologias
{
    public class EditModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public EditModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
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
           ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "IdCompetencia");
           ViewData["IdMetodologia"] = new SelectList(_context.eva_cat_metodologias, "IdMetodologia", "IdMetodologia");
           ViewData["IdPlantillaMetodo"] = new SelectList(_context.eva_plantilla_metodologia, "IdPlantillaMetodo", "IdPlantillaMetodo");
           ViewData["IdMomento"] = new SelectList(_context.eva_plantilla_momentos_metodologia, "IdMomento", "IdMomento");
           ViewData["IdPersona"] = new SelectList(_context.rh_cat_personas, "IdPersona", "IdPersona");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_momentos_metodologias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_momentos_metodologiasExists(eva_momentos_metodologias.IdMomentoDet))
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

        private bool eva_momentos_metodologiasExists(short id)
        {
            return _context.eva_momentos_metodologia.Any(e => e.IdMomentoDet == id);
        }
    }
}
