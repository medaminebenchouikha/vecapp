using System.Threading;
using System.Threading.Tasks;

namespace src.VecRepositories.Abstractions
{
    public interface IReadWriteEntityRepository<T> : IReadOnlyEntityRepository<T>
    where T : class, IEntity
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}