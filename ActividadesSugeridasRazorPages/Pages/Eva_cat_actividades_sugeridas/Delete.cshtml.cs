using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_cat_actividades_sugeridas
{
    public class DeleteModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public DeleteModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Eva_cat_actividad_sugerida Eva_cat_actividad_sugerida { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Eva_cat_actividad_sugerida = await _context.Eva_cat_actividades_sugeridas
                .Include(a => a.Eva_cat_tipo_actividades_sugeridas).SingleOrDefaultAsync(m => m.IdActividadSugerida == id);

            if (Eva_cat_actividad_sugerida == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Eva_cat_actividad_sugerida = await _context.Eva_cat_actividades_sugeridas.FindAsync(id);

            if (Eva_cat_actividad_sugerida != null)
            {
                await _context.Database.ExecuteSqlCommandAsync("DELETE FROM eva_actividades_sug_estatus WHERE IdActividadSugerida =" + id);
      
                _context.Eva_cat_actividades_sugeridas.Remove(Eva_cat_actividad_sugerida);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
