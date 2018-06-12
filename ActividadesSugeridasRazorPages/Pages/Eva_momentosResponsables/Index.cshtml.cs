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
        public short idMomento;
        public short idCompetencia;
        

        public int? idPerson;
        public short idCompe;
        public string per;
        public string appat;
        public string appmat;
        public string compe;
        public string moment;


        public IndexModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<evas_momentos_responsables> evas_momentos_responsables { get;set; }
        public IList<rh_cats_personas> rh_cats_personas { get; set; }
        public IList<cats_generales> cats_generales { get; set; }

        public async Task OnGetAsync()
        {
            idPerson = Convert.ToInt32(Request.Query["idPer"]);
            idCompe = Convert.ToInt16(Request.Query["idCompe"]);
            idMomento = Convert.ToInt16(Request.Query["id"]);



            if (_context.rh_cat_personas.Find(idPerson) != null)
            {
                per = _context.rh_cat_personas.Find(idPerson).Nombre;
                appat = _context.rh_cat_personas.Find(idPerson).ApPaterno;
                appmat = _context.rh_cat_personas.Find(idPerson).ApMaterno;
            }

            if (_context.eva_cat_competencias.Find(idCompe) != null)
            {
                compe = _context.eva_cat_competencias.Find(idCompe).DesCompetencia;
            }

            if (_context.eva_momentos_metodologia.Find(idMomento) != null)
            {
                moment = _context.eva_momentos_metodologia.Find(idMomento).DesMomento;

            }

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
