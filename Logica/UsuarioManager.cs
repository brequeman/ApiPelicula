using AccesoBD.Models.BD;
using AccesoBD.Models.BDContext;
using AccesoBD.Models.DTO;
using System.Text.RegularExpressions;

namespace Logica
{
    public class UsuarioManager
    {
        private bd_cinemaContext _context;

        public UsuarioManager(bd_cinemaContext dbcontext)
        {
            _context = dbcontext;
        }

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

        public string Crear(UsuarioDTO usuarioDTO)
        {
            if(_context.Usuarios.Where(u => u.Correo == usuarioDTO.Correo).Any())
            {
                return "El correo ya se encuetra registrado";
            }

            string errorClave = ClaveValida(usuarioDTO.Clave);

            if (string.IsNullOrEmpty(errorClave))
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = usuarioDTO.Nombre;
                usuario.Correo = usuarioDTO.Correo;
                usuario.Clave = usuarioDTO.Clave;

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return usuario.Id.ToString();
            }

            return errorClave;

            
        }

        public string ClaveValida(string clave)
        {
            Match matchNumeros = Regex.Match(clave, @"\d");
            Match matchEspeciales = Regex.Match(clave, @"[]@_?#!]");
            Match matchMayusculas = Regex.Match(clave, @"[A-Z]");
            Match matchMinuscula = Regex.Match(clave, @"[a-z]");

            if (!matchNumeros.Success)
            {
                return "Tu contraseña debe tener al menos un numero";
            }

            if (!matchEspeciales.Success)
            {
                return "Tu contraseña debe tener al menos uno de los siguientes caracteres especiales ']@_?#!'";
            }
            if (!matchMayusculas.Success)
            {
                return "Tu contraseña debe tener al menos un caracter mayuscula";
            }
            if (!matchMinuscula.Success)
            {
                return "Tu contraseña debe tener al menos un caracter minuscula";
            }
            return "";
        }
    }
}
