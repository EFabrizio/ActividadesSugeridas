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
    public class IndexModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public IndexModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_momentos_metodologias> eva_momentos_metodologias { get;set; }

        public int? idPerson;
        public short idCompe;
        public string per;
        public string compe;
        public DateTime fecha;

        public async Task OnGetAsync(short? id)
        {

            idPerson = id;
            idCompe = _context.eva_evalua_competencias_persona.Find(idPerson).IdCompetencia;
                 
            fecha = DateTime.Now;

            per = _context.rh_cat_personas.Find(idPerson).Nombre;
            compe = _context.eva_cat_competencias.Find(idCompe).DesCompetencia;
            eva_momentos_metodologias = await _context.eva_momentos_metodologia
                .Include(e => e.Metodologia)
                .Include(e => e.Momento)
                .Include(e => e.PlantillaMetodo)
                .Include(e => e.cat_generales)
                .Include(e => e.cat_tipo_generales)
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.rh_cat_personas).ToListAsync();
            
        }
    }
}
