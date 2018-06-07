using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasRazorPages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Specialized;

namespace ActividadesSugeridasRazorPages.Pages.Eva_actividades_sug_estatus
{
    
    public class CreateModel : PageModel
    {
        
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;


        //Para sacar las listas de datos de las tablas
        //Tipos Actividades sugeridas y Actividades Sugeridas
        public IList<Eva_cat_tipo_actividad_sugerida> Eva_cat_tipo_actividad_sugerida { get; set; }
        public IList<Eva_cat_actividad_sugerida> Eva_cat_actividad_sugerida { get; set; }
        public IList<Cats_estatus> Cats_estatus { get; set; }

        //Para Obtener el Id de la actividad
        public int IdActividad;
        public int IdTipo;
        public string DesActividad;
        public string DesTipo;
        public string username;
        public string idAct;
        public string idTipo;
        public string Tema;
        public string descripcion;
        public string tipo;
        public DateTime fecha;
        public short IdTipoEstatus = 1;



        public CreateModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        
        }



        //Se le pasa como parametro el id que viene en el @page del index
        [HttpGet("CreateChangeEvent/")]
        public IActionResult OnGet()
        {
            idAct = Request.Query["id"];
            idTipo = Request.Query["idtipo"];
            Tema = Request.Query["tema"].ToString();
            tipo = Request.Query["destipo"].ToString();
            descripcion = Request.Query["desact"].ToString();
            fecha = DateTime.Now;
           

            ViewData["IdActividadSugerida"] = idAct; // new SelectList(_context.ActividadesSugeridas, "IdActividadSugerida", "DesActividad");
            ViewData["IdTipoActividadSug"] = idTipo;// new SelectList(_context.TipoActividadesSugeridas, "IdTipoActividadSugerida", "DesTipoActividadSugerida");
            ViewData["IdEstatus"] = new SelectList(_context.cat_estatus.Where(e=> e.IdTipoEstatus == 1), "IdEstatus", "DesEstatus");
           // ViewData["IdTipoEstatus"] = 1;//= new SelectList(_context.Set<TipoEstatus>(), "IdTipoEstatus", "DesTipoEstatus");
            return Page();
            
        }

        /*
        public async Task OnGetAsync(int id, int idtipo)
        {
           
            IdActividad = id;


            ActividadSugerida = await _context.ActividadesSugeridas
              .Include(a => a.TipoActividadesSugeridas).ToListAsync();

            TipoActividadSugerida = await _context.TipoActividadesSugeridas.ToListAsync();


            foreach (var value in ActividadSugerida)
            {
                if (id == value.IdActividadSugerida)
                {
                    IdActividad = id;
                    DesActividad = value.DesActividad.ToString();

                    foreach (var val in TipoActividadSugerida)
                    {
                        if (idtipo == val.IdTipoActividadSugerida)
                        {
                            IdTipo = val.IdTipoActividadSugerida;
                            DesTipo = val.DesTipoActividadSugerida.ToString();
                        }
                    }
                }
            }
        } */

        [BindProperty]
        public Eva_actividad_sug_estatus Eva_actividad_sug_estatus { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
           

            if (!ModelState.IsValid)
            {
                return Page();
            }



            string query = "SELECT TOP 1 * FROM eva_actividades_sug_estatus ORDER BY FechaEstatus DESC";
            var ultimoRegistro = _context.Eva_actividades_sug_estatus.FromSql(query).SingleOrDefault();

            await _context.Database.ExecuteSqlCommandAsync(
                "UPDATE eva_actividades_sug_estatus SET ACTUAL = 0 WHERE IDEstatusDet = {0}",
                parameters: ultimoRegistro.IdEstatusDet);

            _context.Eva_actividades_sug_estatus.Add(Eva_actividad_sug_estatus);
            await _context.SaveChangesAsync();

       


            idAct = Request.Query["id"];

            return RedirectToPage("./Index",new { id = idAct });
            //return Redirect("./Index"+idAct.ToString());
        }

        
        
    }
}
