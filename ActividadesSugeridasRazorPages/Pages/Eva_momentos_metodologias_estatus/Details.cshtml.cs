using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_metodologias_estatus
{
    public class DetailsModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public DetailsModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
