using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.Eva_momentos_metodologias
{
    public class CreateModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;
        public int idPerson;
        public int idComp;
        public string per;
        public string compe;
        public DateTime fechaActualizacion;
        public DateTime fechaReg;
        public Array metodos;
        public List<eva_plantillas_metodologia> eva_plantillas_metodologia { get; set; }
        public List<eva_plantillas_momentos_metodologia> eva_plantillas_momentos_metodologia { get; set; }
        public List<Res_evento> Res_evento { get; set; }



        public CreateModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
            eva_plantillas_metodologia = _context.eva_plantilla_metodologia.ToList();
            eva_plantillas_momentos_metodologia = _context.eva_plantilla_momentos_metodologia.ToList();
            Res_evento = _context.Res_eventos.ToList();
        }

        public IActionResult OnGet()
        {
            idPerson = Convert.ToInt32(Request.Query["idPer"]);
            idComp = Convert.ToInt32(Request.Query["idCompe"]);
            per = Request.Query["per"].ToString();
            compe = Request.Query["compe"].ToString();
            fechaActualizacion = DateTime.Today;
            fechaReg = DateTime.Today;


            ViewData["IdMetodologia"] = new SelectList(_context.eva_cat_metodologias, "IdMetodologia", "DesMetodologia");
        ViewData["IdMomento"] = new SelectList(_context.eva_plantilla_momentos_metodologia, "IdMomento", "DesMomento");
        ViewData["IdPlantillaMetodo"] = new SelectList(_context.eva_plantilla_metodologia, "IdPlantillaMetodo", "DesPlantillaMetodo");
          //  ViewData["IdGenCalificacion"] //new SelectList(_context.cat_generales.Where(e => e.IdTipoGeneral == 1), "IdGeneral", "DesGeneral");
        ViewData["IdTipoGenCalificacion"] = new SelectList(_context.cat_tipos_generales, "IdTipoGeneral", "IdTipoGeneral");
            ViewData["IdCompetencia"] = idComp; //new SelectList(_context.eva_cat_competencias, "IdCompetencia", "IdCompetencia");
            ViewData["IdPersona"] = idPerson; //new SelectList(_context.rh_cat_personas, "IdPersona", "IdPersona");
          ViewData["IdEvento"] = new SelectList(_context.Res_eventos, "IdEvento", "NombreEvento");
            return Page();
        }
        /*public async Task OnGetAsync()
        {
            eva_cats_metodologias = await _context.eva_cat_metodologias.ToList();
        }*/

        [BindProperty]
        public eva_momentos_metodologias eva_momentos_metodologias { get; set; }
      

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            idPerson = Convert.ToInt32(Request.Query["idPer"]);
            idComp = Convert.ToInt32(Request.Query["idCompe"]);
            per = Request.Query["per"].ToString();
            compe = Request.Query["compe"].ToString();

            _context.eva_momentos_metodologia.Add(eva_momentos_metodologias);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index",new{ id = idPerson});
        }
    }
}