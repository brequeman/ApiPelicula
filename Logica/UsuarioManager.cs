using AccesoBD.Models.BD;
using AccesoBD.Models.BDContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class UsuarioManager
    {
        private bd_cinemaContext _context = new bd_cinemaContext();

        public List<Usuario> Listar()
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();
                lista = _context.Usuarios.ToList();

                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int Crear(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario.Id;
        }

        public void Editar(Usuario usuario)
        {
            var objectoEncontrado = _context.Usuarios.Find(usuario.Id);
            if (objectoEncontrado != null)
            {
                objectoEncontrado.Nombre = usuario.Nombre;
                _context.SaveChanges();
            }
        }
        public void Eliminar(int id)
        {
            var objetoEncontrado = _context.Usuarios.Find(id);
            if (objetoEncontrado != null)
            {
                _context.Usuarios.Remove(objetoEncontrado);
                _context.SaveChanges();
            }
        }

    }
}
