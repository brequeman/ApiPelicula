using System;
using System.Collections.Generic;

namespace AccesoBD.Models.BD
{
    public partial class Actor
    {
        public Actor()
        {
            PeliculaActors = new HashSet<PeliculaActor>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<PeliculaActor> PeliculaActors { get; set; }
    }
}
