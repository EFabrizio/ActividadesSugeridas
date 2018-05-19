using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class Eva_cat_actividad_sugerida
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdActividadSugerida { get; set; }

        public String Tema { get; set; }
        [RegularExpression(@"^[a-zA-Z.\s]+$", ErrorMessage = "Solo Letras Porfavor")]
        [Required(ErrorMessage = "Escriba una Descripcion a la actividad")]
        public String DesActividad { get; set; }

        //[ForeignKey("IdTipoActividadSugerida")]
        //public int IdTipoActividadSugerida { get; set; }
        //public virtual TipoActividadSugerida TipoActividadSugerida { get; set; }

       // [Display(Name = "TipoActividadSugerida")]
        public short IdTipoActividadSug { get; set; }
        [ForeignKey("IdTipoActividadSug")]
        public virtual Eva_cat_tipo_actividad_sugerida Eva_cat_tipo_actividades_sugeridas { get; set; }
    }
}
