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
    public class IndexModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public IndexModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_momentos_metodologias_estatus> eva_momentos_metodologias_estatus { get;set; }
        public string persona;
        public string momento;
        public short idDesMomento;
        public string competencia;
        public int momentoId;
        public short competenciaId;
        public int personaId;
        public short? metodologia_momento;
        public string appat;
        public string appmat;

        public async Task OnGetAsync()
        {

            metodologia_momento = Convert.ToInt16(Request.Query["id"]);
            personaId = Convert.ToInt32(Request.Query["idPer"]);
            competenciaId = Convert.ToInt16(Request.Query["idCompe"]);
    
            var metodologia = _context.eva_momentos_metodologia.Find(metodologia_momento);



                   



            momentoId = metodologia.IdMomento;
            if (_context.rh_cat_personas.Find(personaId) != null)
                persona = _context.rh_cat_personas.Find(personaId).Nombre;
                appat = _context.rh_cat_personas.Find(personaId).ApPaterno;
                appmat = _context.rh_cat_personas.Find(personaId).ApMaterno;

            if (_context.eva_cat_competencias.Find(competenciaId) != null)
            competencia = _context.eva_cat_competencias.Find(competenciaId).DesCompetencia;
            momento = metodologia.DesMomento;
            idDesMomento = metodologia.IdMomentoDet;
            eva_momentos_metodologias_estatus = await _context.eva_momentos_metodologia_estatus.FromSql("SELECT * FROM eva_momentos_metodologia_estatus " +
                "WHERE IdMomentoDet = "+metodologia_momento+" AND IdPersona = "+personaId+ " AND IdCompetencia = "+competenciaId)
                .Include(e => e.Cat_estatus)
                .Include(e => e.Cat_tipos_estatus)
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.eva_momentos_metodologia)
                .Include(e => e.rh_cat_personas).ToListAsync();

        }
    }
}
