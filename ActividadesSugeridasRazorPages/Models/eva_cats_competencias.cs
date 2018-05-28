using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class eva_cats_competencias
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdCompetencia { get; set; }

        [ForeignKey("IdTipoCompetencia")]
        public short IdTipoCompetencia { get; set; }
        public virtual eva_cats_tipo_competencias eva_cat_tipo_competencias { get; set; }

        public string DesCompetencia { get; set; }
        public string Detalle { get; set; }


    }
}
