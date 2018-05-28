using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_metodologias
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
        ViewData["IdMetodologia"] = new SelectList(_context.eva_cat_metodologias, "IdMetodologia", "IdMetodologia");
        ViewData["IdPlantillaMetodo"] = new SelectList(_context.eva_plantilla_metodologia, "IdPlantillaMetodo", "IdPlantillaMetodo");
        ViewData["IdMomento"] = new SelectList(_context.eva_plantilla_momentos_metodologia, "IdMomento", "IdMomento");
        ViewData["IdPersona"] = new SelectList(_context.rh_cat_personas, "IdPersona", "IdPersona");
            return Page();
        }

        [BindProperty]
        public eva_momentos_metodologias eva_momentos_metodologias { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.eva_momentos_metodologia.Add(eva_momentos_metodologias);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}