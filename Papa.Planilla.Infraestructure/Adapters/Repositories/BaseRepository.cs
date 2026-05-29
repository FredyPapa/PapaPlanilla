using Microsoft.EntityFrameworkCore;
using Papa.Planilla.Domain.Entities;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Infraestructure.Configuration.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Papa.Planilla.Infraestructure.Adapters.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntidadBase
    {
        private readonly PlanillaDbContext _context;

        public BaseRepository(PlanillaDbContext context)
        {
            _context = context;
        }

        //Guardar
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var response = _context.Set<TEntity>().Add(entity);
            //await _context.SaveChangesAsync();
            return response.Entity;
        }

        //Obtener por Id
        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            //return await _context.Set<TEntity>().FindAsync(id);
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        //Listar varios registros
        public async Task<TEntity?> FindAysnc(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>()
                .Where(predicate)
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }

        //Listar varios registros y con paginado
        public async Task<(ICollection<TResult> Result, int TotalRow)> ListAsync<TResult>
            (
                Expression<Func<TEntity, bool>> predicate, 
                Expression<Func<TEntity, TResult>> selector, 
                int pageNumber, int pageSize
            )
        {
            var query = _context.Set<TEntity>()
                .Where(predicate);
            
            var result = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(selector)
                .ToListAsync();

            var totalRow = await query.CountAsync();

            return (result, totalRow);
        }

    }
}
