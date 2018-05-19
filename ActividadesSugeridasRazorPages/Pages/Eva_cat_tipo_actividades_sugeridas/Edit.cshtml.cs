using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_cat_tipo_actividades_sugeridas
{
    public class EditModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;
        public short? idAct;

        public EditModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Eva_cat_tipo_actividad_sugerida Eva_cat_tipo_actividad_sugerida { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            idAct = id;

            if (id == null)
            {
                return NotFound();
            }

            Eva_cat_tipo_actividad_sugerida = await _context.Eva_cat_tipo_actividades_sugeridas.SingleOrDefaultAsync(m => m.IdTipoActividadSug == id);

            if (Eva_cat_tipo_actividad_sugerida == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Eva_cat_tipo_actividad_sugerida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Eva_cat_tipo_actividad_sugeridaExists(Eva_cat_tipo_actividad_sugerida.IdTipoActividadSug))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new {id = idAct});
        }

        private bool Eva_cat_tipo_actividad_sugeridaExists(short? id)
        {
            return _context.Eva_cat_tipo_actividades_sugeridas.Any(e => e.IdTipoActividadSug == id);
        }
    }
}
