using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_evalua_competencias_persona
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
        ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "IdCompetencia");
        ViewData["IdTipoCompetencia"] = new SelectList(_context.eva_cat_tipo_competencias, "IdTipoCompetencia", "IdTipoCompetencia");
            return Page();
        }

        [BindProperty]
        public eva_evalua_competencias_personas eva_evalua_competencias_personas { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.eva_evalua_competencias_persona.Add(eva_evalua_competencias_personas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}