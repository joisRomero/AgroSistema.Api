using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.EliminarCampaniaAsync
{
    public class EliminarCampaniaCommand :IRequest
    {
        public int IdCampania { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
