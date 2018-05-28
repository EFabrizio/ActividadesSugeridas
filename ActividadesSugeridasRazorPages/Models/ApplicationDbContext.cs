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

        public DbSet<eva_cats_metodologias> eva_cat_metodologias { get; set; }

        public DbSet<eva_plantillas_metodologia> eva_plantilla_metodologia { get; set; }

        public DbSet<eva_plantillas_momentos_metodologia> eva_plantilla_momentos_metodologia { get; set; }

        public DbSet<rh_cats_personas> rh_cat_personas { get; set; }

        public DbSet<eva_cats_tipo_competencias> eva_cat_tipo_competencias { get; set; }

        public DbSet<eva_cats_competencias> eva_cat_competencias { get; set; }

        public DbSet<eva_momentos_metodologias> eva_momentos_metodologia { get; set; }

        public DbSet<eva_momentos_metodologias_estatus> eva_momentos_metodologia_estatus { get; set; }

        public DbSet<evas_momentos_responsables> eva_momentos_responsables { get; set; }

        public DbSet<eva_evalua_competencias_personas> eva_evalua_competencias_persona { get; set; }

        public DbSet<cats_tipos_generales> cat_tipos_generales { get; set; }

        public DbSet<cats_generales> cat_generales { get; set; }


    }
}
