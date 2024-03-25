using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.ReabrirCampaniaAsync
{
    public class ReabrirCampaniaCommand : IRequest
    {
        public int IdCampania { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
