using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Results
{
    public class BaseResponse<T>
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public int? ErrorCode { get; set; }

        // ¡AQUÍ ESTÁ EL AJUSTE CLAVE!
        // Esta propiedad se adaptará automáticamente a cualquier tipo de dato (una lista o un objeto único)
        public T? Data { get; set; }
    }
}