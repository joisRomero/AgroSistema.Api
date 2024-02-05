using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cultivo.ModificarCultivosAsync
{
    public class ModificarCultivoCommand : IRequest
    {
        public int IdCultivo { get; set; }
        public string? NombreCultivo { get; set; }
        public int IdUsuario { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
