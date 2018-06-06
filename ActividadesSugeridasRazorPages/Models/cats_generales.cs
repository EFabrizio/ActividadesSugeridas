using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class cats_generales
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdGeneral { get; set; }

    //   [ForeignKey("IdTipoGeneral")]
       public short IdTipoGeneral { get; set; }
       public virtual cats_tipos_generales Gene { get; set; }

        public string DesGeneral { get; set; }

        //  public short IdTipoGeneral { get; set; }
        // public virtual cats_tipos_generales cat_tipos_generales { get; set; }
        public List<eva_momentos_metodologias> GenEvaMomentosMetodologias { get; set; }
        public List<evas_momentos_responsables> EvaMomentosResponsables { get; set; }
    }


}
