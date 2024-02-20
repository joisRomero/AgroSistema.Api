using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.ObtenerCampania
{
    public class ObtenerCampaniaCommand : IRequest<ObtenerCampaniaCommandDTO>
    {
        public int IdCampania { get; set; }
    }
}
