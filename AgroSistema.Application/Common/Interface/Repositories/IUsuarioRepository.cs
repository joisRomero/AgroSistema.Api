using AgroSistema.Domain.Entities.CrearUsuarioAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface IUsuarioRepository
    {
        Task<ResponseCrearUsuarioEntity> CrearUsuario(CrearUsuarioEntity crearUsuarioEntity);
        Task<bool> ValidarUsuario(string nombreUsuario);
    }
}
