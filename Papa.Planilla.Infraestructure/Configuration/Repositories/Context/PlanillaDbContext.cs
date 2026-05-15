using Microsoft.EntityFrameworkCore;
using Papa.Planilla.Domain.Entities;
using PlanillaEntity = Papa.Planilla.Domain.Entities.Planilla;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Papa.Planilla.Infraestructure.Configuration.Repositories.Context
{
    public class PlanillaDbContext(DbContextOptions<PlanillaDbContext> options) : DbContext(options)
    {
        //DbSets
        public DbSet<Cargo> cargos { get; set; }
        public DbSet<Contrato> contratos { get; set; }
        public DbSet<PlanillaEntity> planillas { get; set; }
        public DbSet<Trabajador> trabajadores { get; set; }
        public DbSet<UnidadOrganica> unidadOrganicas { get; set; }

        /*
        //Creamos la cadena de conexión (temporalmente en este lugar, para realizar las migraciones)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=1502;Database=db_planilla;Username=admin;Password=Password2026");
        }
        */

        //Para aplicar las configuraciones en las tablas a crear
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("planilla");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlanillaDbContext).Assembly);
        }
    }
}
