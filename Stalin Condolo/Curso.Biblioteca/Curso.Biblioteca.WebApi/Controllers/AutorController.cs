using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServiciosDefinicion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase, IAutorServicio
    {
        private readonly IAutorServicio autorServicio;

        public AutorController(IAutorServicio autorServicio)
        {
            this.autorServicio = autorServicio;
        }

        [HttpPost]
        public async Task<bool> CreateAsync(CreateAutorDto AutorDto)
        {
            return await autorServicio.CreateAsync(AutorDto);
        }
        [HttpDelete]
        public async Task<bool> DeleteAsync(int Id)
        {
            return await autorServicio.DeleteAsync(Id);
        }
        [HttpGet]
        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            return await autorServicio.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<AutorDto> GetByIdAsync(int id)
        {
            return await autorServicio.GetByIdAsync(id);
        }
        [HttpPut]
        public async Task<bool> UpdateAsync(int id, CreateAutorDto AutorDto)
        {
            return await autorServicio.UpdateAsync(id, AutorDto);
        }
    }
}
