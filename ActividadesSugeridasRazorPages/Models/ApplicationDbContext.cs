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
      
       public DbSet<evas_evalua_competencias_responsables> eva_evalua_competencias_responsables { get; set; }


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

        public DbSet<Res_evento> Res_eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Plantilla Metodologia
            modelBuilder.Entity<eva_plantillas_metodologia>()
                .HasOne(e => e.Metodologia)
                .WithMany(b => b.PlantillaMetodologia)
                .HasForeignKey(p => p.IdMetodologia)
                .HasConstraintName("ForeignKey_PlantillaMetodologia_Metodologia");

            //Momentos Metodologias
            modelBuilder.Entity<eva_plantillas_momentos_metodologia>()
                .HasOne(e => e.PlantillaMetodologia)
                .WithMany(b => b.MomentosMetodologias)
                .HasForeignKey(p => p.IdPlantillaMetodo)
                .HasConstraintName("ForeignKey_MomentosMetodologia_PlantillaMetodologia");

            modelBuilder.Entity<eva_plantillas_momentos_metodologia>()
                .HasOne(e => e.Metodologia)
                .WithMany(b => b.MomentosMetodologias)
                .HasForeignKey(p => p.IdMetodologia)
                .HasConstraintName("ForeignKey_MomentosMetodologia_Metodologia");


            //Eva_Momentos_Metodologias-->Momentos Metodologias _  04-06-2018


            modelBuilder.Entity<eva_momentos_metodologias>()
               .HasOne(e => e.Metodologia)
               .WithMany(b => b.EvaMomentosMetodologias)
               .HasForeignKey(p => p.IdMetodologia)
               .HasConstraintName("ForeignKey_EvaMomentosMetodologia_Metodologia");

            modelBuilder.Entity<eva_momentos_metodologias>()
                 .HasOne(e => e.PlantillaMetodo)
                 .WithMany(b => b.EvaMomentosMetodologias)
                 .HasForeignKey(p => p.IdPlantillaMetodo)
                 .HasConstraintName("ForeignKey_EvaMomentosMetodologia_Plantilla");

            modelBuilder.Entity<eva_momentos_metodologias>()
               .HasOne(e => e.Momento)
               .WithMany(b => b.EvaMomentosMetodologias)
               .HasForeignKey(p => p.IdMomento)
               .HasConstraintName("ForeignKey_EvaMomentosMetodologia_Momento");





            //*Evaluacion momentos metodología
            //  modelBuilder.Entity<eva_momentos_metodologias>()
            //     .HasOne(e => e.PlantillaMetodologia)
            //    .WithMany(b => b.MomentosMetodologias)
            //   .HasForeignKey(p => p.IdPlantillaMetodo)
            //  .HasConstraintName("ForeignKey_MomentosMetodologia_PlantillaMetodologia");

            //modelBuilder.Entity<eva_plantillas_momentos_metodologia>()
            //   .HasOne(e => e.Metodologia)
            //  .WithMany(b => b.MomentosMetodologias)
            // .HasForeignKey(p => p.IdMetodologia)
            // .HasConstraintName("ForeignKey_MomentosMetodologia_Metodologia");*/

            //cat_Generales
            modelBuilder.Entity<cats_generales>()
                .HasOne(e => e.Gene)
                .WithMany(b => b.Generales)
                .HasForeignKey(p => p.IdTipoGeneral)
                .HasConstraintName("ForeignKey_CatGenerales_CatsTiposGenerales");


            //Eva_Momentos_Metodologias-->Tipos Generales _  04-06-2018
            modelBuilder.Entity<eva_momentos_metodologias>()
               .HasOne(e => e.cat_tipo_generales)
               .WithMany(b => b.GenEvaMomentosMetodologias)
               .HasForeignKey(p => p.IdTipoGenCalificacion)
               .HasConstraintName("ForeignKey_EvaMomentosMetodologias_CatsTiposGenerales");

            modelBuilder.Entity<eva_momentos_metodologias>()
               .HasOne(e => e.cat_generales)
               .WithMany(b => b.GenEvaMomentosMetodologias)
               .HasForeignKey(p => p.IdGenCalificacion)
               .HasConstraintName("ForeignKey_EvaMomentosMetodologias_CatsGenerales");


            //Eva_Momentos_Responsables -->Tipos Responsables _  04-06-2018
            modelBuilder.Entity<evas_momentos_responsables>()
               .HasOne(e => e.cat_generales)
               .WithMany(b => b.EvaMomentosResponsables)
               .HasForeignKey(p => p.IdGenResponsable)
               .HasConstraintName("ForeignKey_EvaMomentosResponsables_CatsTiposGenerales");

            modelBuilder.Entity<evas_momentos_responsables>()
               .HasOne(e => e.cat_tipo_generales)
               .WithMany(b => b.EvaMomentosResponsables)
               .HasForeignKey(p => p.IdTipoGenResponsable)
               .HasConstraintName("ForeignKey_EvaMomentosResponsables_CatsGenerales");

            /*RESPOSABLES*/
            modelBuilder.Entity<evas_momentos_responsables>()
                .HasKey(c => new { c.IdPersona, c.IdCompetencia, c.IdMomentoDet, c.IdResponsable });

            modelBuilder.Entity<evas_momentos_responsables>()
             .HasOne(e => e.cat_tipo_generales)
             .WithMany(b => b.EvaMomentosResponsables)
             .HasForeignKey(p => p.IdTipoGenResponsable)
             .HasConstraintName("ForeignKey_EvaMomentosMetodologias_CatsTiposGenerales");

            modelBuilder.Entity<evas_momentos_responsables>()
               .HasOne(e => e.cat_generales)
               .WithMany(b => b.EvaMomentosResponsables)
               .HasForeignKey(p => p.IdGenResponsable)
               .HasConstraintName("ForeignKey_EvaMomentosMetodologias_CatsGenerales");


            //primary key eva_evalua_competencias_responsables
            modelBuilder.Entity<evas_evalua_competencias_responsables>()
                .HasKey(c => new { c.IdPersona, c.IdCompetencia, c.IdOportunidad, c.IdResponsable });
        }


    }
}
