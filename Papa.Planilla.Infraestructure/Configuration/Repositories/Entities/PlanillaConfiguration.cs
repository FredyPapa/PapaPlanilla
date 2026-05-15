using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanillaEntity = Papa.Planilla.Domain.Entities.Planilla;

namespace Papa.Planilla.Infraestructure.Configuration.Repositories.Entities
{
    public class PlanillaConfiguration : IEntityTypeConfiguration<PlanillaEntity>
    {
        public void Configure(EntityTypeBuilder<PlanillaEntity> builder)
        {
            //Nombre de la tabla
            builder.ToTable("planillas", schema: "planilla");

            //Índices
            builder.HasIndex(p => p.Anio);
            builder.HasIndex(p => p.Mes);
            builder.HasIndex(p => p.TrabajadorId);
            builder.HasIndex(p => p.ContratoId);
            builder.HasIndex(p => p.EstadoPlanilla);

            //Campos
            builder.Property(p => p.Anio)
                    .IsRequired()
                    .HasColumnName("anio_planilla");

            builder.Property(c => c.Mes)
                    .IsRequired()
                    .HasColumnName("mes_planilla");

            // Relaciones
            builder.HasOne(p => p.Trabajador)
                   .WithMany(t => t.Planillas)
                   .HasForeignKey(p => p.TrabajadorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Contrato)
                   .WithMany(c => c.Planillas)
                   .HasForeignKey(p => p.ContratoId)
                   .OnDelete(DeleteBehavior.Restrict);

            //Objetos de valor
            builder.OwnsOne(p => p.SueldoBasico, s =>
            {
                s.Property(d => d.Moneda)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("sueldo_basico_moneda");

                s.Property(d => d.Monto)
                .IsRequired()
                .HasColumnType("decimal(10,2)")
                .HasColumnName("sueldo_basico_monto");
            });

            builder.OwnsOne(p => p.TotalIngresos, s =>
            {
                s.Property(d => d.Moneda)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("total_ingresos_moneda");

                s.Property(d => d.Monto)
                .IsRequired()
                .HasColumnType("decimal(10,2)")
                .HasColumnName("total_ingresos_monto");
            });

            builder.OwnsOne(p => p.TotalDescuentos, s =>
            {
                s.Property(d => d.Moneda)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("total_descuento_moneda");

                s.Property(d => d.Monto)
                .IsRequired()
                .HasColumnType("decimal(10,2)")
                .HasColumnName("total_descuento_monto");
            });

            //Campo
            builder.Property(p => p.EstadoPlanilla)
                    .IsRequired()
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .HasColumnName("estado_planilla");

            //Campos a ignorar porque son calculados (no se guardan en base de datos)
            builder.Ignore(p => p.SueldoNeto);
        }
    }
}