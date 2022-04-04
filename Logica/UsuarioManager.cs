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
    public class UsuarioManager
    {
        private bd_cinemaContext _context = new bd_cinemaContext();

        public UsuarioDTO ObtenerUsuario(string correo, string clave)
        {
            try
            {
                UsuarioDTO usuarioDTO = new UsuarioDTO();

                Usuario? usuarioExiste = _context.Usuarios.Where(u => u.Correo == correo && u.Clave == clave).FirstOrDefault();

                if (usuarioExiste != null)
                {
                    usuarioDTO.Clave = usuarioExiste.Clave;
                    usuarioDTO.Correo = usuarioExiste.Correo;
                    usuarioDTO.Id = usuarioExiste.Id;
                    usuarioDTO.Nombre = usuarioExiste.Nombre;
                }

                return usuarioDTO;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int Crear(UsuarioDTO usuarioDTO)
        {
            if(_context.Usuarios.Where(u => u.Correo == usuarioDTO.Correo).Any())
            {
                return -1;
            }

            Usuario usuario = new Usuario();
            usuario.Nombre = usuarioDTO.Nombre;
            usuario.Correo = usuarioDTO.Correo;
            usuario.Clave = usuarioDTO.Clave;

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario.Id;
        }


    }
}
