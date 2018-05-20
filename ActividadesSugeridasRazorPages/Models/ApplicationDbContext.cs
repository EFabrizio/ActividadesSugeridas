using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Eva_cat_tipo_actividad_sugerida> Eva_cat_tipo_actividades_sugeridas { get; set; }

        public DbSet<Eva_cat_actividad_sugerida> Eva_cat_actividades_sugeridas { get; set; }

        
        public DbSet<Eva_actividad_sug_estatus> Eva_actividades_sug_estatus { get; set; }

       

        public DbSet<Cat_tipos_estatus> Cat_tipo_estatus { get; set; }

        public DbSet<Cats_estatus> cat_estatus { get; set; }


    }
}
