using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class eva_momentos_metodologias_estatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdEstatusDet { get; set; }

        [ForeignKey("IdPersona")]
        public int IdPersona { get; set; }
        public virtual rh_cats_personas rh_cat_personas { get; set; }

        [ForeignKey("IdCompetencia")]
        public short IdCompetencia { get; set; }
        public virtual eva_cats_competencias eva_cat_competencias { get; set; }

        [ForeignKey("IdMomentoDet")]
        public short IdMomentoDet { get; set; }
        public virtual eva_momentos_metodologias eva_momentos_metodologia { get; set; }

        [ForeignKey("IdTipoEstatus")]
        public short IdTipoEstatus { get; set; }
        public virtual Cat_tipos_estatus Cat_tipo_estatus { get; set; }

        [ForeignKey("IdEstatus")]
        public short IdEstatus { get; set; }
        public virtual Cats_estatus cat_estatus { get; set; }

        public DateTime FechaEstatus { get; set; }
        public Boolean Actual { get; set; }
        public string Observacion { get; set; }
        public string IdUsuarioReg { get; set; }



    }
}
