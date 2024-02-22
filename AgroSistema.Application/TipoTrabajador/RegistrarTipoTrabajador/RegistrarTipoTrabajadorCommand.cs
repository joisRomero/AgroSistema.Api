using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoTrabajador.RegistrarTipoTrabajador
{
    public class RegistrarTipoTrabajadorCommand : IRequest
    {
        public string? NombreTipoTrabajador { get; set; }
        public string? DescripcionTipoTrabajador { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
