using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class rh_cats_personas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }
        public short IdInstituto { get; set; }
        public string NumControl { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public DateTime FechaNac { get; set; }
        public Boolean TipoPersona { get; set; }
        public Boolean Sexo { get; set; }
        public string RutaFoto { get; set; }
        public string Alias { get; set; }
        public short IdTipoGenOcupacion { get; set; }
        public short IdGenOcupacion { get; set; }
        public short IdTipoGenEstadoCivil { get; set; }
        public short IdGenEstadoCivil { get; set; }
        public Boolean Activo { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public Boolean Borrado { get; set; }

    }
}
