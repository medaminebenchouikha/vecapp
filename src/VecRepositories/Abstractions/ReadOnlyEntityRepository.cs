using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace src.VecRepositories.Abstractions
{
    public class ReadOnlyEntityRepository<T> : IReadOnlyEntityRepository<T>
    where T : class, IEntity
    {
        public IQueryable<T> EntityAsQueryable { get; protected set; }
        public DbContext DbContext { get; }
        public bool Disposed => _disposedValue;
        protected DbSet<T> DbEntitySet { get; private set; }
        protected ReadOnlyEntityRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbEntitySet = DbContext.Set<T>();
            EntityAsQueryable = DbEntitySet.AsQueryable();
        }
        public async Task<IEnumerable<T>> GetAllAsync(int pageIndex, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            return await EntityAsQueryable.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter, int pageIndex, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            return await EntityAsQueryable.Where(filter).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await EntityAsQueryable.CountAsync(cancellationToken);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
        {
            return await EntityAsQueryable.Where(filter).CountAsync(cancellationToken);
        }

        #region IDisposable Support

        private bool _disposedValue;

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        protected void ThrowIfDisposed()
        {
            if (Disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
        #endregion
    }
}