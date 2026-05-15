using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papa.Planilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Infraestructure.Configuration.Repositories.Entities
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            //Nombre de la tabla
            builder.ToTable("cargos", schema: "planilla");

            //Campos
            builder.Property(c => c.Descripcion)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("descripcion");
        }
    }
}
