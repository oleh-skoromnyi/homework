using EFPractice.Core.Entities;
using EFPractice.Core.Models;
using EFPractice.Core.Repositories;
using EFPractice.Core.Specifications;

using EFPractice.DA.Contexts;
using EFPractice.DA.Extentions;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFLecture.DA.Repositories
{
    public class EFCoreRepository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly FileDbContext context;
        protected readonly DbSet<TEntity> entities;

        public EFCoreRepository(FileDbContext context)
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }

        public virtual Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return this.entities.AddAsync(entity, cancellationToken).AsTask();
        }

        public virtual Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return this.entities.AddRangeAsync(entities, cancellationToken);
        }

        public virtual Task<TEntity> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            return this.entities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public virtual Task<TEntity> FindAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return this.entities.FirstOrDefaultAsync(specification.Expression, cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            var query = this.entities.Where(x => true);
            if (specification.Include != null)
            {
                foreach (var include in specification.Include)
                {
                    query = query.Include(include);
                }
            }
            return await query.Where(specification.Expression).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual Task<PagedList<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = this.entities.Where(x=>true);
            if (specification.Include != null)
            {
                foreach (var include in specification.Include)
                { 
                    query = query.Include(include);
                }
            }
            return query.Where(specification.Expression).ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public Task<int> GetCount(Specification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IQueryable<string> GetGrouped(Specification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual Task RemoveAsync(TEntity entities, CancellationToken cancellationToken = default)
        {
            this.entities.Remove(entities);
            return Task.CompletedTask;
        }

        public virtual Task RemoveAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            this.entities.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            this.entities.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            this.entities.UpdateRange(entities);
            return Task.CompletedTask;
        }
    }
}
