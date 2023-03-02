using System.Data;

namespace AgroSistema.Application.Common.Interface
{
    public interface IDataBase
    {
        IDbConnection GetConnection();
    }
}
