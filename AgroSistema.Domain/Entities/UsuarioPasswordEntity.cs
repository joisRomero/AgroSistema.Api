using AgroSistema.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities
{
    public class UsuarioPasswordEntity : BaseEntity
    {
        public string PasswordHash { get; set; }
    }
}
