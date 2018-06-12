using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_cat_actividades_sugeridas
{
    public class EditModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public EditModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public short? idAct;

        [BindProperty]
        public Eva_cat_actividad_sugerida Eva_cat_actividad_sugerida { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            idAct = id;

            Eva_cat_actividad_sugerida = await _context.Eva_cat_actividades_sugeridas
                .Include(a => a.Eva_cat_tipo_actividades_sugeridas).SingleOrDefaultAsync(m => m.IdActividadSugerida == id);

            if (Eva_cat_actividad_sugerida == null)
            {
                return NotFound();
            }
           ViewData["IdTipoActividadSug"] = new SelectList(_context.Eva_cat_tipo_actividades_sugeridas, "IdTipoActividadSug", "DesTipoActividadSug");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Eva_cat_actividad_sugerida).State = EntityState.Modified;

            try
            {
              
              
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadSugeridaExists(Eva_cat_actividad_sugerida.IdActividadSugerida))
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

        private bool ActividadSugeridaExists(int id)
        {
            return _context.Eva_cat_actividades_sugeridas.Any(e => e.IdActividadSugerida == id);
        }
    }
}
