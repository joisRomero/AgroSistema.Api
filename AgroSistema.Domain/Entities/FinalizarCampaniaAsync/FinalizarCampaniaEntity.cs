using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.FinalizarCampaniaAsync
{
    public class FinalizarCampaniaEntity
    {
        public int IdCampania { get; set; }
        public DateTime FechaFinaliza { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
