using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ValidarCodigoRecuperacionCuentaAsync
{
    public class ValidarTokenRecoveryAcountEntity
    {
        public string Correo { get; set; }
        public string Token { get; set; }
    }
}
