using AccesoBD.Models.BD;
using AccesoBD.Models.BDContext;
using AccesoBD.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DirectorManager
    {
        private bd_cinemaContext _context;

        public DirectorManager(bd_cinemaContext dbcontext)
        {
            _context = dbcontext;
        }
        public List<DirectorDTO> Listar()
        {
            try
            {
                List<DirectorDTO> lista = new List<DirectorDTO>();
                lista = _context.Directors.Select(director => new DirectorDTO
                {
                    Nombre = director.Nombre,
                    Id = director.Id
                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int Crear(DirectorDTO director)
        {
            Director nuevoRegistro = new Director();
            nuevoRegistro.Nombre = director.Nombre;

            _context.Directors.Add(nuevoRegistro);
            _context.SaveChanges();
            return nuevoRegistro.Id;
        }

        public void Editar(DirectorDTO director)
        {
            var objectoEncontrado = _context.Directors.Find(director.Id);
            if (objectoEncontrado != null)
            {
                objectoEncontrado.Nombre = director.Nombre;
                _context.SaveChanges();
            }
        }
        public void Eliminar(int id)
        {
            var objetoEncontrado = _context.Directors.Find(id);
            if (objetoEncontrado != null)
            {
                _context.Directors.Remove(objetoEncontrado);
                _context.SaveChanges();
            }
        }

    }
}
