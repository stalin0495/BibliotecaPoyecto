using Curso.Biblioteca.Aplicacion.ServicioImplementacion;
using Curso.Biblioteca.Aplicacion.ServiciosDefinicion;
using Curso.Biblioteca.Dominio.RepositorioDefinicion;
using Curso.Biblioteca.Infraestructura.Context;
using Curso.Biblioteca.Infraestructura.RepositorioImplementacion;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BibliotecaDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<IAutorRepositorio, AutorRepositorio>();
builder.Services.AddTransient<ILibroRepositorio, LibroRepositorio>();
builder.Services.AddTransient<IEditorialRepositorio, EditorialRepositorio>();

builder.Services.AddTransient<IAutorServicio, AutorServicio>();
builder.Services.AddTransient<ILibroServicio, LibroServicio>();
builder.Services.AddTransient<IEditorialServicio, EditorialServicio>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
