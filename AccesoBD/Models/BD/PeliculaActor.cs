using System;
using System.Collections.Generic;

namespace AccesoBD.Models.BD
{
    public partial class PeliculaActor
    {
        public int IdActor { get; set; }
        public int IdPelicula { get; set; }
        public bool? Activo { get; set; }

        public virtual Actor ActorNavigation { get; set; } = null!;
        public virtual Pelicula PeliculaNavigation { get; set; } = null!;
    }
}
