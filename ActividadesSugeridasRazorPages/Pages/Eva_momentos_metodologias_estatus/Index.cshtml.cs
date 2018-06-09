﻿using System;
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
        public string competencia;
        public int momentoId;
        public short competenciaId;
        public int personaId;



        public async Task OnGetAsync(short? id)
        {

            var metodologia = _context.eva_momentos_metodologia.Find(id);
            personaId = metodologia.IdPersona;
            competenciaId = metodologia.IdCompetencia;
            momentoId = metodologia.IdMomento;

            persona = _context.rh_cat_personas.Find(personaId).Nombre;
            competencia = _context.eva_cat_competencias.Find(competenciaId).DesCompetencia;
            momento = metodologia.DesMomento;


            eva_momentos_metodologias_estatus = await _context.eva_momentos_metodologia_estatus
                .Include(e => e.Cat_estatus)
                .Include(e => e.Cat_tipos_estatus)
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.eva_momentos_metodologia)
                .Include(e => e.rh_cat_personas).ToListAsync();
        }
    }
}
