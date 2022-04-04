using AccesoBD.Models.BD;
using AccesoBD.Models.DTO;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPelicula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private DirectorManager _directorManager = new DirectorManager();

        [HttpGet]
        public List<DirectorDTO> ListarDirector()
        {

            return _directorManager.Listar();


        }

        [HttpPost]
        public int CrearDirector(DirectorDTO director)
        {
            return _directorManager.Crear(director);
        }

        [HttpPut]
        public void EditarDirector(DirectorDTO director)
        {
            _directorManager.Editar(director);
        }

        [HttpDelete]
        public void EliminarDirector(int id)
        {
            _directorManager.Eliminar(id);
        }
    }
}
