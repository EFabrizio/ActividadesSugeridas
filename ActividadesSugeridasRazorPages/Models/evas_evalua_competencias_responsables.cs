using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class evas_evalua_competencias_responsables
    {

        public int? IdResponsable { get; set; }
        public int? IdPersona { get; set; }
        public short? IdCompetencia { get; set; }
        public short? IdOportunidad { get; set; }
        public short? IdTipoGenResponsable { get; set; }
        public short? IdGenResponsable { get; set; }

    }
}
