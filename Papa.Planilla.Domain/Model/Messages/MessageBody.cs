using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.Model.Messages
{
    public class MessageBody
    {
        public string QueueName { get; set; } = default!;
        public object Body { get; set; } = default!;
    }
}
