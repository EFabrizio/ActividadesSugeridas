﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_metodologias_estatus
{
    public class CreateModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;
        public DateTime fecha;
        public int idMomento;
        public int personaId;
        public int competenciaId;

        public CreateModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("CreateChangeEvent/")]
        public IActionResult OnGet()
        {


        idMomento = Convert.ToInt32(Request.Query["idMomento"]);

            personaId = Convert.ToInt32(Request.Query["idPer"]);
            competenciaId = Convert.ToInt32(Request.Query["idCompe"]);
            fecha = DateTime.Now;
        ViewData["IdEstatus"] = new SelectList(_context.cat_estatus, "IdEstatus", "DesEstatus");
        ViewData["IdTipoEstatus"] = new SelectList(_context.Cat_tipo_estatus, "IdTipoEstatus", "DesTipoEstatus");
        ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "DesCompetencia");
        ViewData["IdMomentoDet"] = new SelectList(_context.eva_momentos_metodologia, "IdMomentoDet", "DesMomento");
        ViewData["IdPersona"] = new SelectList(_context.rh_cat_personas, "IdPersona", "Nombre");
            
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
            idMomento = Convert.ToInt32(Request.Query["idMomento"]);

            personaId = Convert.ToInt32(Request.Query["idPer"]);
            competenciaId = Convert.ToInt32(Request.Query["idCompe"]);


            string query = "SELECT TOP 1 * FROM eva_momentos_metodologia_estatus WHERE IdMomentoDet =" + idMomento + 
                "AND IdPersona = "+personaId+" AND IdCompetencia = "+competenciaId+" ORDER BY FechaEstatus DESC";
            var ultimoRegistro = _context.eva_momentos_metodologia_estatus.FromSql(query).SingleOrDefault();
            if (ultimoRegistro != null)
            {
                await _context.Database.ExecuteSqlCommandAsync(
                    "UPDATE eva_momentos_metodologia_estatus SET ACTUAL = 0 WHERE IDEstatusDet = {0}",
                    parameters: ultimoRegistro.IdEstatusDet);
            }

            _context.eva_momentos_metodologia_estatus.Add(eva_momentos_metodologias_estatus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = idMomento, idPer = personaId , idCompe = competenciaId });
        }
    }
}