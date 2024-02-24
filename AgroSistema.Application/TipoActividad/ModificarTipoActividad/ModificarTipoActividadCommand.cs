using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoActividad.ModificarTipoActividad
{
    public class ModificarTipoActividadCommand :IRequest
    {
        public int IdTipoActividad { get; set; }
        public string? NombreTipoActividad { get; set; }
        public string? RealizadaPorTipoActividad { get; set; }
        public string? DescripcionTipoActividad { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
