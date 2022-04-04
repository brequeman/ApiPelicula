using AccesoBD.Models.BD;
using AccesoBD.Models.DTO;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPelicula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private ActorManager _actorManager = new ActorManager();

        [HttpGet]
        public List<ActorDTO> ListarActor()
        {
            return _actorManager.Listar();
        }

        [HttpPost]
        public int CrearActor(ActorDTO actor)
        {
            return _actorManager.Crear(actor);
        }

        [HttpPut]
        public void EditarActor(ActorDTO actor)
        {
            _actorManager.Editar(actor);
        }

        [HttpDelete]
        public void EliminarActor(int id)
        {
            _actorManager.Eliminar(id);
        }

    }

}
