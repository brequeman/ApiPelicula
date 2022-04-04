using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoBD.Models.DTO
{
    public class PeliculaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Sinopsis { get; set; } = null!;
        public int Duracion { get; set; }
        public DirectorDTO Director { get; set; } = null!;
        public CategoriaDTO Categoria { get; set; } = null!;
        public ClasificacionDTO Clasificacion { get; set; } = null!;
        public List<ActorDTO> Actores { get; set; } = null!;
    }
}
