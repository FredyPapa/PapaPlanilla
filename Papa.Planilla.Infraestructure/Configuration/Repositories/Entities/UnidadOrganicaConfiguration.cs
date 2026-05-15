using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papa.Planilla.Domain.Entities;

namespace Papa.Planilla.Infraestructure.Configuration.Repositories.Entities
{
    public class UnidadOrganicaConfiguration : IEntityTypeConfiguration<UnidadOrganica>
    {
        public void Configure(EntityTypeBuilder<UnidadOrganica> builder)
        {
            //Nombre de la tabla
            builder.ToTable("unidades_organicas", schema: "planilla");

            //Campos
            builder.Property(uo => uo.Descripcion)
                .IsRequired()
                .HasMaxLength(350)
                .HasColumnName("descripcion");

            //Objeto de valor
            builder.OwnsOne(c => c.CodigoPresupuestal, cp =>
            {
                cp.Property(d => d.Codigo)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("codigo_presupuestal");

                cp.Property(d => d.Descripcion)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("codigo_presupuestal_descripcion");

                //Para evitar duplicidad en tipo y número (no debería existir 2 DNI con el mismo número)
                cp.HasIndex(d => new { d.Codigo, d.Descripcion}).IsUnique();
            });

        }
    }
}