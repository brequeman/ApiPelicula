using AccesoBD.Models.BD;
using AccesoBD.Models.DTO;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPelicula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private CategoriaManager _categoriaManager = new CategoriaManager();

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
