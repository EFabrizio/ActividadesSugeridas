using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class evas_momentos_responsables
    {


        public int IdResponsable { get; set; }

        [ForeignKey("IdCompetencia")]
        public int IdPersona { get; set; }
        public virtual rh_cats_personas rh_cat_personas { get; set; }


        [ForeignKey("IdCompetencia")]
        public short IdCompetencia { get; set; }
        public virtual eva_cats_competencias eva_cat_competencias { get; set; }

        [ForeignKey("IdMomentoDet")]
        public short IdMomentoDet { get; set; }
        public virtual eva_momentos_metodologias eva_momentos_metodologia { get; set; }



        public short IdTipoGenResponsable { get; set; }
        public virtual cats_tipos_generales cat_tipo_generales { get; set; }


        public short IdGenResponsable { get; set; }
        public virtual cats_generales cat_generales { get; set; }
    }
}
