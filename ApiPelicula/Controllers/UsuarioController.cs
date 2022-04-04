using AccesoBD.Models.BDContext;
using AccesoBD.Models.DTO;
using Logica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ApiPelicula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioManager _usuarioManager;

        public UsuarioController(bd_cinemaContext context)
        {
            _usuarioManager = new UsuarioManager(context);
        }

        [HttpPost]
        public ActionResult<string> RegistrarUsuario(UsuarioDTO usuario)
        {
            string respuesta = _usuarioManager.Crear(usuario);

            if (Regex.IsMatch(respuesta, @"^[0-9]+$"))
            {
                return Ok("Usuario registrado");
            }
            else
            {
                return BadRequest(respuesta);
            }

            
        }
    }
}
