using AgroSistema.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.CrearTokenUsuarioAsync
{
    public class TokenUsuarioEntity : BaseEntity
    {
        public Guid Identificador { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public string Owner { get; set; }
        public DateTime FechaExpiracion { get; set; }
    }
}
