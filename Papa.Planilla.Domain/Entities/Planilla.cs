using Papa.Planilla.Domain.Enums;
using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.Entities
{
    public class Planilla : EntidadBase
    {
        public int Anio { get; private set; }
        public int Mes { get; private set; }
        public Guid TrabajadorId { get; private set; }
        public Trabajador Trabajador { get; private set; }
        public Guid ContratoId { get; private set; }
        public Contrato Contrato { get; private set; }
        public Importe SueldoBasico { get; private set; }
        public Importe TotalIngresos { get; private set; }
        public Importe TotalDescuentos { get; private set; }
        public Importe SueldoNeto => TotalIngresos - TotalDescuentos;
        public PlanillaEstado EstadoPlanilla { get; set; }

        private Planilla() { }

        private Planilla(int anio, int mes, Trabajador trabajador, Contrato contrato, Importe sueldoBasico, Importe totalIngresos, Importe totalDescuentos)
        {
            if (anio <= 0)
                throw new ArgumentException("El año debe ser un número positivo.", nameof(anio));
            if (mes < 1 || mes > 12)
                throw new ArgumentException("El mes debe estar entre 1 y 12.", nameof(mes));
            if (sueldoBasico == null)
                throw new ArgumentException("El sueldo básico no puede estar vacío.", nameof(sueldoBasico));
            if (totalIngresos == null)
                throw new ArgumentException("El total de ingresos no puede estar vacío.", nameof(totalIngresos));
            if (totalDescuentos == null)
                throw new ArgumentException("El total de descuentos no puede estar vacío.", nameof(totalDescuentos));
            
            Anio = anio;
            Mes = mes;
            TrabajadorId = trabajador.Id;
            ContratoId = contrato.Id;
            SueldoBasico = sueldoBasico;
            TotalIngresos = totalIngresos;
            TotalDescuentos = totalDescuentos;
            EstadoPlanilla = PlanillaEstado.Pendiente;
        }

        public static Planilla Crear(int anio, int mes, Trabajador trabajador, Contrato contrato, Importe sueldoBasico, Importe totalIngresos, Importe totalDescuentos)
        {
            return new Planilla(anio, mes, trabajador, contrato, sueldoBasico, totalIngresos, totalDescuentos);
        }

        public void Procesado()
        {
            if (EstadoPlanilla == PlanillaEstado.Procesado)
                throw new InvalidOperationException("La planilla ya ha sido procesada.");
            EstadoPlanilla = PlanillaEstado.Procesado;
        }
    }
}
