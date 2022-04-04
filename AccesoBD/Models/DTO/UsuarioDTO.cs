using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoBD.Models.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        
        [Required]
        [EmailAddress]
        public string Correo { get; set; } = null!;

        [StringLength(50, MinimumLength = 10, ErrorMessage = "La contraseña debe tener una longitud minima de {2} y máximo de {1}")]
        public string Clave { get; set; } = null!;
    }
}
