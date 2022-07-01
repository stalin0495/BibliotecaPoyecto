using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServiciosDefinicion;
using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.RepositorioDefinicion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServicioImplementacion
{
    public class LibroServicio : ILibroServicio
    {
        private readonly ILibroRepositorio libroRepositorio;
        public LibroServicio(ILibroRepositorio libroRepositorio)
        {
            this.libroRepositorio = libroRepositorio;
        }

        public async Task<bool> CreateAsync(CreateLibroDto libroDto)
        {
            var libro = new Libro
            {
                Titulo = libroDto.Titulo,
                ISBN = libroDto.ISBN,
                AutorId = libroDto.AutorId,
                EditorialId = libroDto.EditorialId
            };
            await libroRepositorio.CreateAsync(libro);

            return true;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = libroRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var libro = consulta.SingleOrDefault();

            await libroRepositorio.DeleteAsync(libro);
            return true;
        }

        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
            var consulta = libroRepositorio.GetAll();
            var listaAutores = await consulta.Select(x => new LibroDto
            {
                Id = x.Id,
                Titulo = x.Titulo,
                ISBN = x.ISBN,
                Autor = x.Autor.Nombre,
                Editorial = x.Editorial.Direccion
            }).ToListAsync();

            return listaAutores;
        }

        public async Task<LibroDto> GetByIdAsync(int id)
        {
            var consulta = libroRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var libro = await consulta.Select(x => new LibroDto
            {
                Id = x.Id,
                Titulo = x.Titulo,
                ISBN = x.ISBN,
                Autor = x.Autor.Nombre,
                Editorial = x.Editorial.Direccion
            }).SingleOrDefaultAsync();

            return libro;
        }

        public async Task<bool> UpdateAsync(int id, CreateLibroDto libroDto)
        {
            var consulta = libroRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var libro = consulta.SingleOrDefault();

            //Establecer los nuevos valores
            libro.Titulo = libroDto.Titulo;
            libro.ISBN = libroDto.ISBN;
            libro.AutorId = libroDto.AutorId;
            libro.EditorialId = libroDto.EditorialId;
            
            await libroRepositorio.UpdateAsync(libro);
            return true;
        }
    }
}
