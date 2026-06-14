using Papa.Planilla.Domain.Enums;
using Papa.Planilla.Domain.Events;
using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.Entities
{
    public class Planilla : EntidadBase
    {
        //Atributos
        public int Anio { get; private set; }
        public Meses Mes { get; private set; }
        public Guid TrabajadorId { get; private set; }
        public Trabajador Trabajador { get; private set; } = null!;
        public Guid ContratoId { get; private set; }
        public Contrato Contrato { get; private set; } = null!;
        public Importe SueldoBasico { get; private set; } = null!;
        public Importe TotalIngresos { get; private set; } = null!;
        public Importe TotalDescuentos { get; private set; } = null!;
        public Importe SueldoNeto => TotalIngresos - TotalDescuentos;
        public PlanillaEstado EstadoPlanilla { get; set; }

        //Constructores
        private Planilla() { }

        private Planilla(int anio, Meses mes, Trabajador trabajador, Contrato contrato, Importe sueldoBasico, Importe totalIngresos, Importe totalDescuentos)
        {
            if (anio <= 0)
                throw new ArgumentException("El año debe ser un número positivo.", nameof(anio));
            if (!Enum.IsDefined(typeof(Meses), mes))
                throw new ArgumentException("El valor ingresado no es válido", nameof(mes));
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

            //Agregamos al evento de dominio (encolar)
            AddDomainEvent(
                new PlanillaCreatedDomainEvent(
                    Id,
                    TrabajadorId,
                    ContratoId,
                    Anio,
                    (int)Mes,
                    SueldoBasico.Moneda,
                    SueldoBasico.Monto,
                    TotalIngresos.Moneda,
                    TotalIngresos.Monto,
                    TotalDescuentos.Moneda,
                    TotalDescuentos.Monto
                )
            );
        }

        //Patrón Factory
        public static Planilla Crear(int anio, Meses mes, Trabajador trabajador, Contrato contrato, Importe sueldoBasico, Importe totalIngresos, Importe totalDescuentos)
        {
            return new Planilla(anio, mes, trabajador, contrato, sueldoBasico, totalIngresos, totalDescuentos);
        }

        //Actualizar
        public void Actualizar(int anio, Meses mes, Guid trabajadorId, Guid contratoId, Importe sueldoBasico, Importe totalIngresos, Importe totalDescuentos, PlanillaEstado estadoPlanilla)
        {
            if (anio <= 0)
                throw new ArgumentException("El año debe ser un número positivo.", nameof(anio));
            if (!Enum.IsDefined(typeof(Meses), mes))
                throw new ArgumentException("El valor ingresado no es válido", nameof(mes));
            if (sueldoBasico == null)
                throw new ArgumentException("El sueldo básico no puede estar vacío.", nameof(sueldoBasico));
            if (totalIngresos == null)
                throw new ArgumentException("El total de ingresos no puede estar vacío.", nameof(totalIngresos));
            if (totalDescuentos == null)
                throw new ArgumentException("El total de descuentos no puede estar vacío.", nameof(totalDescuentos));

            Anio = anio;
            Mes = mes;
            TrabajadorId = trabajadorId;
            ContratoId = contratoId;
            SueldoBasico = sueldoBasico;
            TotalIngresos = totalIngresos;
            TotalDescuentos = totalDescuentos;
            EstadoPlanilla = estadoPlanilla;
            FechaActualizacion = DateTime.UtcNow;
            UsuarioActualizacion = 1;
        }

        //Métodos de negocio
        public void Procesado()
        {
            if (EstadoPlanilla == PlanillaEstado.Procesado)
                throw new InvalidOperationException("La planilla ya ha sido procesada.");
            EstadoPlanilla = PlanillaEstado.Procesado;
        }
    }
}
