using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.eva_plantilla_momentos_metodologia
{
    public class DetailsModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public DetailsModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public eva_plantillas_momentos_metodologia eva_plantillas_momentos_metodologia { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_plantillas_momentos_metodologia = await _context.eva_plantilla_momentos_metodologia
                .Include(e => e.Metodologia)
                .Include(e => e.PlantillaMetodologia).SingleOrDefaultAsync(m => m.IdMomento == id);

            if (eva_plantillas_momentos_metodologia == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
