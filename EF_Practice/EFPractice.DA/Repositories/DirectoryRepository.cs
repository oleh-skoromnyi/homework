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

namespace EFPractice.DA.Repositories
{
    public class DirectoryRepository : IRepository<Directory>
    {
        protected readonly FileDbContext context;
        protected readonly DbSet<Directory> entities;

        public DirectoryRepository(FileDbContext context)
        {
            this.context = context;
            this.entities = this.context.Set<Directory>();
        }

        public virtual Task AddAsync(Directory entity, CancellationToken cancellationToken = default)
        {
            return this.entities.AddAsync(entity, cancellationToken).AsTask();
        }

        public virtual Task AddAsync(IEnumerable<Directory> entities, CancellationToken cancellationToken = default)
        {
            return this.entities.AddRangeAsync(entities, cancellationToken);
        }

        public virtual Task<Directory> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            return this.entities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public virtual Task<Directory> FindAsync(Specification<Directory> specification, CancellationToken cancellationToken = default)
        {
            return this.entities.FirstOrDefaultAsync(specification.Expression, cancellationToken);
        }

        public virtual async Task<IEnumerable<Directory>> GetAsync(Specification<Directory> specification, CancellationToken cancellationToken = default)
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

        public virtual Task<PagedList<Directory>> GetAsync(Specification<Directory> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = this.entities.Where(x => true);
            if (specification.Include != null)
            {
                foreach (var include in specification.Include)
                {
                    query = query.Include(include);
                }
            }
            return query.Where(specification.Expression).ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public Task<int> GetCount(Specification<Directory> specification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IQueryable<string> GetGrouped(Specification<Directory> specification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual Task RemoveAsync(Directory entities, CancellationToken cancellationToken = default)
        {
            this.entities.Remove(entities);
            return Task.CompletedTask;
        }

        public virtual Task RemoveAsync(IEnumerable<Directory> entities, CancellationToken cancellationToken = default)
        {
            this.entities.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(Directory entity, CancellationToken cancellationToken = default)
        {
            this.entities.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(IEnumerable<Directory> entities, CancellationToken cancellationToken = default)
        {
            this.entities.UpdateRange(entities);
            return Task.CompletedTask;
        }
    }
}
