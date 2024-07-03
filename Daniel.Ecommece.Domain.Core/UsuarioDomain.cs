using Daniel.Ecommerce.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daniel.Ecommerce.Tranversal.Domain.Interfaces;
using Daniel.Ecommerce.Domain.Entity;


namespace Daniel.Ecommece.Domain.Core
{
    public class UsuarioDomain : IUsuarioDomain
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioDomain(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Task<Usuario> ValidarUsuario(string nombreUsuario, string contraseña)
        {
            return _usuarioRepository.ValidarUsuario(nombreUsuario, contraseña);
        }
    }
}
