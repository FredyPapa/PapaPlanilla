using Papa.Planilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Papa.Planilla.Domain.Ports.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : EntidadBase
    {
        Task<TEntity> AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity?> FindAysnc(Expression<Func<TEntity, bool>> predicate);
        Task<(ICollection<TResult> Result, int TotalRow)> ListAsync<TResult>
        (
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TResult>> selector,
            int pageNumber, int pageSize
        );
    }
}
