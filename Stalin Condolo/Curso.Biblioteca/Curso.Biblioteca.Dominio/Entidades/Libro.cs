using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Dominio.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public int EditorialId { get; set; }
        public Editorial Editorial { get; set; }

    }
}
