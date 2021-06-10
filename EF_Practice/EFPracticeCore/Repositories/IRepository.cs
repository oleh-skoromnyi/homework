using EFPractice.Core.Entities;
using EFPractice.Core.Models;
using EFPractice.Core.Specifications;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFPractice.Core.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {

        Task<TEntity> FindAsync(int id, CancellationToken cancellationToken = default);

        Task<TEntity> FindAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<PagedList<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task AddAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default);

        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task RemoveAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default);

        Task<int> GetCount(Specification<TEntity> specification, CancellationToken cancellationToken = default);

        IQueryable<string> GetGrouped(Specification<TEntity> specification = null, CancellationToken cancellationToken = default);
        
    }
}
