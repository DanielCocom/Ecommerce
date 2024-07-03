using Microsoft.AspNetCore.Mvc;
using Daniel.Ecommerce.Services.WebApi.Helpers;
using Daniel.Ecommerce.Aplicacion.Interface;
using Daniel.Ecommerce.Aplicacion.Dto;
using Daniel.Ecommerce.Transversal.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
namespace Daniel.Ecommerce.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAplication _usuarioAplication;
        private readonly AppSettings _appSettings;

        public UsuarioController(IUsuarioAplication usuarioAplication, AppSettings appSettings)
        {
            _appSettings = appSettings;
            _usuarioAplication = usuarioAplication;
        }
        // permite el acceso para generar el token
        [AllowAnonymous]
        [HttpPost("si")]
        public async Task<IActionResult> AutenticarUsuario([FromBody] UsuarioDto usuarioDto ) 
        {
            var response = await _usuarioAplication.ValidarUsuario(usuarioDto.nombreUsuario, usuarioDto.contraseña);
            if(response.IsSuccess)
            {
                if(response.Data != null)
                {

                    response.Data.token = CreateToken(response);
                    Console.WriteLine("Token generado");
                    return Ok(response);    
                }
                else
                {
                    return NotFound(response.Message);
                }
            }
                return BadRequest(response.Message);




        }
        private string CreateToken(Response<UsuarioDto> usuarioDto)
        {
            if (usuarioDto == null || usuarioDto.Data == null)
            {
                throw new ArgumentNullException(nameof(usuarioDto), "El objeto usuarioDto no puede ser nulo.");
            }

            try 
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                //Describe los atributos para emitir el token
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                      {
                      new Claim(ClaimTypes.Name, usuarioDto.Data.nombreUsuario)
                      }
                    ),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _appSettings.Issuer,
                    Audience = _appSettings.Audience,


                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return tokenString;

            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            


        }

       
    }
}
