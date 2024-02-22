using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoTrabajador.ModificarTipoTrabajador
{
    public class ModificarTipoTrabajadorCommand : IRequest
    {
        public int IdTipoTrabajador { get; set; }
        public string? NombreTipoTrabajador { get; set; }
        public string? DescripcionTipoTrabajador { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
