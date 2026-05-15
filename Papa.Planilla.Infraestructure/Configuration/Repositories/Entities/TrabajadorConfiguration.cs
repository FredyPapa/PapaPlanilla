using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papa.Planilla.Domain.Entities;

namespace Papa.Planilla.Infraestructure.Configuration.Repositories.Entities
{
    public class TrabajadorConfiguration : IEntityTypeConfiguration<Trabajador>
    {
        public void Configure(EntityTypeBuilder<Trabajador> builder)
        {
            //Nombre de la tabla
            builder.ToTable("trabajadores",schema: "planilla");

            //Objeto de valor
            builder.OwnsOne(t => t.DocumentoIdentidad, di =>
            {
                di.Property(d => d.Tipo)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("tipo_documento");

                di.Property(d => d.Numero)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("numero_documento");

                //Para evitar duplicidad en tipo y número (no debería existir 2 DNI con el mismo número)
                di.HasIndex(d => new { d.Tipo, d.Numero }).IsUnique();
            });

            //Campos
            builder.Property(t => t.ApellidoPaterno)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("apellido_paterno");

            builder.Property(t => t.ApellidoMaterno)
                .IsRequired(false)
                .HasMaxLength(50)
                .HasColumnName("apellido_materno");

            builder.Property(t => t.Nombres)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombres");

            builder.Property(t => t.Correo)
                .IsRequired(false)
                .HasMaxLength(150)
                .HasColumnName("correo");

            //Objeto de valor
            builder.OwnsOne(t => t.NumeroCelular, nc =>
            {
                nc.Property(d => d.CodigoPais)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnName("celular_codigo_pais");

                nc.Property(d => d.Numero)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("celular_numero");

                //Para evitar duplicidad en tipo y número (no debería existir 2 DNI con el mismo número)
                nc.HasIndex(d => new { d.CodigoPais, d.Numero }).IsUnique();
            });

            //Relación de Muchos a 1 para Navegación (HasMany)
            builder.HasMany(t => t.Contratos)
                .WithOne(c => c.Trabajador)
                .HasForeignKey(c => c.TrabajadorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasMany(t => t.Planillas)
                .WithOne(p => p.Trabajador)
                .HasForeignKey(p => p.TrabajadorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

        }
    }
}
