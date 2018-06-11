using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_responsables
{
    public class IndexModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public IndexModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<evas_momentos_responsables> evas_momentos_responsables { get;set; }
        public IList<rh_cats_personas> personas { get; set; }
        public IList<eva_cats_competencias> competencias { get; set; }
        public IList<eva_momentos_metodologias> momentos { get; set; }
        public IList<eva_momentos_metodologias> momentoscompetencia { get; set; }
        public IList<eva_momentos_metodologias> momentosdatos { get; set; }
        public IList<rh_cats_personas> rh_cats_personas { get; set; }
        public IList<cats_generales> cats_Generales { get; set; }

        public string nombrePersona;
        public string apellidoPaterno;
        public string apellidoMaterno;
        public string desCompetencia;
        public string desMomento;
        public int? IdMomentoDet;
        public int? IdNombre;
        public int? IdCompetencia;


        public async Task OnGetAsync(short? id)
        {

            rh_cats_personas = await _context.rh_cat_personas.ToListAsync();

            cats_Generales  = await _context.cat_generales.ToListAsync();


            evas_momentos_responsables = await _context.eva_momentos_responsables
                .Include(e => e.cat_generales)
                .Include(e => e.cat_tipo_generales)
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.eva_momentos_metodologia)
                .Include(e => e.rh_cat_personas).ToListAsync();
            IdMomentoDet = id;

            momentos = await _context.eva_momentos_metodologia
                .Include(a => a.rh_cat_personas).ToListAsync();

            personas = await _context.rh_cat_personas.ToListAsync();



            momentoscompetencia = await _context.eva_momentos_metodologia
               .Include(a => a.eva_cat_competencias).ToListAsync();


            competencias = await _context.eva_cat_competencias.ToListAsync();

            momentosdatos = await _context.eva_momentos_metodologia.ToListAsync();

            /*momentos = await _context.eva_momentos_metodologia
                .Include(a => a.eva_cat_competencias).ToListAsync();*/


            foreach (var value in momentos)
            {
                if (id == value.IdMomentoDet)
                {
                        IdNombre = value.IdPersona;


                    foreach (var val in personas)
                    {
                        if (IdNombre == val.IdPersona)
                        {
                            nombrePersona = val.Nombre.ToString();
                            apellidoPaterno = val.ApPaterno.ToString();
                            apellidoMaterno = val.ApMaterno.ToString();
                            //Tipos = (short)val.IdTipoActividadSug;
                        }
                    }

                }


            }


            //Ciclo para las competencias
            foreach (var value in momentos)
            {
                if (id == value.IdMomentoDet)
                {
                    IdCompetencia = value.IdCompetencia;


                    foreach (var val in competencias)
                    {
                        if (IdCompetencia == val.IdCompetencia)
                        {

                            desCompetencia = val.DesCompetencia.ToString();


                        }
                    }

                }


            }

            //Ciclo para las competencias

            foreach (var value in momentosdatos)
            {
                if (id == value.IdMomentoDet)
                {

                    desMomento = value.DesMomento;

                    

                }


            }

        }
    }
}
