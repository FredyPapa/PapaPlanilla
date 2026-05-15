using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papa.Planilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Infraestructure.Configuration.Repositories.Entities
{
    public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            //Nombre de la tabla
            builder.ToTable("contratos", schema: "planilla");

            //Índices
            builder.HasIndex(c => c.TrabajadorId);
            builder.HasIndex(c => c.UnidadOrganicaId);
            builder.HasIndex(c => c.CargoId);
            builder.HasIndex(c => c.EstadoContrato);
            builder.HasIndex(c => c.FechaInicio);
            builder.HasIndex(c => c.FechaFin);

            //Relaciones
            builder.HasOne(c => c.Trabajador)
                   .WithMany(t => t.Contratos)
                   .HasForeignKey(c => c.TrabajadorId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            builder.HasOne(c => c.UnidadOrganica)
                   .WithMany(u => u.Contratos)
                   .HasForeignKey(c => c.UnidadOrganicaId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            builder.HasOne(c => c.Cargo)
                   .WithMany(ca => ca.Contratos)
                   .HasForeignKey(c => c.CargoId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            //Campos
            builder.Property(c => c.FechaInicio)
                    .IsRequired()
                    .HasColumnName("fecha_inicio");

            builder.Property(c => c.FechaFin)
                    .IsRequired(false)
                    .HasColumnName("fecha_fin");

            //Objeto de valor
            builder.OwnsOne(c => c.Sueldo, s =>
            {
                s.Property(d => d.Moneda)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("sueldo_moneda");

                s.Property(d => d.Monto)
                .IsRequired()
                .HasColumnType("decimal(10,2)")
                .HasColumnName("sueldo_monto");
            });

            //Campo
            builder.Property(c => c.EstadoContrato)
                    .IsRequired()
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .HasColumnName("estado_contrato");

        }
    }
}
