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
    public class IndexModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public IndexModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }


        public IList<eva_evalua_competencias_personas> eva_evalua_competencias_personas { get;set; }
        public IList<rh_cats_personas> rh_cats_personas { get; set; }

        public async Task OnGetAsync()
        {
            eva_evalua_competencias_personas = await _context.eva_evalua_competencias_persona
                .Include(e => e.eva_cat_competencias)
                .Include(e => e.eva_cat_tipo_competencias).ToListAsync();

            rh_cats_personas = await _context.rh_cat_personas.ToListAsync();
        }
       

    }
    }

