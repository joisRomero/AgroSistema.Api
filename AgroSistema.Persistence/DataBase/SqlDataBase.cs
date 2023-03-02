using AgroSistema.Application.Common.Interface;
using System.Data;
using System.Data.SqlClient;

namespace AgroSistema.Persistence.DataBase
{
    public class SqlDataBase : IDataBase
    {
        private SqlConnection _connection;
        private readonly string _connectionString;

        public SqlDataBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            //if (_connection == null || string.IsNullOrWhiteSpace(_connection.ConnectionString))
            //{
            //    _connection = new SqlConnection(_connectionString);
            //}

            _connection = new SqlConnection(_connectionString);
            return _connection;
        }
    }
}
