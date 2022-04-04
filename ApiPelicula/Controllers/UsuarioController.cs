using AccesoBD.Models.DTO;
using Logica;
using Microsoft.AspNetCore.Mvc;

namespace ApiPelicula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioManager _usuarioManager = new UsuarioManager();

        [HttpPost]
        public string RegistrarPelicula(UsuarioDTO usuario)
        {
            int respuesta = _usuarioManager.Crear(usuario);

            if(respuesta == -1) {
                return "El correo ya se encuetra registrado";
            }

            return "Ok - Usuario registrado";
        }
    }
}
