using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class eva_cats_metodologias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdMetodologia { get; set; }
        public string DesMetodologia {get; set;}
        public string Clave { get; set; }
        public string Explicacion { get; set; }

        public List<eva_plantillas_metodologia> PlantillaMetodologia { get; set; }
        public List<eva_plantillas_momentos_metodologia> MomentosMetodologias { get; set; }
        public List<eva_momentos_metodologias> EvaMomentosMetodologias { get; set; }

    }
}
