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
    public class ActorManager
    {
        private bd_cinemaContext _context;

        public ActorManager(bd_cinemaContext dbcontext)
        {
            _context = dbcontext;
        }

        public List<ActorDTO> Listar()
        {
            try
            {
                List<ActorDTO> lista = new List<ActorDTO>();
                lista = _context.Actors.Select(actor => new ActorDTO
                {
                    Id = actor.Id,
                    Nombre = actor.Nombre
                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public int Crear(ActorDTO actor)
        {
            Actor nuevoRegistro = new Actor();
            nuevoRegistro.Nombre = actor.Nombre;

            _context.Actors.Add(nuevoRegistro);
            _context.SaveChanges();
            return nuevoRegistro.Id;
        }
        public void Editar(ActorDTO actor)
        {
            var objetoEncontrado = _context.Actors.Find(actor.Id);
            if (objetoEncontrado != null)
            {
                objetoEncontrado.Nombre= actor.Nombre;
                _context.SaveChanges();
            }
        }
        public void Eliminar(int id)
        {
            var objetoEncontrado = _context.Actors.Find(id);
            if (objetoEncontrado != null)
            {
                _context.Actors.Remove(objetoEncontrado);
                _context.SaveChanges();
            }
        }

    }
}
