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
    public class CategoriaController : ControllerBase
    {
        private CategoriaManager _categoriaManager;

        public CategoriaController(bd_cinemaContext context)
        {
            _categoriaManager = new CategoriaManager(context);
        }

        [HttpGet]
        public List<CategoriaDTO> ListarCategoria()
        {

            return _categoriaManager.Listar();


        }


        [HttpPost]
        public int CrearCategoria(CategoriaDTO categoria)
        {
            return _categoriaManager.Crear(categoria);
        }

        [HttpPut]
        public void EditarCategoria(CategoriaDTO categoria)
        {
            _categoriaManager.Editar(categoria);
        }

        [HttpDelete]
        public void EliminarCategoria(int id)
        {
            _categoriaManager.Eliminar(id);
        }
    }
}
