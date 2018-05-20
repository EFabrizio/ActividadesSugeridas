using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Cat_estatus
{
    public class EditModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public EditModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cats_estatus Cats_estatus { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cats_estatus = await _context.cat_estatus
                .Include(c => c.Cat_tipos_estatus).SingleOrDefaultAsync(m => m.IdEstatus == id);

            if (Cats_estatus == null)
            {
                return NotFound();
            }
           ViewData["IdTipoEstatus"] = new SelectList(_context.Cat_tipo_estatus, "IdTipoEstatus", "IdTipoEstatus");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cats_estatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cats_estatusExists(Cats_estatus.IdEstatus))
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

        private bool Cats_estatusExists(short id)
        {
            return _context.cat_estatus.Any(e => e.IdEstatus == id);
        }
    }
}
