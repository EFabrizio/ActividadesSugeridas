using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_metodologias
{
    public class DetailsModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;
        public int idPerson;
        public int idComp;
        public string per;
        public string compe;

        public DetailsModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public eva_momentos_metodologias eva_momentos_metodologias { get; set; }
        public IList<Res_evento> Res_evento { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            idPerson = Convert.ToInt32(Request.Query["idPer"]);
            idComp = Convert.ToInt32(Request.Query["idCompe"]);
            per = Request.Query["per"].ToString();
            compe = Request.Query["compe"].ToString();

            Res_evento = await _context.Res_eventos.ToListAsync();

            if (id == null)
            {
                return NotFound();
            }

            eva_momentos_metodologias = await _context.eva_momentos_metodologia
                .Include(e => e.Metodologia)
                .Include(e => e.Momento)
                .Include(e => e.PlantillaMetodo)
                .Include(e => e.cat_generales)
                .Include(e => e.cat_tipo_generales)
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.rh_cat_personas).SingleOrDefaultAsync(m => m.IdMomentoDet == id);

            if (eva_momentos_metodologias == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
