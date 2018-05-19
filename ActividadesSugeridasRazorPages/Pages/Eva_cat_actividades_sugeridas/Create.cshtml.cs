using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_cat_actividades_sugeridas
{
    public class CreateModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public CreateModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdTipoActividadSug"] = new SelectList(_context.Eva_cat_tipo_actividades_sugeridas, "IdTipoActividadSug", "DesTipoActividadSug");
            return Page();
        }

        [BindProperty]
        public Eva_cat_actividad_sugerida Eva_cat_actividad_sugerida { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Eva_cat_actividades_sugeridas.Add(Eva_cat_actividad_sugerida);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}