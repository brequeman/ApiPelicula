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
    public class ClasificacionManager
    {
        private bd_cinemaContext _context;

        public ClasificacionManager(bd_cinemaContext dbcontext)
        {
            _context = dbcontext;
        }

        public List<ClasificacionDTO> Listar()
        {
            try
            {
                List<ClasificacionDTO> lista = new List<ClasificacionDTO>();
                lista = _context.Clasificacions.Select(clasificacion => new ClasificacionDTO
                {
                    Id = clasificacion.Id,
                    Nombre = clasificacion.Nombre
                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int Crear(ClasificacionDTO clasificacion)
        {
            Clasificacion nuevoRegistro = new Clasificacion();
            nuevoRegistro.Nombre = clasificacion.Nombre;

            _context.Clasificacions.Add(nuevoRegistro);
            _context.SaveChanges();

            return nuevoRegistro.Id;
        }

        public void Editar(ClasificacionDTO clasificacion)
        {
            var objectoEncontrado = _context.Clasificacions.Find(clasificacion.Id);
            if (objectoEncontrado != null)
            {
                objectoEncontrado.Nombre = clasificacion.Nombre;
                _context.SaveChanges();
            }
        }
        public void Eliminar(int id)
        {
            var objetoEncontrado = _context.Clasificacions.Find(id);
            if (objetoEncontrado != null)
            {
                _context.Clasificacions.Remove(objetoEncontrado);
                _context.SaveChanges();
            }
        }

    }
}
