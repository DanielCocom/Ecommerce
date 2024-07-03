using Daniel.Ecommerce.Transversal.Common;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;

using System.Data;

namespace Daniel.Ecommerce.Infrastructure.Data
{
    // todo lo relacionado a la base de datos
    public class ConnectionFactory : IConnectionFactory
    {
         private readonly IConfiguration _configuration;
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration; //inyeccion por constructor
        }

        public IDbConnection GetDbConnection
        {
            // instancia de conexion abierta
            get{

                var sqlConnection = new SqlConnection();

                if (sqlConnection == null) return null;
                sqlConnection.ConnectionString = _configuration.GetConnectionString("northwindConnection");
                sqlConnection.Open();
                return sqlConnection;
            }


        }


    }
}
