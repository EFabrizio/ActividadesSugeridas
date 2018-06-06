using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class Cats_estatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdEstatus { get; set; }

        [ForeignKey("IdTipoEstatus")]
        public short IdTipoEstatus { get; set; }
        public virtual Cat_tipos_estatus Cat_tipo_estatus { get; set; }

        public string DesEstatus { get; set; }
        public DateTime FechaReg { get; set; }

       



    }
}
