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
    public class ClasificacionController : ControllerBase
    {
        private ClasificacionManager _clasificacionaManager;

        public ClasificacionController(bd_cinemaContext context)
        {
            _clasificacionaManager = new ClasificacionManager(context);
        }

        [HttpGet]
        public List<ClasificacionDTO> ListarClasificacion()
        {

            return _clasificacionaManager.Listar();


        }


        [HttpPost]
        public int CrearClasificacion(ClasificacionDTO clasificacion)
        {
            return _clasificacionaManager.Crear(clasificacion);
        }

        [HttpPut]
        public void EditarClasificacion(ClasificacionDTO clasificacion)
        {
            _clasificacionaManager.Editar(clasificacion);
        }

        [HttpDelete]
        public void EliminarClasificacion(int id)
        {
            _clasificacionaManager.Eliminar(id);
        }
    }
}
