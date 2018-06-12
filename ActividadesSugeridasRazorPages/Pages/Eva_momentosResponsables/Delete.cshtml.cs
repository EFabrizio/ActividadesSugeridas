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

        public int idPer;
        public int idCompe;
        public int idRes;

        public async Task<IActionResult> OnGetAsync(int? idPer,  short? idCompe, short? idMome, int? idRes)
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
                .Include(e => e.rh_cat_personas).FirstOrDefaultAsync(m => m.IdPersona == idPer);

            if (evas_momentos_responsables == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? idPer, short? idCompe, short? idMome, int? idRes)
        {
            record = _context.eva_momentos_responsables.Find(idPer, idCompe, idMome, idRes);

            if (record == null)
            {
                return NotFound();
            }

            evas_momentos_responsables = await _context.eva_momentos_responsables.FindAsync(idPer,idCompe,idMome,idRes);

            if (evas_momentos_responsables != null)
            {
                _context.eva_momentos_responsables.Remove(evas_momentos_responsables);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
