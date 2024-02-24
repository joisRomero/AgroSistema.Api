using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.EditarTipoGasto
{
    public class EditarTipoGastoCommand : IRequest
    {
        public int IdTipoGasto { get; set; }
        public string? NombreTipoGasto { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
