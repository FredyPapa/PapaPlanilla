using Papa.Planilla.Domain.Ports.Services;
using Papa.Planilla.Infraestructure.Configuration.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Infraestructure.Adapters.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlanillaDbContext _context;
        private readonly DomainEventDispatcher _dispatcher;

        public UnitOfWork(PlanillaDbContext context, DomainEventDispatcher dispatcher)
        {
            _context = context;
            _dispatcher = dispatcher;
        }

        public async Task<int> SaveChangesAsync()
        {
            await _dispatcher.DispatchEventAsync(_context);
            return await _context.SaveChangesAsync();
        }
    }
}
