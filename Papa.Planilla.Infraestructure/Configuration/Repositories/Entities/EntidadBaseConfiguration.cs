using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papa.Planilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Infraestructure.Configuration.Repositories.Entities
{
    public class EntidadBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntidadBase
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FechaCreacion).IsRequired();
            builder.Property(e => e.UsuarioCreacion).IsRequired(false);
            builder.Property(e => e.FechaActualizacion).IsRequired();
            builder.Property(e => e.UsuarioActualizacion).IsRequired(false);
        }
    }
}
