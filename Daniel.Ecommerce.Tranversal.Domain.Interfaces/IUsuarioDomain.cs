using Daniel.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.Ecommerce.Tranversal.Domain.Interfaces
{
    public interface IUsuarioDomain
    {
        Task<Usuario> ValidarUsuario(string nombreUsuario, string contraseña);

    }
}
