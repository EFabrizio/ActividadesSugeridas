using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_metodologias
{
    public class IndexModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public IndexModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_momentos_metodologias> eva_momentos_metodologias { get;set; }
        public string id;
        public string nombre;
        public string nomcompetencia;
        public string idcompetencia;

        public async Task OnGetAsync()
        {
            id = Request.Query["id"];
            nombre = Request.Query["nombre "];
            nomcompetencia= Request.Query["nomcompetencia"].ToString();
            idcompetencia = Request.Query["idcompetencia"].ToString();
            

            eva_momentos_metodologias = await _context.eva_momentos_metodologia
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.eva_cat_metodologias)
                .Include(e => e.eva_plantilla_metodologia)
                .Include(e => e.eva_plantilla_momentos_metodologia)
                .Include(e => e.rh_cat_personas).ToListAsync();
        }
    }
}
