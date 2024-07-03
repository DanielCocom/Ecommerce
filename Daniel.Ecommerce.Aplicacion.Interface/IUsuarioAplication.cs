using Daniel.Ecommerce.Aplicacion.Dto;
using Daniel.Ecommerce.Transversal.Common;

namespace Daniel.Ecommerce.Aplicacion.Interface
{
    public interface IUsuarioAplication
    {
         public Task<Response<UsuarioDto>> ValidarUsuario(string nombreUsuario, string constraseña);
    }
}
