using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.Ports.Messages
{
    public interface IRabbitConsumerService
    {
        Task SubscribeAsync<TMessage>(string queueName, Func<IServiceProvider, TMessage, Task> onMessage);
    }
}
