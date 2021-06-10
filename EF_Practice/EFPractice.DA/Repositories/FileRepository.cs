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
    public class FileRepository : IRepository<File>
    {
        protected readonly FileDbContext context;
        protected readonly DbSet<File> entities;

        public FileRepository(FileDbContext context)
        {
            this.context = context;
            this.entities = this.context.Set<File>();
        }

        public virtual Task AddAsync(File entity, CancellationToken cancellationToken = default)
        {
            return this.entities.AddAsync(entity, cancellationToken).AsTask();
        }

        public virtual Task AddAsync(IEnumerable<File> entities, CancellationToken cancellationToken = default)
        {
            return this.entities.AddRangeAsync(entities, cancellationToken);
        }

        public virtual Task<File> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            return this.entities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public virtual Task<File> FindAsync(Specification<File> specification, CancellationToken cancellationToken = default)
        {
            return this.entities.FirstOrDefaultAsync(specification.Expression, cancellationToken);
        }

        public virtual async Task<IEnumerable<File>> GetAsync(Specification<File> specification, CancellationToken cancellationToken = default)
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

        public virtual Task<PagedList<File>> GetAsync(Specification<File> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
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

        public Task<int> GetCount(Specification<File> specification, CancellationToken cancellationToken = default)
        {
            var query = this.entities.Where(x => true);
            if (specification.Include != null)
            {
                foreach (var include in specification.Include)
                {
                    query = query.Include(include);
                }
            }
            return query.Where(specification.Expression).CountAsync();
        }

        public IQueryable<string> GetGrouped(Specification<File> specification, CancellationToken cancellationToken = default)
        {
            var query = this.entities.Where(x => true);
            
            if (specification != null)
            {
                if (specification.Include != null)
                {
                    foreach (var include in specification.Include)
                    {
                        query = query.Include(include);
                    }
                }
                query = query.Where(specification.Expression);
            }
            return query.GroupBy(y => y.Type).Select(x=>$"{x.Key} -- {x.Count()}");
        }

        public virtual Task RemoveAsync(File entities, CancellationToken cancellationToken = default)
        {
            this.entities.Remove(entities);
            return Task.CompletedTask;
        }

        public virtual Task RemoveAsync(IEnumerable<File> entities, CancellationToken cancellationToken = default)
        {
            this.entities.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(File entity, CancellationToken cancellationToken = default)
        {
            this.entities.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(IEnumerable<File> entities, CancellationToken cancellationToken = default)
        {
            this.entities.UpdateRange(entities);
            return Task.CompletedTask;
        }
    }
}
