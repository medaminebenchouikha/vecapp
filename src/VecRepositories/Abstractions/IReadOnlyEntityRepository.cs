using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace src.VecRepositories.Abstractions
{
    public interface IReadOnlyEntityRepository<T> : IEntityRepository
    where T : class, IEntity
    {
        IQueryable<T> EntityAsQueryable { get; }
        DbContext DbContext { get; }
        Task<IEnumerable<T>> GetAllAsync(int pageIndex, int pageSize = 10, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter, int pageIndex, int pageSize = 10, CancellationToken cancellationToken = default);
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    }
}