using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_metodologias_estatus
{
    public class CreateModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;
        public DateTime fecha;
        public string idMomento;

        public CreateModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {


        idMomento = Request.Query["idMomento"];
        fecha = DateTime.Now;
        ViewData["IdEstatus"] = new SelectList(_context.cat_estatus, "IdEstatus", "IdEstatus");
        ViewData["IdTipoEstatus"] = new SelectList(_context.Cat_tipo_estatus, "IdTipoEstatus", "IdTipoEstatus");
        ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "IdCompetencia");
        ViewData["IdMomentoDet"] = new SelectList(_context.eva_momentos_metodologia, "IdMomentoDet", "IdMomentoDet");
        ViewData["IdPersona"] = new SelectList(_context.rh_cat_personas, "IdPersona", "IdPersona");
            return Page();
        }

        [BindProperty]
        public eva_momentos_metodologias_estatus eva_momentos_metodologias_estatus { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            idMomento = Request.Query["idMomento"];
            _context.eva_momentos_metodologia_estatus.Add(eva_momentos_metodologias_estatus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = idMomento });
        }
    }
}