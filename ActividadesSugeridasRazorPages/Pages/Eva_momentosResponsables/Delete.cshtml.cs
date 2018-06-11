﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentosResponsables
{
    public class DeleteModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public DeleteModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public evas_momentos_responsables evas_momentos_responsables { get; set; }
        public evas_momentos_responsables record { get; set; }

        public int idMomento;
        public int personaId;
        public int competenciaId;

        public async Task<IActionResult> OnGetAsync(int? IdPer)
        {
            

           /* record = _context.eva_momentos_responsables.Find(IdPer, competenciaId, idMomento, IdRes);

            if (record == null)
            {
                return NotFound();
            }*/

            evas_momentos_responsables = await _context.eva_momentos_responsables
                .Include(e => e.cat_generales)
                .Include(e => e.cat_tipo_generales)
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.eva_momentos_metodologia)
                .Include(e => e.rh_cat_personas).SingleOrDefaultAsync(m => m.IdPersona == IdPer);

            if (evas_momentos_responsables == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            evas_momentos_responsables = await _context.eva_momentos_responsables.FindAsync(id);

            if (evas_momentos_responsables != null)
            {
                _context.eva_momentos_responsables.Remove(evas_momentos_responsables);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
