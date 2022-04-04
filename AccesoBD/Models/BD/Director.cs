using System;
using System.Collections.Generic;

namespace AccesoBD.Models.BD
{
    public partial class Director
    {
        public Director()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
