using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServiciosDefinicion
{
    public interface IEditorialServicio
    {
        Task<ICollection<EditorialDto>> GetAllAsync();
        Task<EditorialDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateEditorialDto EditorialDto);
        Task<bool> UpdateAsync(int id, CreateEditorialDto EditorialDto);
        Task<bool> DeleteAsync(int Id);
    }
}
