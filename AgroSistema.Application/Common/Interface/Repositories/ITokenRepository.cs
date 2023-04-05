using AgroSistema.Domain.Entities.CrearTokenUsuarioAsync;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface ITokenRepository
    {
        Task CrearTokenUsuarioAsync(TokenUsuarioEntity crearTokenUsuarioEntity);
    }
}
