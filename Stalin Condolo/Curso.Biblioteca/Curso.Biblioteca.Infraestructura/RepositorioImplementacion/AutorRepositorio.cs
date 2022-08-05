using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.RepositorioDefinicion;
using Curso.Biblioteca.Infraestructura.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.RepositorioImplementacion
{
    public class AutorRepositorio : IAutorRepositorio
    {
            private readonly BibliotecaDbContext context;
            public AutorRepositorio(BibliotecaDbContext cntext)
            {
                context = cntext;
            }
        

        public async Task CreateAsync(Autor entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Autor entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
        public IQueryable<Autor> GetAll()
        {
            return context.Autores.AsQueryable();
        }
        public async Task<ICollection<Autor>> GetAllAsync()
        {
            return await context.Autores.ToListAsync();
        }

        public async Task UpdateAsync(Autor entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }


    }
}
