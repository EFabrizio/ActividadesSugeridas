using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentosResponsables
{
    public class IndexModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;
        public string persona;
        public string apellidopat;
        public string apellidomat;
        public string momento;
        public string competencia;
        public int idPersona;
        public int idMomento;
        public int idCompetencia;

        public IndexModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<evas_momentos_responsables> evas_momentos_responsables { get;set; }
        public IList<rh_cats_personas> rh_cats_personas { get; set; }
        public IList<cats_generales> cats_generales { get; set; }

        public async Task OnGetAsync()
        {
            idPersona = Convert.ToInt32(Request.Query["idPer"]);
            idCompetencia = Convert.ToInt32(Request.Query["idCompe"]);
            idMomento = Convert.ToInt32(Request.Query["id"]);
            persona = Request.Query["Per"].ToString();
            competencia = Request.Query["Compe"].ToString();
            momento = Request.Query["momento"].ToString();
            //apellidomat = _context.rh_cat_personas.Find(idPersona).ApMaterno;
            //apellidopat = _context.rh_cat_personas.Find(idPersona).ApPaterno;
            rh_cats_personas = await _context.rh_cat_personas.ToListAsync();
            cats_generales = await _context.cat_generales.ToListAsync();


            evas_momentos_responsables = await _context.eva_momentos_responsables
                .Include(e => e.cat_generales)
                .Include(e => e.cat_tipo_generales)
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.eva_momentos_metodologia)
                .Include(e => e.rh_cat_personas).ToListAsync();
        }
    }
}
