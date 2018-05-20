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
    public class IndexModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public IndexModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Eva_actividad_sug_estatus> Eva_actividades_sug_estatus { get; set; }
        public IList<Eva_cat_tipo_actividad_sugerida> Eva_cat_tipo_actividad_sugerida { get; set; }
        public IList<Eva_cat_actividad_sugerida> Eva_cat_actividad_sugerida { get; set; }
        public IList<Cat_tipos_estatus> Cat_tipo_estatus { get; set; }
        public IList<Cats_estatus> Cat_estatus { get; set; }
       


        public string message;
        public string description;
        public string tipo;
        public int Tipos;
        public int IdDescripcion;
        public int? IdActividad;


        public async Task OnGetAsync(int? id)
        {
            Eva_actividades_sug_estatus = await _context.Eva_actividades_sug_estatus
                .Include(a => a.Eva_cat_actividades_sugeridas)
                .Include(a => a.Eva_cat_tipo_actividades_sugeridas)
                .Include(a => a.IdEstatus).ToListAsync();

            Eva_cat_actividad_sugerida = await _context.Eva_cat_actividades_sugeridas
                .Include(a => a.Eva_cat_tipo_actividades_sugeridas).ToListAsync();

            Eva_cat_tipo_actividad_sugerida = await _context.Eva_cat_tipo_actividades_sugeridas.ToListAsync();


            IdActividad = id;
 

            foreach (var value in Eva_cat_actividad_sugerida)
            {
                if(id == value.IdActividadSugerida)
                {
                    message = value.Tema.ToString();
                    description =  value.DesActividad.ToString();
                    IdDescripcion = value.IdTipoActividadSug;

                    foreach (var val in Eva_cat_tipo_actividad_sugerida)
                    {
                        if (IdDescripcion == val.IdTipoActividadSug)
                        {
                            tipo = val.DesTipoActividadSug.ToString();
                            Tipos = (short)val.IdTipoActividadSug;
                        }
                    }

                }


            }
        }

        
    }
}
