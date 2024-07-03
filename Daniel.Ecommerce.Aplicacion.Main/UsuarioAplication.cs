using AutoMapper;
using Daniel.Ecommerce.Aplicacion.Dto;
using Daniel.Ecommerce.Aplicacion.Interface;
using Daniel.Ecommerce.Transversal.Common;
using Daniel.Ecommerce.Tranversal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.Ecommerce.Aplicacion.Main
{
    public class UsuarioAplication : IUsuarioAplication
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioDomain _usuarioDomain;
        
        public UsuarioAplication(IUsuarioDomain usuarioDomain, IMapper mapper)
        {
            _mapper = mapper;
            _usuarioDomain = usuarioDomain;

        }
        public async Task<Response<UsuarioDto>> ValidarUsuario(string nombreUsuario, string contraseña)
        {
            var response = new Response<UsuarioDto>();
            if (String.IsNullOrEmpty(nombreUsuario) || String.IsNullOrEmpty(contraseña))
            {
                response.IsSuccess = false;
                response.Message = "Informacion no puede ser vacia";
                return response;
                   
            }
            // el uso de esta clausula es para recortar el uso de if
            try
            {
                var usuario = await _usuarioDomain.ValidarUsuario(nombreUsuario, contraseña);

                 
                response.Data =  _mapper.Map<UsuarioDto>(usuario);
                    response.IsSuccess = true;
                    response.Message = "Autetificacion Exitosa";


                

            }
            catch (InvalidOperationException)
            {
                response.Message = "El usuario no existe";

            }
            
            catch (Exception ex)
            {
                response.IsSuccess=false;

                
                response.Message = ex.Message;

            }
           
            return response;
            
            

        }

    }
}
