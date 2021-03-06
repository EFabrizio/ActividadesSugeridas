﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentosResponsables
{
    public class CreateModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;
        
        public string persona;
        public string apellidomat;
        public string apellidopat;
        public string momento;
        public string competencia;
        public int idPersona;
        public short idMomento;
        public short idCompetencia;
        public List<evas_evalua_competencias_responsables> Responsables { get; set; }
        public List<eva_momentos_metodologias> Metodologias { get; set; }
        public List<evas_momentos_responsables> MomentosResponsables { get; set; }
        public evas_momentos_responsables record { get; set; }

        public int idPerson;
        public short idCompe;
        public short idComp;
        public short idMoment;
        public string per;
        public string appat;
        public string appmat;
        public string compe;
        public string moment;

        public CreateModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
           
        }

        public IActionResult OnGet()
         
        {

            /*idPersona = Convert.ToInt32(Request.Query["idPer"]);

        { 
            idPersona = Convert.ToInt32(Request.Query["idPer"]);

            idCompetencia = Convert.ToInt16(Request.Query["idCompe"]);
            idMomento = Convert.ToInt16(Request.Query["idMome"]);*/

            idPerson = Convert.ToInt32(Request.Query["idPer"]);
            idCompe = Convert.ToInt16(Request.Query["idCompe"]);
            idMoment = Convert.ToInt16(Request.Query["id"]);
            per = Request.Query["per"].ToString();
            compe = Request.Query["compe"].ToString();
            moment = Request.Query["moment"].ToString();


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




            Responsables = _context.eva_evalua_competencias_responsables.ToList();
            Metodologias = _context.eva_momentos_metodologia.ToList();
            MomentosResponsables = _context.eva_momentos_responsables.ToList();


            competencia = _context.eva_cat_competencias.Find(idCompetencia).DesCompetencia;
            momento = _context.eva_momentos_metodologia.Find(idMomento).DesMomento;
            persona = _context.rh_cat_personas.Find(idPersona).Nombre;
            apellidomat = _context.rh_cat_personas.Find(idPersona).ApMaterno;
            apellidopat = _context.rh_cat_personas.Find(idPersona).ApPaterno;


            ViewData["IdGenResponsable"] = new SelectList(_context.cat_generales.Where(e => e.IdTipoGeneral == 6), "IdGeneral", "DesGeneral");
            ViewData["IdTipoGenResponsable"] = 6;//new SelectList(_context.cat_tipos_generales, "IdTipoGeneral", "IdTipoGeneral");
            ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "IdCompetencia");
            ViewData["IdMomentoDet"] = new SelectList(_context.eva_momentos_metodologia, "IdMomentoDet", "IdMomentoDet");
            ViewData["IdPersona"] = new SelectList(_context.rh_cat_personas, "IdPersona", "Nombre");


            return Page();
        }

        [BindProperty]
        public evas_momentos_responsables evas_momentos_responsables { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            idPersona = Convert.ToInt32(Request.Query["idPer"]);
            idCompetencia = Convert.ToInt16(Request.Query["idCompe"]);
            idMomento = Convert.ToInt16(Request.Query["id"]);


            record = _context.eva_momentos_responsables.Find(idPersona, idCompetencia, idMomento, evas_momentos_responsables.IdResponsable);

            if (record == null)
            {
                _context.eva_momentos_responsables.Add(evas_momentos_responsables);
                await _context.SaveChangesAsync();
            }
          

            

        

            return RedirectToPage("./Index",new {id = idMomento, idPer = idPersona, idCompe = idCompetencia});
        }
    }
}