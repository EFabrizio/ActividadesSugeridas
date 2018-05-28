using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class eva_momentos_metodologias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdMomentoDet { get; set; }

        [ForeignKey("IdPersona")]
        public int IdPersona { get; set; }
        public virtual rh_cats_personas rh_cat_personas { get; set; }

        [ForeignKey("IdCompetencia")]
        public short IdCompetencia { get; set; }
        public virtual eva_cats_competencias eva_cat_competencias { get; set; }

        public string DesMomento { get; set; }
        public string Objetivo { get; set; }
        public string ResultadoEsperado { get; set; }
        public string ResultadoObtenido { get; set; }
        public string Observaciones { get; set; }
        public short IdTipoGenCalificacion { get; set; }
        public short IdGenCalificacion { get; set; }
        public float Calificacion { get; set; }

        [ForeignKey("IdMetodologia")]
        public short IdMetodologia { get; set; }
        public virtual eva_cats_metodologias eva_cat_metodologias { get; set; }

        [ForeignKey("IdPlantillaMetodo")]
        public short IdPlantillaMetodo { get; set; }
        public virtual eva_plantillas_metodologia eva_plantilla_metodologia { get; set; }

        [ForeignKey("IdMomento")]
        public short IdMomento { get; set; }
        public virtual eva_plantillas_momentos_metodologia eva_plantilla_momentos_metodologia { get; set; }

        public DateTime FechaReg { get; set; }
        public DateTime FechaUltAct { get; set; }
        public DateTime FechaEvaluacion { get; set; }
        public short IdEmpSuc { get; set; }
        public int IdEvento { get; set; }


    }
}
