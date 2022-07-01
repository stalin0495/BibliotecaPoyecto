using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServiciosDefinicion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase, ILibroServicio
    {
        private readonly ILibroServicio libroServicio;

        public LibroController(ILibroServicio libroServicio)
        {
            this.libroServicio = libroServicio;
        }
        [HttpPost]
        public async Task<bool> CreateAsync(CreateLibroDto LibroDto)
        {
            return await libroServicio.CreateAsync(LibroDto);
        }
        [HttpDelete]
        public async Task<bool> DeleteAsync(int Id)
        {
            return await libroServicio.DeleteAsync(Id);
        }
        [HttpGet]
        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
            return await libroServicio.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<LibroDto> GetByIdAsync(int id)
        {
            return await libroServicio.GetByIdAsync(id);
        }
        [HttpPut]
        public async Task<bool> UpdateAsync(int id, CreateLibroDto LibroDto)
        {
            return await libroServicio.UpdateAsync(id, LibroDto);
        }
    }
}
