using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_responsables
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
        ViewData["IdGenResponsable"] = new SelectList(_context.cat_generales, "IdGeneral", "IdGeneral");
        ViewData["IdTipoGenResponsable"] = new SelectList(_context.cat_tipos_generales, "IdTipoGeneral", "IdTipoGeneral");
        ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "IdCompetencia");
        ViewData["IdMomentoDet"] = new SelectList(_context.eva_momentos_metodologia, "IdMomentoDet", "IdMomentoDet");
        ViewData["IdPersona"] = new SelectList(_context.rh_cat_personas, "IdPersona", "IdPersona");
            return Page();
        }

        [BindProperty]
        public evas_momentos_responsables evas_momentos_responsables { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.eva_momentos_responsables.Add(evas_momentos_responsables);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}