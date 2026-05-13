using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Papa.Planilla.Domain.Entities
{
    public class Trabajador : EntidadBase
    {
        //Atributos
        public DocumentoIdentidad DocumentoIdentidad { get; private set; }
        public string ApellidoPaterno { get; private set; }
        public string ApellidoMaterno { get; private set; }
        public string Nombres { get; private set; }
        public string? Correo { get; private set; }
        public NumeroCelular NumeroCelular { get; set; }

        //Propiedades de Navegación
        private readonly List<Contrato> _contratos = new();
        public IReadOnlyCollection<Contrato> Contratos => _contratos.AsReadOnly();
        private readonly List<Planilla> _planillas = new();
        public IReadOnlyCollection<Planilla> Planillas => _planillas.AsReadOnly();

        //Constructores
        private Trabajador() { }

        private Trabajador(DocumentoIdentidad documentoIdentidad, string apellidoPaterno, string apellidoMaterno, string nombres, string? correo, NumeroCelular numeroCelular)
        {
            if(documentoIdentidad == null)
                throw new ArgumentException("El documento de identidadno no puede estar vacío.", nameof(documentoIdentidad));
            if(string.IsNullOrWhiteSpace(apellidoPaterno))
                throw new ArgumentException("El apellido paterno no puede estar vacío.", nameof(apellidoPaterno));
            if(string.IsNullOrWhiteSpace(apellidoMaterno))
                throw new ArgumentException("El apellido materno no puede estar vacío.", nameof(apellidoMaterno));
            if(string.IsNullOrWhiteSpace(nombres))
                throw new ArgumentException("Los nombres no pueden estar vacíos.", nameof(nombres));
            if(string.IsNullOrWhiteSpace(correo))
                throw new ArgumentException("El correo no puede estar vacío.", nameof(correo));
            if (numeroCelular == null)
                throw new ArgumentException("El número de celular no puede estar vacío.", nameof(documentoIdentidad));

            DocumentoIdentidad = documentoIdentidad;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Nombres = nombres;
            Correo = correo;
            NumeroCelular = numeroCelular;
        }

        //Patrón Factory
        public static Trabajador Crear(DocumentoIdentidad documentoIdentidad, string apellidoPaterno, string apellidoMaterno, string nombres, string? correo, NumeroCelular numeroCelular)
        {
            return new Trabajador(documentoIdentidad, apellidoPaterno, apellidoMaterno, nombres, correo, numeroCelular);
        }
    }
}
