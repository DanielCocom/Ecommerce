using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Daniel.Ecommerce.Transversal.Common
{
    public interface IConnectionFactory
    {
        #region interfaz para obtener la conexion donde sea necesario
        IDbConnection GetDbConnection { get; }
        #endregion
    }
}
