using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ActividadesSugeridasRazorPages.Models
{
    public class Res_evento
    {
        [Key]
        public int IdEvento { get; set; }
        public int IdTipoGenEvento { get; set; }
        public int IdGenEvento { get; set; }
        public int IdPersonaReg { get; set; }
        public string NombreEvento { get; set; }
        public string Observacion { get; set; }
        public string Explicacion { get; set; }
        public string URL { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdEdificio { get; set; }
        public DateTime FechaReg { get; set; }
        public short UsuarioReg { get; set; }

    }
}
