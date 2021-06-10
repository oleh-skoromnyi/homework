using EFPractice.Core.Entities;
using EFPractice.Core.Models;
using EFPractice.Core.Repositories;
using EFPractice.Core.Services;
using EFPractice.Core.Specifications;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFPractice.BLL.Services
{
    public class FileService : IFileService
    {
        protected readonly IRepository<File> repository;
        protected readonly IRepository<Directory> dirRepository;

        public FileService(IRepository<File> repository, IRepository<Directory> dirRepository)
        {
            this.repository = repository;
            this.dirRepository = dirRepository;
        }

        public async Task AddAsync(File entity, CancellationToken cancellationToken = default)
        {
            await this.repository.AddAsync(entity, cancellationToken);
        }

        public Task AddAsync(IEnumerable<File> entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task<File> FindAsync(int id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task<File> FindAsync(Specification<File> specification, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task<IEnumerable<File>> GetAsync(Specification<File> specification, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task<PagedList<File>> GetAsync(Specification<File> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return this.repository.GetAsync(specification, pageNumber, pageSize, cancellationToken);
        }
        public Task RemoveAsync(File entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task RemoveAsync(IEnumerable<File> entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task UpdateAsync(File entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task UpdateAsync(IEnumerable<File> entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task<PagedList<File>> GetAvailableFilesInDirectory(User user, Directory directory, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var includes = new List<Expression<Func<File, object>>>();
            includes.Add(y => y.FilePermissions.Where(x => x.CanRead && x.UserId == user.Id));
            return this.GetAsync(new Specification<File>(
                    x => x.DirectoryId == directory.Id,
                    includes),
                pageNumber, pageSize, cancellationToken);
        }

        public Task<List<Entity>> GetDirectoryAndSub(Directory directory, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var includes = new List<Expression<Func<Directory, object>>>();
            //includes.Add(y => y.Children.Where(x => x.Id == y.ParentId));
            var directories = this.dirRepository.GetAsync(new Specification<Directory>(
                    x => x.ParentId == directory.Id,
                    includes),
                pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            var files = this.repository.GetAsync(new Specification<File>(
                    x => x.DirectoryId == directory.Id),
                pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            var result = new List<Entity>();
            result.AddRange(directories);
            result.AddRange(files);
            return Task.FromResult(result);
        }

        public List<string> GetDirectoryAndSubWithFullPath(Directory directory, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var result = new List<string>();
            var tempPath = "";
            var tempDir = this.dirRepository.GetAsync(new Specification<Directory>(x => x.Id == directory.Id), 1, 1).Result.Items.FirstOrDefault();
            result.AddRange(DirectoryFiles(null, tempPath, tempDir, pageNumber, pageSize));
            return result;
        }

        public Task<List<Entity>> GetAvailableDirectoryAndSub(User user, Directory directory, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var dirIncludes = new List<Expression<Func<Directory, object>>>();
            var fileIncludes = new List<Expression<Func<File, object>>>();
            //dirIncludes.Add(y => y.Children.Where(x => x.Id == y.ParentId));
            dirIncludes.Add(y => y.DirectoryPermissions.Where(x => x.UserId == user.Id && x.CanRead));
            fileIncludes.Add(y => y.FilePermissions.Where(x => x.UserId == user.Id && x.CanRead));
            var directories = this.dirRepository.GetAsync(new Specification<Directory>(
                    x => x.ParentId == directory.Id,
                    dirIncludes),
                pageNumber, pageSize, cancellationToken).Result.Items.Where(x => x.DirectoryPermissions.Any(y => y.UserId == user.Id)).ToList();
            var files = this.repository.GetAsync(new Specification<File>(
                    x => x.DirectoryId == directory.Id, fileIncludes),
                pageNumber, pageSize, cancellationToken).Result.Items.Where(x => x.FilePermissions.Any(y => y.UserId == user.Id)).ToList();
            var result = new List<Entity>();
            result.AddRange(directories);
            result.AddRange(files);
            return Task.FromResult(result);
        }

        public List<string> GetAvailableDirectoryAndSubWithFullPath(User user, Directory directory, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var result = new List<string>();
            var tempPath = "";
            var tempDir = this.dirRepository.GetAsync(new Specification<Directory>(x => x.Id == directory.Id), 1, 1).Result.Items.FirstOrDefault();
            var dirIncludes = new List<Expression<Func<Directory, object>>>();
            var fileIncludes = new List<Expression<Func<File, object>>>();
            dirIncludes.Add(y => y.DirectoryPermissions.Where(x => x.UserId == user.Id && x.CanRead));
            fileIncludes.Add(y => y.FilePermissions.Where(x => x.UserId == user.Id && x.CanRead));
            result.AddRange(DirectoryFiles(user, tempPath, tempDir, pageNumber, pageSize, dirIncludes, fileIncludes));
            return result;
        }
        private List<string> DirectoryFiles(User user, string tempPath, Directory tempDir, int pageNumber, int pageSize, List<Expression<Func<Directory, object>>> dirInclude = default, List<Expression<Func<File, object>>> fileInclude = default, CancellationToken cancellationToken = default)
        {

            var directories = this.dirRepository.GetAsync(new Specification<Directory>(
                        x => x.ParentId == tempDir.Id, dirInclude),
                    pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            var files = this.repository.GetAsync(new Specification<File>(
                    x => x.DirectoryId == tempDir.Id, fileInclude),
                pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            var curPath = tempPath + tempDir.Title + '\\';
            var result = new List<string>();

            if (dirInclude != default)
            {
                directories = directories.Where(x => x.DirectoryPermissions != null).Where(x => x.DirectoryPermissions.Any(y => y.UserId == user.Id)).ToList();
                files = files.Where(x => x.FilePermissions != null).Where(x => x.FilePermissions.Any(y => y.UserId == user.Id)).ToList();
            }

            foreach (var dir in directories)
            {
                result.AddRange(DirectoryFiles(user, curPath, dir, pageNumber, pageSize, dirInclude, fileInclude));
            }
            foreach (var file in files)
            {
                result.Add(curPath + file.Title + file.Extension);
            }
            return result;
        }

        public List<int> GetFilesInFolderCountAndAvailableForUser(User user, Directory directory, CancellationToken cancellationToken = default)
        {
            var result = new List<int>();
            var includes = new List<Expression<Func<File, object>>>();
            includes.Add(y => y.FilePermissions.Where(x => x.CanRead && x.UserId == user.Id));
            result.Add(this.repository.GetCount(new Specification<File>(
                    x => x.DirectoryId == directory.Id)
                    , cancellationToken).Result);
            result.Add(this.repository.GetCount(new Specification<File>(
                    x => x.DirectoryId == directory.Id,
                    includes), cancellationToken).Result);
            return result;
        }
        public List<string> GetGroupedFileCountByType()
        {
            return this.repository.GetGrouped().ToList();
        }
    }
}
