using Papa.Planilla.Domain.Enums;
using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.Entities
{
    public class Contrato : EntidadBase
    {
        //Atributos
        public Guid TrabajadorId { get; private set; }
        public Trabajador Trabajador { get; private set; } = null!;
        public Guid UnidadOrganicaId { get; set; }
        public UnidadOrganica UnidadOrganica { get; set; } = null!;
        public Guid CargoId { get; private set; }
        public Cargo Cargo { get; private set; } = null!;
        public DateTime FechaInicio { get; private set; }
        public DateTime? FechaFin { get; private set; }
        public Importe Sueldo { get; private set; } = null!;
        public ContratoEstado EstadoContrato { get; set; }

        //Propiedades de Navegación
        private readonly List<Planilla> _planillas = new();
        public IReadOnlyCollection<Planilla> Planillas => _planillas.AsReadOnly();

        //Constructores
        private Contrato() { }

        private Contrato(Trabajador trabajador, UnidadOrganica unidadOrganica, Cargo cargo, DateTime fechaInicio, DateTime? fechaFin, Importe sueldo)
        {
            if (fechaInicio == default)
                throw new ArgumentException("La fecha de inicio no puede estar vacía.", nameof(fechaInicio));
            if (sueldo == null)
                throw new ArgumentException("El sueldo no puede estar vacío.", nameof(sueldo));
            TrabajadorId = trabajador.Id;
            UnidadOrganicaId = unidadOrganica.Id;
            CargoId = cargo.Id;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Sueldo = sueldo;
            EstadoContrato = ContratoEstado.Vigente;
        }

        //Patrón Factory
        public static Contrato Crear(Trabajador trabajador, UnidadOrganica unidadOrganica, Cargo cargo, DateTime fechaInicio, DateTime? fechaFin, Importe sueldo)
        {
            return new Contrato(trabajador, unidadOrganica, cargo, fechaInicio, fechaFin, sueldo);
        }
    }
}
