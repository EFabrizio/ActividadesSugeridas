using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_evalua_competencias_persona
{
    public class EditModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public EditModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_evalua_competencias_personas eva_evalua_competencias_personas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_evalua_competencias_personas = await _context.eva_evalua_competencias_persona
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.eva_cat_tipo_competencias).SingleOrDefaultAsync(m => m.IdPersona == id);

            if (eva_evalua_competencias_personas == null)
            {
                return NotFound();
            }
           ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "IdCompetencia");
           ViewData["IdTipoCompetencia"] = new SelectList(_context.eva_cat_tipo_competencias, "IdTipoCompetencia", "IdTipoCompetencia");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_evalua_competencias_personas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_evalua_competencias_personasExists(eva_evalua_competencias_personas.IdPersona))
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

        private bool eva_evalua_competencias_personasExists(int id)
        {
            return _context.eva_evalua_competencias_persona.Any(e => e.IdPersona == id);
        }
    }
}
