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
    public class PeliculaController : ControllerBase
    {
        private PeliculaManager _peliculaManager;

        public PeliculaController(bd_cinemaContext context)
        {
            _peliculaManager = new PeliculaManager(context);
        }


        [HttpGet]
        public List<PeliculaDTO> ListarPelicula()
        {

            return _peliculaManager.Listar();
        }

        [HttpGet("{id}")]
        public PeliculaDTO ObtenerPelicula(int id)
        {
            return _peliculaManager.ObtenerRegistro(id);
        }

        [HttpPost]
        public int CrearPelicula(PeliculaDTO pelicula)
        {
            return _peliculaManager.Crear(pelicula);
        }

        [HttpPut]
        public void EditarPelicula(PeliculaDTO pelicula)
        {
            _peliculaManager.Editar(pelicula);
        }

        [HttpDelete]
        public void EliminarPelicula(int id)
        {
            _peliculaManager.Eliminar(id);
        }
    }
}
