using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasRazorPages.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_responsables
{
    public class CreateModel : PageModel
    {


        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

     public string idnombre;
     public string idmomento;
     public string idcompetencia;
     public string nombre;
     public string paterno;
     public string materno;
     public string desmomento;
     public string descompetencia;

        public CreateModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            idnombre = Request.Query["idper"];
            idmomento = Request.Query["idmom"];
            idcompetencia= Request.Query["idcom"];
            nombre = Request.Query["nombre"].ToString();
            paterno= Request.Query["paterno"].ToString();
            materno = Request.Query["materno"].ToString();
            desmomento = Request.Query["desmom"].ToString();
            descompetencia = Request.Query["descom"].ToString();

          



        ViewData["IdGenResponsable"] = new SelectList(_context.cat_generales, "IdGeneral", "IdGeneral");
        ViewData["IdTipoGenResponsable"] = new SelectList(_context.cat_tipos_generales, "IdTipoGeneral", "IdTipoGeneral");
            ViewData["IdCompetencia"] = idcompetencia; //new SelectList(_context.eva_cat_competencias, "IdCompetencia", "IdCompetencia");
            ViewData["IdMomentoDet"] = idmomento; //new SelectList(_context.eva_momentos_metodologia, "IdMomentoDet", "IdMomentoDet");
            ViewData["IdPersona"] = idcompetencia; // new SelectList(_context.rh_cat_personas, "IdPersona", "Nombre"  );
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

            _context.eva_momentos_responsables.Add(evas_momentos_responsables);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}