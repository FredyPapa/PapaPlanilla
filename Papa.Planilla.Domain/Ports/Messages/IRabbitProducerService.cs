using Papa.Planilla.Domain.Model.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.Ports.Messages
{
    public interface IRabbitProducerService
    {
        Task PublishAsync(MessageBody request);
    }
}
