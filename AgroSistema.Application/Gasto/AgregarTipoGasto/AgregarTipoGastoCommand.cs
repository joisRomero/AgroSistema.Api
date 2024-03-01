using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.AgregarTipoGasto
{
    public class AgregarTipoGastoCommand : IRequest
    {
        public string? NombreTipoGasto { get; set; }
        public int IdUsuario { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
