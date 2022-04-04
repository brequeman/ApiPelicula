using System;
using System.Collections.Generic;

namespace AccesoBD.Models.BD
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            PeliculaActors = new HashSet<PeliculaActor>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int IdDirector { get; set; }
        public int IdCategoria { get; set; }
        public int IdClasificacion { get; set; }
        public string Sinopsis { get; set; } = null!;
        public int Duracion { get; set; }

        public virtual Categoria CategoriaNavigation { get; set; } = null!;
        public virtual Clasificacion ClasificacionNavigation { get; set; } = null!;
        public virtual Director DirectorNavigation { get; set; } = null!;
        public virtual ICollection<PeliculaActor> PeliculaActors { get; set; }
    }
}
