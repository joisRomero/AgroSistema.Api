using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.ValidarCampania
{
    public class ValidarCampaniaCommand : IRequest<ValidarCampaniaDTO>
    {
        public int IdUsuario { get; set; }
        public int IdCampania { get; set; }
    }
}
