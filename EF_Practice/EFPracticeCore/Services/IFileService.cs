using EFPractice.Core.Entities;
using EFPractice.Core.Models;
using EFPractice.Core.Specifications;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFPractice.Core.Services
{
    public interface IFileService
    {
        Task<File> FindAsync(int id, CancellationToken cancellationToken = default);


        Task<File> FindAsync(Specification<File> specification, CancellationToken cancellationToken = default);

        Task<IEnumerable<File>> GetAsync(Specification<File> specification, CancellationToken cancellationToken = default);

        Task<PagedList<File>> GetAsync(Specification<File> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default);

        Task AddAsync(File entity, CancellationToken cancellationToken = default);

        Task AddAsync(IEnumerable<File> entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(File entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(IEnumerable<File> entity, CancellationToken cancellationToken = default);

        Task RemoveAsync(File entity, CancellationToken cancellationToken = default);

        Task RemoveAsync(IEnumerable<File> entity, CancellationToken cancellationToken = default);

    }
}
