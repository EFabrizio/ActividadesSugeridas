using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class Eva_actividad_sug_estatus
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdEstatusDet { get; set; }

        [ForeignKey("IdTipoActividadSug")]
        public short IdTipoActividadSug { get; set; }
        public virtual Eva_cat_tipo_actividad_sugerida Eva_cat_tipo_actividades_sugeridas { get; set; }

        [ForeignKey("IdActividadSugerida")]
        public int IdActividadSugerida { get; set; }
        public virtual Eva_cat_actividad_sugerida Eva_cat_actividades_sugeridas { get; set; }

        [ForeignKey("IdTipoEstatus")]
        public short IdTipoEstatus { get; set; }
        public virtual Cat_tipo_estatus Cat_tipos_estatus { get; set; }

        [ForeignKey("IdEstatus")]
        public short IdEstatus { get; set; }
        public virtual Cats_estatus Cat_estatus { get; set; }

        public DateTime FechaEstatus { get; set; }

        [StringLength(1, MinimumLength = 1)]
        public string Actual { get; set; }
        public string Observacion { get; set; }
        public string IdUsuarioReg { get; set; }



    }
}
