using AgroSistema.Domain.Entities.LoginAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface ILoginRepository
    {
        Task<LoginEntity> ObtenerUsuarioAsync(string usuario, string clave);
        Task<int> ValidarUsuarioAsync(string usuario, string clave);
    }
}
