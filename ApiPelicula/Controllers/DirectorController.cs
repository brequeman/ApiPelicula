using AccesoBD.Models.BD;
using AccesoBD.Models.BDContext;
using AccesoBD.Models.DTO;
using Logica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPelicula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DirectorController : ControllerBase
    {
        private DirectorManager _directorManager;


        public DirectorController(bd_cinemaContext context)
        {
            _directorManager = new DirectorManager(context);
        }

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
