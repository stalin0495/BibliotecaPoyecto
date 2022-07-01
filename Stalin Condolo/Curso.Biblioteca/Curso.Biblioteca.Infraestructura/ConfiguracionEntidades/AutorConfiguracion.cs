﻿using Curso.Biblioteca.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.ConfiguracionEntidades
{
    public class AutorConfiguracion : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autores");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
            .IsRequired();

            builder.Property(b => b.Nombre)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(b => b.Apellido)
            .HasMaxLength(100)
            .IsRequired();
        }
    }
}
