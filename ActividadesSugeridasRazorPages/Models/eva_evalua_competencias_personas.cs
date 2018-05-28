using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class eva_evalua_competencias_personas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }

        [ForeignKey("IdCompetencia")]
        public short IdCompetencia { get; set; }
        public virtual eva_cats_competencias eva_cat_competencias { get; set; }

        public short IdEmpSuc { get; set; }
        public short IdAsignatura { get; set; }
        public short IdTipoGenOrigenCompe { get; set; }
        public short IdGenOrigenCompe { get; set; }

        [ForeignKey("IdTipoCompetencia")]
        public short IdTipoCompetencia { get; set; }
        public virtual eva_cats_tipo_competencias eva_cat_tipo_competencias { get; set; }

        public DateTime FechaReg { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Justificacion { get; set; }


    }
}
