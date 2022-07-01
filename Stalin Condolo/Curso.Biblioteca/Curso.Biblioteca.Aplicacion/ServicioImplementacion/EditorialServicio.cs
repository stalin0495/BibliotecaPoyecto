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
    public class EditorialServicio : IEditorialServicio
    {
        private readonly IEditorialRepositorio editorialRepositorio;
        public EditorialServicio(IEditorialRepositorio editorialRepositorio)
        {
            this.editorialRepositorio = editorialRepositorio;
        }

        public async Task<bool> CreateAsync(CreateEditorialDto editorialDto)
        {
            var editorial = new Editorial
            {
                Nombre = editorialDto.Nombre,
                Direccion = editorialDto.Direccion
            };
            await editorialRepositorio.CreateAsync(editorial);

            return true;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = editorialRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var editorial = consulta.SingleOrDefault();

            await editorialRepositorio.DeleteAsync(editorial);
            return true;
        }

        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
            var consulta = editorialRepositorio.GetAll();
            var listaAutores = await consulta.Select(x => new EditorialDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Direccion = x.Direccion
            }).ToListAsync();

            return listaAutores;
        }

        public async Task<EditorialDto> GetByIdAsync(int id)
        {
            var consulta = editorialRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var editorial = await consulta.Select(x => new EditorialDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Direccion = x.Direccion
            }).SingleOrDefaultAsync();

            return editorial;
        }

        public async Task<bool> UpdateAsync(int id, CreateEditorialDto EditorialDto)
        {
            var consulta = editorialRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var editorial = consulta.SingleOrDefault();

            //Establecer los nuevos valores
            editorial.Nombre = EditorialDto.Nombre;
            editorial.Direccion = EditorialDto.Direccion;

            await editorialRepositorio.UpdateAsync(editorial);
            return true;
        }
    }
}
