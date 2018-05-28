using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class eva_plantillas_metodologia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdPlantillaMetodo { get; set; }

        [ForeignKey("IdMetodologia")]
        public short IdMetodologia { get; set; }
        public virtual eva_cats_metodologias eva_cat_metodologias { get; set; }

        public string DesPlantillaMetodo { get; set; }
        public DateTime FechaReg { get; set; }
        public Boolean VersionActual { get; set; }
        
    }
}
