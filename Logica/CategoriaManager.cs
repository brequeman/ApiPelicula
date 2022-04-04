using AccesoBD.Models.BD;
using AccesoBD.Models.BDContext;
using AccesoBD.Models.DTO;

namespace Logica
{
    public class CategoriaManager
    {
        private bd_cinemaContext _context;

        public CategoriaManager(bd_cinemaContext dbcontext)
        {
            _context = dbcontext;
        }

        public List<CategoriaDTO> Listar()
        {
            try
            {
                List<CategoriaDTO> lista = new List<CategoriaDTO>();
                lista = _context.Categoria.Select(categoria => new CategoriaDTO
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre
                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int Crear(CategoriaDTO categoria)
        {
            Categoria nuevoRegistro = new Categoria();

            nuevoRegistro.Nombre = categoria.Nombre;

            _context.Categoria.Add(nuevoRegistro);
            _context.SaveChanges();
            return nuevoRegistro.Id;
        }

        public void Editar(CategoriaDTO categoria)
        {
            var objectoEncontrado = _context.Categoria.Find(categoria.Id);
            if (objectoEncontrado != null)
            {
                objectoEncontrado.Nombre = categoria.Nombre;
                _context.SaveChanges();
            }
        }
        public void Eliminar(int id)
        {
            var objetoEncontrado = _context.Categoria.Find(id);
            if (objetoEncontrado != null)
            {
                _context.Categoria.Remove(objetoEncontrado);
                _context.SaveChanges();
            }
        }

    }
}
