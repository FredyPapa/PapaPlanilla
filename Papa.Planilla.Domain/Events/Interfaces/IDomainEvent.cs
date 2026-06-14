using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.Events.Interfaces
{
    public interface IDomainEvent
    {
        Guid Id { get; }
        DateTime OcurredOn { get; }
    }
}
