using Daniel.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.Ecommerce.Infrastructure.Interface
{
    public interface IUsuarioRepository
    {
        // devolver objeto
        Task<Usuario> ValidarUsuario(string nombreUsuario, string contraseña);
    }
}
