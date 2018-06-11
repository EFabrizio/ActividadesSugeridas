using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_metodologias_estatus
{
    public class EditModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public EditModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_momentos_metodologias_estatus eva_momentos_metodologias_estatus { get; set; }

        public int idMomento;
        public int personaId;
        public int competenciaId;


        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            idMomento = Convert.ToInt32(Request.Query["idMomento"]);

            personaId = Convert.ToInt32(Request.Query["idPer"]);
            competenciaId = Convert.ToInt32(Request.Query["idCompe"]);

            eva_momentos_metodologias_estatus = await _context.eva_momentos_metodologia_estatus
                .Include(e => e.Cat_estatus)
                .Include(e => e.Cat_tipos_estatus)
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.eva_momentos_metodologia)
                .Include(e => e.rh_cat_personas).SingleOrDefaultAsync(m => m.IdEstatusDet == id);

            if (eva_momentos_metodologias_estatus == null)
            {
                return NotFound();
            }
           ViewData["IdEstatus"] = new SelectList(_context.cat_estatus, "IdEstatus", "DesEstatus");
           ViewData["IdTipoEstatus"] = new SelectList(_context.Cat_tipo_estatus, "IdTipoEstatus", "DesTipoEstatus");
           ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "DesCompetencia");
           ViewData["IdMomentoDet"] = new SelectList(_context.eva_momentos_metodologia, "IdMomentoDet", "DesMomento");
           ViewData["IdPersona"] = new SelectList(_context.rh_cat_personas, "IdPersona", "Nombre");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            idMomento = Convert.ToInt32(Request.Query["idMomento"]);

            personaId = Convert.ToInt32(Request.Query["idPer"]);
            competenciaId = Convert.ToInt32(Request.Query["idCompe"]);

            _context.Attach(eva_momentos_metodologias_estatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_momentos_metodologias_estatusExists(eva_momentos_metodologias_estatus.IdEstatusDet))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { id = idMomento, idPer = personaId, idCompe = competenciaId });
        }

        private bool eva_momentos_metodologias_estatusExists(short id)
        {
            return _context.eva_momentos_metodologia_estatus.Any(e => e.IdEstatusDet == id);
        }
    }
}
