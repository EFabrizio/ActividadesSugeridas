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

        [ForeignKey("IdMetodologia")]
        public short IdMetodologia { get; set; }
        public virtual eva_cats_metodologias eva_cat_metodologias { get; set; }

        [ForeignKey("IdPlantillaMetodo")]
        public short IdPlantillaMetodo { get; set; }
        public virtual eva_plantillas_metodologia eva_plantilla_metodologia { get; set; }

        public string DesMomento { get; set; }
        public string Objetivo { get; set; }
        public short Secuencia { get; set; }

    }
}
