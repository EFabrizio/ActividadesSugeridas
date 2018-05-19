using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class Eva_cat_tipo_actividad_sugerida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdTipoActividadSug { get; set; }
        [RegularExpression(@"^[a-zA-Z.\s]+$", ErrorMessage = "Solo Letras Po favo")]
        [Required(ErrorMessage = "Escriba una Descripcion a la actividad")]
        public String DesTipoActividadSug { get; set; }
    }
}
