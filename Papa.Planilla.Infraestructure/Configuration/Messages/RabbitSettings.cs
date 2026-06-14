using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Infraestructure.Configuration.Messages
{
    public class RabbitSettings
    {
        public string Hostname { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
