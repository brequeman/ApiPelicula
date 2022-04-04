using System;
using System.Collections.Generic;

namespace AccesoBD.Models.BD
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Clave { get; set; } = null!;
    }
}
