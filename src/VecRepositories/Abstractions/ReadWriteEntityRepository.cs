using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace src.VecRepositories.Abstractions
{
    public class ReadWriteEntityRepository<T> : ReadOnlyEntityRepository<T>, IReadWriteEntityRepository<T>
    where T : class, IEntity
    {
        protected ReadWriteEntityRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken)
        {
            if (entity != null)
            {
                await DbEntitySet.AddAsync(entity, cancellationToken);
            }
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {
                DbEntitySet.Remove(entity);
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
        }

    }
}