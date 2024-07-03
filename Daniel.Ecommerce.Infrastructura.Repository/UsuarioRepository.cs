using Daniel.Ecommerce.Domain.Entity;
using Daniel.Ecommerce.Infrastructure.Interface;
using Daniel.Ecommerce.Transversal.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.Ecommerce.Infrastructura.Repository
{
    public  class UsuarioRepository : IUsuarioRepository
    {
        // implementar propiedad de interfaz
        private readonly IConnectionFactory _dbConection;

        public UsuarioRepository(IConnectionFactory dbConection)
        {
            _dbConection = dbConection;
        }

        public async Task<Usuario> ValidarUsuario(string nombreUsuario, string contraseña)
        {
            using (var connection = _dbConection.GetDbConnection)
            {
                var query = "VerificarUsuario2";
                var parameters = new DynamicParameters();
                parameters.Add("nombreUsuario", nombreUsuario);
                parameters.Add("contrasena", contraseña);

                var usuarioData =  await connection.QuerySingleAsync<Usuario>(query, param: parameters, commandType: CommandType.StoredProcedure);
               
                

                


                return usuarioData;

            }
        }
    }
}
