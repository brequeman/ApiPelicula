using AccesoBD.Models.BDContext;
using AccesoBD.Models.DTO;
using ApiPelicula.Models;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiPelicula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration { get; set; }
        private UsuarioManager _usuarioManager;

        public AuthController(IConfiguration configuration, bd_cinemaContext context)
        {
            _configuration = configuration;
            _usuarioManager = new UsuarioManager(context);
        }

        [HttpPost]
        public ActionResult Post(string correo, string clave)
        {
            string errorClave = _usuarioManager.ClaveValida(clave);
            if (string.IsNullOrEmpty(errorClave))
            {
                UsuarioDTO usuarioEncontrado = _usuarioManager.ObtenerUsuario(correo, clave);
                if (usuarioEncontrado.Id > 0)
                {
                    var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", usuarioEncontrado.Id.ToString()),
                        new Claim("Clave", usuarioEncontrado.Clave),
                        new Claim("Nombre", usuarioEncontrado.Nombre)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                            jwt.Issuer,
                            jwt.Audience,
                            claims,
                            expires: DateTime.Now.AddMinutes(20),
                            signingCredentials: signIn
                        );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Credenciales inválidas");
                }
            }
            else
            {
                return BadRequest(errorClave);
            }

            
        }

    }
}
