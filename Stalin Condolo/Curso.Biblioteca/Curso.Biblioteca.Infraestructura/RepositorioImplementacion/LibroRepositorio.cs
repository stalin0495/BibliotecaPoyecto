using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.RepositorioDefinicion;
using Curso.Biblioteca.Infraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.RepositorioImplementacion
{
    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly BibliotecaDbContext context;
        public LibroRepositorio(BibliotecaDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Libro entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Libro entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public IQueryable<Libro> GetAllAsync()
        {
            return context.Libros.AsQueryable();
        }
        public IQueryable<Libro> GetAll()
        {
            return context.Libros.AsQueryable();
        }

        public async Task UpdateAsync(Libro entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
