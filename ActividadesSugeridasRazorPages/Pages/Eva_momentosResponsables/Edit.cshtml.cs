﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;
using System.Data;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentosResponsables
{
    public class EditModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public EditModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public evas_momentos_responsables evas_momentos_responsables { get; set; }
        public evas_momentos_responsables record { get; set; }

        public async Task<IActionResult> OnGetAsync(int? idPer, short? idCompe, short? idMome, int? idRes)
        {
             record = _context.eva_momentos_responsables.Find(idPer, idCompe, idMome, idRes);

            if (record == null)
            {
                return NotFound();
            }

            evas_momentos_responsables = await _context.eva_momentos_responsables
                .Include(e => e.cat_generales)
                .Include(e => e.cat_tipo_generales)
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.eva_momentos_metodologia)
                .Include(e => e.rh_cat_personas).SingleOrDefaultAsync(m => m.IdPersona == idPer);

            if (evas_momentos_responsables == null)
            {
                return NotFound();
            }
           ViewData["IdGenResponsable"] = new SelectList(_context.cat_generales, "IdGeneral", "IdGeneral");
           ViewData["IdTipoGenResponsable"] = new SelectList(_context.cat_tipos_generales, "IdTipoGeneral", "IdTipoGeneral");
           ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "IdCompetencia");
           ViewData["IdMomentoDet"] = new SelectList(_context.eva_momentos_metodologia, "IdMomentoDet", "IdMomentoDet");
           ViewData["IdPersona"] = new SelectList(_context.rh_cat_personas, "IdPersona", "IdPersona");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(evas_momentos_responsables).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!evas_momentos_responsablesExists(evas_momentos_responsables.IdPersona))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool evas_momentos_responsablesExists(int id)
        {
            return _context.eva_momentos_responsables.Any(e => e.IdPersona == id);
        }
    }
}
