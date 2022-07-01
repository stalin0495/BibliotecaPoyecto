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
    public class AutorServicio : IAutorServicio
    {
        private readonly IAutorRepositorio autorRepositorio;
        public AutorServicio(IAutorRepositorio autorRepositorio)
        {
            this.autorRepositorio = autorRepositorio;
        }

        public async Task<bool> CreateAsync(CreateAutorDto autorDto)
        {
            var autor = new Autor
            {
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido
            };
            await autorRepositorio.CreateAsync(autor);

            return true;
            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = autorRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var autor = consulta.SingleOrDefault();

            await autorRepositorio.DeleteAsync(autor);
            return true;
        }

        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            var consulta = autorRepositorio.GetAll();
            var listaAutores = await consulta.Select(x => new AutorDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).ToListAsync();

            return listaAutores;
        }

        public async Task<AutorDto> GetByIdAsync(int id)
        {
            var consulta = autorRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var autor = await consulta.Select(x => new AutorDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).SingleOrDefaultAsync();

            return autor;
        }

        public async Task<bool> UpdateAsync(int id, CreateAutorDto autorDto)
        {
            var consulta = autorRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var autor = consulta.SingleOrDefault();

            //Establecer los nuevos valores
            autor.Nombre = autorDto.Nombre;
            autor.Apellido = autorDto.Apellido;

            await autorRepositorio.UpdateAsync(autor);
            return true;
        }
    }
}
