using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class eva_plantillas_momentos_metodologia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdMomento { get; set; }

       // [ForeignKey("IdMetodologia")]
       // public short IdMetodologia { get; set; }
       // public virtual eva_plantillas_metodologia Metodologia { get; set; }

       // [ForeignKey("IdPlantillaMetodo")]
       // public short IdPlantillaMetodo { get; set; }
       // public virtual eva_plantillas_metodologia PlantillaMetodologia{ get; set; }

        public short IdMetodologia { get; set; }
        public eva_cats_metodologias Metodologia { get; set; }

        public short IdPlantillaMetodo { get; set; }
        public eva_plantillas_metodologia PlantillaMetodologia { get; set; }

        public string DesMomento { get; set; }
        public string Objetivo { get; set; }
        public short Secuencia { get; set; }

        //public List<eva_plantillas_momentos_metodologia> MomentosMetodologias { get; set; }
        public List<eva_momentos_metodologias> EvaMomentosMetodologias { get; set; }


    }
}
