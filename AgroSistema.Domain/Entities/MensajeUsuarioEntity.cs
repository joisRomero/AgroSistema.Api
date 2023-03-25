using AgroSistema.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities
{
    public class MensajeUsuarioEntity : BaseEntity
    {
        public string? Codigo { get; set; }
        public Guid AplicacionGuid { get; set; }
        public string? Descripcion { get; set; }
    }
}
