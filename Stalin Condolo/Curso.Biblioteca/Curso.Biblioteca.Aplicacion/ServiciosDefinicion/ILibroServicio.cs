using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServiciosDefinicion
{
    public interface ILibroServicio
    {
        Task<ICollection<LibroDto>> GetAllAsync();
        Task<LibroDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateLibroDto LibroDto);
        Task<bool> UpdateAsync(int id, CreateLibroDto LibroDto);
        Task<bool> DeleteAsync(int Id);
    }
}
