using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_evalua_competencias_persona
{
    public class DetailsModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public DetailsModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public eva_evalua_competencias_personas eva_evalua_competencias_personas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_evalua_competencias_personas = await _context.eva_evalua_competencias_persona
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.eva_cat_tipo_competencias).SingleOrDefaultAsync(m => m.IdPersona == id);

            if (eva_evalua_competencias_personas == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
