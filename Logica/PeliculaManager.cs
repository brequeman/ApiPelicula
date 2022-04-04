using AccesoBD.Models.BD;
using AccesoBD.Models.BDContext;
using AccesoBD.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PeliculaManager
    {
        private bd_cinemaContext _context = new bd_cinemaContext();

        public List<PeliculaDTO> Listar()
        {
            try
            {
                List<PeliculaDTO> lista = new List<PeliculaDTO>();
                lista = _context.Peliculas.Select(pelicula => new PeliculaDTO
            {
                Duracion = pelicula.Duracion,
                Id = pelicula.Id,
                Nombre = pelicula.Nombre,
                Sinopsis = pelicula.Sinopsis,
                Categoria = new CategoriaDTO()
                {
                    Id = pelicula.IdCategoria,
                    Nombre = pelicula.CategoriaNavigation.Nombre
                },
                Director = new DirectorDTO()
                {
                    Id = pelicula.IdDirector,
                    Nombre = pelicula.DirectorNavigation.Nombre
                },
                Clasificacion = new ClasificacionDTO()
                {
                    Id = pelicula.IdClasificacion,
                    Nombre = pelicula.ClasificacionNavigation.Nombre
                },
                Actores = pelicula.PeliculaActors.Select(actor => new ActorDTO
                {
                    Id = actor.IdActor,
                    Nombre = actor.ActorNavigation.Nombre
                }).ToList()
            }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public PeliculaDTO ObtenerRegistro(int id)
        {
            try
            {
                PeliculaDTO pelicula = _context.Peliculas.Where(pelicula => pelicula.Id == id).
                    Select(pelicula => new PeliculaDTO
                    {
                    Duracion = pelicula.Duracion,
                    Id = pelicula.Id,
                    Nombre = pelicula.Nombre,
                    Sinopsis = pelicula.Sinopsis,
                    Categoria = new CategoriaDTO()
                    {
                        Id = pelicula.IdCategoria,
                        Nombre = pelicula.CategoriaNavigation.Nombre
                    },
                    Director = new DirectorDTO()
                    {
                        Id = pelicula.IdDirector,
                        Nombre = pelicula.DirectorNavigation.Nombre
                    },
                    Clasificacion = new ClasificacionDTO()
                    {
                        Id = pelicula.IdClasificacion,
                        Nombre = pelicula.ClasificacionNavigation.Nombre
                    },
                    Actores = pelicula.PeliculaActors.Select(actor => new ActorDTO
                    {
                        Id = actor.IdActor,
                        Nombre = actor.ActorNavigation.Nombre
                    }).ToList()
                }).First();

                return pelicula;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int Crear(PeliculaDTO pelicula)
        {
            Pelicula nuevoRegistro = new Pelicula()
            {
                Duracion = pelicula.Duracion,
                Nombre = pelicula.Nombre,
                Sinopsis = pelicula.Sinopsis,
                IdCategoria = pelicula.Categoria.Id,
                IdDirector = pelicula.Director.Id,
                IdClasificacion = pelicula.Clasificacion.Id
            };

            List<PeliculaActor> actores = new List<PeliculaActor>();
            for(int i = 0; i< pelicula.Actores.Count; i++)
            {
                PeliculaActor nuevo = new PeliculaActor();
                nuevo.IdActor = pelicula.Actores[i].Id;
                actores.Add(nuevo);
            }

            nuevoRegistro.PeliculaActors = actores;

            _context.Peliculas.Add(nuevoRegistro);
            _context.SaveChanges();
            return nuevoRegistro.Id;
        }

        public void Editar(PeliculaDTO pelicula)
        {
            var objectoEncontrado = _context.Peliculas.Find(pelicula.Id);
            if (objectoEncontrado != null)
            {
                objectoEncontrado.Nombre = pelicula.Nombre;
                objectoEncontrado.Sinopsis = pelicula.Sinopsis;
                objectoEncontrado.Duracion = pelicula.Duracion;
                objectoEncontrado.IdCategoria = pelicula.Categoria.Id;
                objectoEncontrado.IdDirector = pelicula.Director.Id;
                objectoEncontrado.IdClasificacion = pelicula.Clasificacion.Id;
                _context.PeliculaActors.RemoveRange(objectoEncontrado.PeliculaActors);
                
                List<PeliculaActor> actores = new List<PeliculaActor>();
                for (int i = 0; i < pelicula.Actores.Count; i++)
                {
                    PeliculaActor nuevo = new PeliculaActor();
                    nuevo.IdActor = pelicula.Actores[i].Id;
                    actores.Add(nuevo);
                }

                objectoEncontrado.PeliculaActors = actores;

                _context.SaveChanges();
            }
        }
        public void Eliminar(int id)
        {
            var objetoEncontrado = _context.Peliculas.Find(id);
            if (objetoEncontrado != null)
            {
                _context.Peliculas.Remove(objetoEncontrado);
                _context.SaveChanges();
            }
        }

    }
}
