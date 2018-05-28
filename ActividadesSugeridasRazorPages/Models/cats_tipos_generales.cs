using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class cats_tipos_generales
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdTipoGeneral { get; set; }
        public string DesTipo { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public Boolean Activo { get; set; }
        public Boolean Borrado { get; set; }


    }
}
