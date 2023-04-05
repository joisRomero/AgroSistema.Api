using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.CrearTokenUsuarioAsync;
using Dapper;
using System.Data;

namespace AgroSistema.Persistence
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IDataBase _database;
        private readonly IDateTimeService _dateTimeService;

        public TokenRepository(IDataBase database, IDateTimeService dateTimeService)
        {
            _database = database;
            _dateTimeService = dateTimeService;
        }

        public async Task CrearTokenUsuarioAsync(TokenUsuarioEntity crearTokenUsuarioEntity)
        {
            using (var cnx = _database.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@identificador", crearTokenUsuarioEntity.Identificador);
                parameters.Add("@tipo", crearTokenUsuarioEntity.Tipo);
                parameters.Add("@valor", crearTokenUsuarioEntity.Valor);
                parameters.Add("@owner", crearTokenUsuarioEntity.Owner);
                parameters.Add("@fechaExpiracion", crearTokenUsuarioEntity.FechaExpiracion);
                parameters.Add("@fechaCreacion", _dateTimeService.Now);

                _ = await cnx.ExecuteAsync(
                    "sp_Token_Insertar",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
