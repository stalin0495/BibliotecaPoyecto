using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServiciosDefinicion
{
    public interface IAutorServicio
    {
        Task<ICollection<AutorDto>> GetAllAsync();
        Task<AutorDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateAutorDto autorDto);
        Task<bool> UpdateAsync(int id, CreateAutorDto autorDto);
        Task<bool> DeleteAsync(int Id);
    }
}
