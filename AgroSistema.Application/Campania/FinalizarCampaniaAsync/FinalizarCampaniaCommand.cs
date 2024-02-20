using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.FinalizarCampaniaAsync
{
    public class FinalizarCampaniaCommand : IRequest
    {
        public int IdCampania { get; set; }
        public DateTime FechaFinaliza { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
