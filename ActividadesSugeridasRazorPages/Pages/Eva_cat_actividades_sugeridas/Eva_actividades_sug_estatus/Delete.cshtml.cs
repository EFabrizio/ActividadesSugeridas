using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_actividades_sug_estatus
{
    public class DeleteModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;
        public short? idAct;
     public int idacti;
        public string act;
        public DeleteModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Eva_actividad_sug_estatus Eva_actividad_sug_estatus { get; set; }
        public Cats_estatus Cats_Estatus { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            idAct = id;
            idacti = Convert.ToInt32(Request.Query["idacti"]);
            
            if (id == null)
            {
                return NotFound();
            }

            Eva_actividad_sug_estatus = await _context.Eva_actividades_sug_estatus
                .Include(a => a.Eva_cat_actividades_sugeridas)
                .Include(a => a.Eva_cat_tipo_actividades_sugeridas)
                .Include(a => a.Cat_estatus).SingleOrDefaultAsync(m => m.IdEstatusDet == id);

            if (Eva_actividad_sug_estatus == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Eva_actividad_sug_estatus = await _context.Eva_actividades_sug_estatus.FindAsync(id);

            if (Eva_actividad_sug_estatus != null)
            {
                _context.Eva_actividades_sug_estatus.Remove(Eva_actividad_sug_estatus);
                await _context.SaveChangesAsync();
            }

            act = Request.Query["idacti"];


            return RedirectToPage("./Index",  new {id = act});
        }
    }
}
